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
        public delegate void TsbConnected(bool tsbConnectionStatus);
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

        string rxBufferAsString;

        commands commandInProgress = new commands();

        SerialPortsExtended serialPorts;
        RichTextBox mainDisplay;
        ProgressBar progressBar;

        public void init(SerialPortsExtended serialPortMain, RichTextBox mainDisplayMain, ProgressBar mainProgressBar)
        {
            serialPorts = serialPortMain;
            mainDisplay = mainDisplayMain;
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

        public void updateActionInProgress(commands commandNumber)
        {
            commandInProgress = commandNumber;
        }

        public void helloProcessing()
        {
            // 1. Try handshake ("@@@") three times; or continue if successful.
            // 2. Check if reply seems valid(ish).
            // 3. Chop up the reply into useful device data.
            // 4. Save the device data for later.
            // 5. If not reply, let the user know it was a fail.

            int[] firmwareDatePieces = { 0x00, 0x00 };
            int firmwareStatus = 0x00;
            int[] signatureBytes = { 0x00, 0x00, 0x00 };
            int pagesizeInWords = 0x00;
            int[] freeFlash = { 0x00, 0x00 };
            int[] eepromSize = { 0x00, 0x00 };

            for(int i = 0; i < 3; i++)
            {
                serialPorts.WriteData("@@@");
                System.Threading.Thread.Sleep(50);
                rxBuffer = serialPorts.ReadExistingAsString();
                if(rxBuffer.Length > 0) { break; }
            }

            // ATtiny have all lower case, ATMega have upper case.  Not sure if it's expected.
            if (rxBuffer.Contains("tsb") || rxBuffer.Contains("TSB") && rxBuffer.Length == 17)
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
                //numberOfPages = 32768 / pageSize;
                numberOfPages = 16;
                // Get flash size.
                flashSize = ((freeFlash[1] << 8) | freeFlash[0])*2;
                string flashLeft = flashSize.ToString();

                // Get EEPROM size.
                fullEepromSize = ((eepromSize[1] << 8) | eepromSize[0])+1;
                string eeprom = fullEepromSize.ToString();

                setMainDisplayTextSafely(
                    "Firmware Date:" + firmwareDateString
                    + "\nStatus:       " + firmwareStatus.ToString("X2")
                    + "\nSignature:    " + deviceSignature
                    + "\nPage Size:    " + pageSizeString
                    + "\nFlash Free:   " + flashLeft
                    + "\nEEPROM size:  " + eeprom + "\n",
                    System.Drawing.Color.LightBlue);

                commandInProgress = commands.none;
                setTsbConnectionSafely(true);
            } else
            {
                mainDisplay.AppendText("Could not handshake with TSB. Please reset and try again.\n", System.Drawing.Color.Crimson);
            }
        }

        public void readFlash()
        {
            
            // 1. Write read Flash command.
            // 2. Get first page by sending confirmation ("!").
            // 3. Continue to get data until buffer is full.

            string localStringBuffer = "";

            // Start this thing
            serialPorts.WriteData(commandsAsStrings[(int)commands.readFlash]);
            System.Threading.Thread.Sleep(50);
            
            int pageIndex = 0;
            // Get all bytes in a page.
            while (pageIndex < numberOfPages)
            {
                serialPorts.WriteData(commandsAsStrings[(int)commands.confirm]);
                System.Threading.Thread.Sleep(150);
                localStringBuffer += serialPorts.ReadExistingAsString();
                Console.WriteLine("Chars: {0}  pageIndex: {1}  numberOfPages: {2}", localStringBuffer.Length, pageIndex, numberOfPages);
                pageIndex++;
            }

            //Console.WriteLine(localStringBuffer.Length);
            //parseRawRead(localStringBuffer);
            //string flashReadAsHexString = serialPorts.convertHexStringToASCIIHex(localStringBuffer);
            byte[] flashReadByteArray = convertFlashReadStringToByteArray(localStringBuffer);
            parseAndPrintRawRead(flashReadByteArray);
            //mainDisplay.AppendText(serialPorts.convertASCIIStringToHexString(GetString(smallBit)), System.Drawing.Color.LimeGreen);
            Console.WriteLine(flashReadByteArray.Length);
            
        }


        public void setTsbConnectionSafely(bool tsbConnection)
        {
            if (mainDisplay.InvokeRequired)
            {
                TsbConnectedEventHandler.Invoke(tsbConnection);
                return;
            }
            TsbConnectedEventHandler.Invoke(tsbConnection);
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


            // 
            mainDisplay.AppendText(rxBuffer);
        }

        public string[] parseRawRead(string rawFlashRead)
        {
            int numberOfPagesRead = (rawFlashRead.Length / pageSize);
            string[] processedFlashRead = new string[numberOfPagesRead*pageSize];

            int pageIndex = 0;

            while(pageIndex < numberOfPagesRead)
            {
                processedFlashRead[pageIndex] = rawFlashRead.Substring(pageIndex * pageSize, pageSize);
                pageIndex++;            
            }

            pageIndex = 0;
            while(pageIndex < numberOfPagesRead)
            {
                mainDisplay.AppendText(processedFlashRead[pageIndex]+"\n", System.Drawing.Color.LimeGreen);
            }

            return processedFlashRead;
        }

        public void parseAndPrintRawRead(byte[] rawFlashRead)
        {
            string fileName = "Lumi_Up_output.hex";
            
            ByteArrayToFile(fileName, rawFlashRead);
            int numberOfPagesRead = (rawFlashRead.Length / pageSize);
            //byte[,] processedFlashRead = new byte[numberOfPagesRead, pageSize];
            byte[] pageByteArray = new byte[pageSize];
            const int lineSize = 8;

            for(int i = 0; i < numberOfPagesRead; i++)
            {
                for(int j = 0; j < lineSize+1; j++)
                {
                    byte[] lineByteArray = new byte[lineSize];
                    int chunkSize = ((i * pageSize) + (j * lineSize));
                    //pageByteArray = rawFlashRead.Skip(i * pageSize + j * lineSize/2).Take(j/2).ToArray();
                    Buffer.BlockCopy(rawFlashRead, chunkSize, lineByteArray, 0, j / sizeof(UInt32));
                    mainDisplay.AppendText(chunkSize.ToString("X6")+": ", System.Drawing.Color.Yellow);
                    mainDisplay.AppendText(tsb.ByteArrayToString(lineByteArray) + "\n", System.Drawing.Color.LimeGreen);
                }
                mainDisplay.AppendText("\n\t\tPage #: "+i + "\n\n", System.Drawing.Color.Yellow);
            }
            //Array.Copy(rawFlashRead, );
           
        }

        public byte[] convertFlashReadStringToByteArray(string rawFlashReadString)
        {
            return GetBytes(rawFlashReadString);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(byte)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(byte)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                

                // close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            hex = hex.Replace("0x0", "0x00");
            return hex.Replace("-", "");
        }

    } // End of Class
} // End of Namespace
