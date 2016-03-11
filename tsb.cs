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

                mainDisplay.AppendText(
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
            // 4. Write monoline string to file.
            // 5. Print out formatted string to display.

            string localStringBuffer = "";
            int pageIndex = 0;

            // Start this thing
            serialPorts.WriteData(commandsAsStrings[(int)commands.readFlash]);
            System.Threading.Thread.Sleep(50);
            
            // Get all bytes in a page.
            while (pageIndex < numberOfPages)
            {
                serialPorts.WriteData(commandsAsStrings[(int)commands.confirm]);
                System.Threading.Thread.Sleep(150);
                localStringBuffer += serialPorts.ReadExistingAsString();
                Console.WriteLine("Chars: {0}  pageIndex: {1}  numberOfPages: {2}", localStringBuffer.Length, pageIndex, numberOfPages);
                pageIndex++;
            }

            string fileName = "Lumi_Up_output.hex";
            writeByteArrayToFile(fileName, localStringBuffer);
            int[] flashReadByteArray = getIntArrayFromString(localStringBuffer);
            parseAndPrintRawRead(flashReadByteArray);
          
        }

        public int[] getIntArrayFromString(string data)
        {
            // 1. Loop through each character in string 
            // 2. Assign each char to place in int array.
            // 3. Return int array.

            int[] dataIntArray = new int[data.Length];
            for(int i = 0; i < data.Length; i++)
            {
                dataIntArray[i] = data[i];
            }

            return dataIntArray;
        }

        public void parseAndPrintRawRead(int[] rawFlashRead)
        {   
            // 1. Get number of pages reads.
            // 2. Define page array, lineBuffer, lineSize, location.
            // 3. Loop through each page...
            // 4. Loop through page depth (pageDepth * lineSize = page)
            // 5. Loop through line
            // 6. Write assemble a HEX string a byte at a time.
            // 7. Write the assembled HEX string to display
            // 8. Clear line buffer.
            // 9. Repeat 1-8 until end of int array.

            int numberOfPagesRead = (rawFlashRead.Length / pageSize);
            int[] pageByteArray = new int[pageSize];
            const int pageDepth = 8;

            string lineBuffer = "";

            for(int i = 0; i < numberOfPagesRead; i++)
            {
                for(int j = 0; j < pageDepth; j++)
                {
                    int location = ((i * pageSize) + (j * pageDepth));
                    mainDisplay.AppendText(location.ToString("X4") + ": ", System.Drawing.Color.Yellow);
                    for(int k = 0; k < 16; k++)
                    {
                        lineBuffer += rawFlashRead[location + k].ToString("X2");
                    }                  
                    mainDisplay.AppendText(lineBuffer.ToString() + "\n", System.Drawing.Color.LimeGreen);
                    lineBuffer = "";
                }
                mainDisplay.AppendText("\n\tPage #: "+i + "\n\n", System.Drawing.Color.Yellow);
            }
        }

        public static void writeByteArrayToFile(string path, string data)
        {
            // 1. Loop through each character in string.
            // 2. Convert to int.
            // 3. Convert back to a string in HEX form.
            // 4. Append the string to master string.
            // 5. Write master string to file as monoline.

            string dataAsString = "";
            int x = 0;
            for(int i = 0; i < data.Length; i++)
            {
                x = data[i];
                dataAsString += (x).ToString("X2");
            }
            System.IO.File.WriteAllText(path, dataAsString);
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

    } // End of Class
} // End of Namespace
