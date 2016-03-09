using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Lumi_Uploader_for_TinySafeBoot
{
    class tsb
    {
        public delegate void TsbConnected(object sender, bool tsbConnectionStatus);
        public event TsbConnected TsbConnectedEventHandler;

        // Create serial command timeout timer.
        private static System.Timers.Timer tsbCommandTimer;

        // Connected to TSB.
        private bool tsbConnected = false;

        const int commandAttempts = 3;
        private int commandAttemptsIndex = 0;

        private string rxBuffer = "";

        // Firmware date.
        public string firmwareDateString;
        long firmwareDate;

        // Atmel device signature.
        string deviceSignature;
        // The size is in words, make it bytes.
        int pageSize;
        // Get flash size.
        int flashSize;
        // Get EEPROM size.
        int fullEepromSize;
        // Number of pages
        int numberOfPages = 0;

        // Flash Read Buffer
        byte[] readFlashBuffer = { 0 };
        int readFlashPageIndex = 0;

        commands commandInProgress = new commands();

        SerialPortsExtended serialPorts;
        RichTextBox mainDisplay;
        ProgressBar progressBar;

        public string readFlash(SerialPortsExtended serialPort)
        {
            return "";
        } 

        public void init(SerialPortsExtended serialPortMain, RichTextBox mainDisplayMain, ProgressBar mainProgressBar)
        {
            serialPorts = serialPortMain;
            mainDisplay = mainDisplayMain;
            serialPorts.DataReceivedForTSB += new SerialPortsExtended.DataReceivedForTSBCallback(gotData);
            progressBar = mainProgressBar;

        }


        // TSB Actions in Progress
        public enum tsbActionsInProgress: int
        {
            none = 0,
            handshaking = 1,
            readingFlash = 2
        }

        // TSB Command Variables
        public enum commands: int
        {
           none = 0,
           hello = 1,
           request = 2,
           confirm = 3,
           readFlash = 4,
           writeFlash = 5,  
           readEEPROM = 6,
           writeEEPROM = 7,
           readUserData = 8,
           writeUserData = 9,
           error = 10
        }

        public static string[] commandsAsStrings =
        {
            "",
            "@@@",
            "?",
            "!",
            "f",
            "F",
            "e",
            "E",
            "c",
            "C",
        };

        public string commandString(commands commandNumber)
        {
            // 1. Return the command string.
            return commandsAsStrings[(int)commandNumber];
        }

        public void execute(commands commandNumber, int timer)
        {
            // 1. Update actionInProgress
            // 2. Set write timeout callback.
            // 3. Capture the serial stream.
            // 4. Write command to serial port.

            if (mainDisplay.InvokeRequired)
            {
                mainDisplay.Invoke(new Action<commands, int>(execute), new object[] { commandNumber, timer });
                return;
            }
            updateActionInProgress(commandNumber);
            //setCommandTimer(timer);
            serialPorts.setCaptureStream(true);
            serialPorts.WriteData(commandsAsStrings[(int)commandNumber]);
            if((int)commandNumber == 4)
            {
                serialPorts.WriteData("!");
            }
        }

        public void updateActionInProgress(commands commandNumber)
        {
            commandInProgress = commandNumber;
        }

        // Read Data.
        public void gotData(object sender, string data)
        {
            // 1. Disable commandTimmer
            // 2. Switch to command in progress.
            if(tsbCommandTimer != null )//|| tsbCommandTimer.Enabled == true)
            {
                tsbCommandTimer.Enabled = false;
            }

            rxBuffer += data;
            Console.WriteLine(data);
            Console.WriteLine(rxBuffer.Length);

            switch (commandInProgress)
            {
                case commands.hello:
                    updateActionInProgress(commandInProgress);
                    helloProcessing();
                    break;
                case commands.readFlash:
                    updateActionInProgress(commandInProgress);
                    //execute(commands.readFlash, 700);
                    //execute(commands.confirm, 700);
                    readFlash();
                    break;
                case commands.error:
                    Console.WriteLine("Error!!");
                    break;
                default:
                    Console.WriteLine("Error while checking command progress.");
                    break;
            }
            

        }

        private void setCommandTimer(int milliseconds)
        {
            // 1. Set a timer for response on a TSB command.
            // 2. Add callback method.
            // 3. Define timer behaviors.
            //Console.WriteLine("Set timer for {0}ms", milliseconds);
            if(milliseconds > 0)
            {
                // Create a timer with a x second interval.
                tsbCommandTimer = new System.Timers.Timer(milliseconds);
                // Hook up the Elapsed event for the timer. 
                tsbCommandTimer.Elapsed += tsbCommandTimerTimeout;
                tsbCommandTimer.AutoReset = false;
                tsbCommandTimer.Enabled = true;
            }
        }

        private void tsbCommandTimerTimeout(object source, EventArgs e)
        {
            if(commandAttemptsIndex < commandAttempts)
            {
                //execute(commandInProgress, 500);
                commandAttemptsIndex++;
            } else
            {
                commandAttemptsIndex = 0;
            }

            tsbCommandTimer.Enabled = false;
            serialPorts.setCaptureStream(false);
            Console.WriteLine("Timer expired");
        }


        private void helloProcessing()
        {

            int[] firmwareDatePieces = { 0x00, 0x00 };
            int firmwareStatus = 0x00;
            int[] signatureBytes = { 0x00, 0x00, 0x00 };
            int pagesizeInWords = 0x00;
            int[] freeFlash = { 0x00, 0x00 };
            int[] eepromSize = { 0x00, 0x00 };

            if (rxBuffer.Length < 15)
            {

                Console.WriteLine(rxBuffer);
                //Console.WriteLine(rxBuffer.Length);
            } else if (rxBuffer.Contains("tsb") || rxBuffer.Contains("TSB") && rxBuffer.Length == 17)
            {
                Console.WriteLine(rxBuffer.Length);
                byte[] tsbGreetingBytes = Encoding.Default.GetBytes(rxBuffer);
                
                if (rxBuffer.Length > 16)
                {
                    firmwareDatePieces[0] = rxBuffer[3];
                    firmwareDatePieces[1] = rxBuffer[4];
                    firmwareStatus = rxBuffer[5];
                    signatureBytes[0] = rxBuffer[6];
                    signatureBytes[1] = rxBuffer[7];
                    signatureBytes[2] = rxBuffer[8];
                    pagesizeInWords = rxBuffer[9];
                    freeFlash[0] = rxBuffer[10];
                    freeFlash[1] = rxBuffer[11];
                    eepromSize[0] = rxBuffer[12];
                    eepromSize[1] = rxBuffer[13];
                }

                // Date of firmware.
                int day = firmwareDatePieces[0];
                int month = ((firmwareDatePieces[1] & 0xF0) >> 1);
                int year = (firmwareDatePieces[1] & 0x0F);
                Console.WriteLine(firmwareDate);
                firmwareDateString = (month + " " + day + " " + "20" + year);

                // Atmel device signature.
                deviceSignature = signatureBytes[0].ToString("X2") + " " + signatureBytes[1].ToString("X2") + " " + signatureBytes[2].ToString("X2");

                // The size is in words, make it bytes.
                pageSize = (pagesizeInWords * 2);
                string pageSizeString = (pagesizeInWords * 2).ToString();

                // REPLACE WITH DEVICE INFO
                numberOfPages = 32768 / pageSize;

                // Get flash size.
                flashSize = ((freeFlash[1] << 8) | freeFlash[0])*2;
                string flashLeft = flashSize.ToString();

                // Get EEPROM size.
                fullEepromSize = ((eepromSize[1] << 8) | eepromSize[0])+1;
                string eeprom = fullEepromSize.ToString();

                setMainDisplayTextSafely("Firmware Date:\t" + firmwareDateString
                    + "\nStatus:\t\t" + firmwareStatus.ToString("X2")
                    + "\nSignature:\t\t" + deviceSignature
                    + "\nPage Size:\t\t" + pageSizeString
                    + "\nFlash Free:\t\t" + flashLeft
                    + "\nEEPROM size:\t " + eeprom + "\n",
                    System.Drawing.Color.LightBlue);

                serialPorts.setCaptureStream(false);
                flushRxBuffer();
                commandInProgress = commands.none;
                TsbConnectedEventHandler(this, true);
            }
        }



        private void readFlash()
        {
            // 1. Read incoming data until CF ('!') count is higher than readFlashPageIndex.
            // 2. Create a new byte array from the string rxBuffer
            // 3. Send another read flash command.
            // 4. When readFlashPageIndex is exceeded...

            //if(rxBuffer.Length < pageSize)
            if(rxBuffer.Length < 64)
            {
                serialPorts.WriteData("!");
                //execute(commands.confirm, 500);
                return;
            } else if (readFlashPageIndex < numberOfPages)
            {
                Console.WriteLine(numberOfPages);
                byte[] page = Encoding.Default.GetBytes(rxBuffer.Substring(0, 63));
                if (rxBuffer.Length > 63)
                {
                    rxBuffer = rxBuffer.Substring(64, (rxBuffer.Length - 64));
                    readFlashBuffer.Concat(page);
                }

                if (progressBar.InvokeRequired)
                {
                    
                }

                //readFlashBuffer = encoding.default.getbytes(rxbuffer);
                //setMainDisplayTextSafely("\npage #: " + readFlashPageIndex + "\n", System.Drawing.Color.AliceBlue);
                //setMainDisplayTextSafely(rxBuffer + "\n", System.Drawing.Color.LimeGreen);
                flushRxBuffer();

                readFlashPageIndex++;
                serialPorts.WriteData("!");
                //execute(commands.confirm, 500);
            }
        
            else
            {
                setMainDisplayTextSafely("Total bytes of flash read: " + readFlashBuffer.Length, System.Drawing.Color.Red);
                readFlashPageIndex = 0;
                displayFlashReadBuffer();
            }
        }


        public void setTsbConnectionSafely(bool tsbConnection)
        {
            if (mainDisplay.InvokeRequired)
            {
                TsbConnectedEventHandler.Invoke(this, tsbConnection);
                return;
            }
            TsbConnectedEventHandler.Invoke(this, tsbConnection);
        }

        private void setMainDisplayTextSafely(string text, System.Drawing.Color color)
        {
            if (mainDisplay.InvokeRequired)
            {
                mainDisplay.Invoke(new Action<string, System.Drawing.Color>(setMainDisplayTextSafely), new object[] { text, color });
                return;
            }
            mainDisplay.AppendText(text, color);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }

        public void flushRxBuffer()
        {
            rxBuffer = "";
        }

        public void displayFlashReadBuffer()
        {
            if (mainDisplay.InvokeRequired)
            {
                mainDisplay.Invoke(new Action(displayFlashReadBuffer), new object[] { });
                return;
            }

            int index = 0;

            while(index < rxBuffer.Length)
            {
                for(int i = 0; i < 8; i++)
                {
                    mainDisplay.Text += (Encoding.UTF8.GetString(readFlashBuffer, 0, index));
                    index += 8;
                }

            }
        }
    }
}
