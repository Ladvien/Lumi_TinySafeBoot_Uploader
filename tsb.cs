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
        #region devices
        enum DEVICE_SIGNATURE
        {
            ATTINY_13A = 0x1E9007,
            ATTINY_13 = 0x1E9007,
            ATTINY_1634 = 0x1E9412,
            ATTINY_167 = 0x1E9487,
            ATTINY_2313A = 0x1E910A,
            ATTINY_2313 = 0x1E910A,
            ATTINY_24A = 0x1E910B,
            ATTINY_24 = 0x1E910B,
            ATTINY_25 = 0x1E910B,
            ATTINY_261A = 0x1E910C,
            ATTINY_261 = 0x1E910C,
            ATTINY_4313 = 0x1E920D,
            ATTINY_44A = 0x1E9207,
            ATTINY_44 = 0x1E9207,
            ATTINY_441 = 0x1E9215,
            ATTINY_45 = 0x1E9206,
            ATTINY_461A = 0x1E9208,
            ATTINY_461 = 0x1E9208,
            ATTINY_48 = 0x1E9209,
            ATTINY_84A = 0x1E930C,
            ATTINY_84 = 0x1E930C,
            ATTINY_841 = 0x1E9315,
            ATTINY_85 = 0x1E930B,
            ATTINY_861A = 0x1E930D,
            ATTINY_861 = 0x1E930D,
            ATTINY_87 = 0x1E9387,
            ATTINY_88 = 0x1E9311,
            ATMEGA_162 = 0x1E9403,
            ATMEGA_164A = 0x1E940F,
            ATMEGA_164PA = 0x1E940A,
            ATMEGA_164P = 0x1E940A,
            ATMEGA_165A = 0x1E9410,
            ATMEGA_165PA = 0x1E9407,
            ATMEGA_165P = 0x1E9407,
            ATMEGA_168A = 0x1E9406,
            ATMEGA_168 = 0x1E9406,
            ATMEGA_168PA = 0x1E940B,
            ATMEGA_168P = 0x1E940B,
            ATMEGA_169A = 0x1E9411,
            ATMEGA_169PA = 0x1E9405,
            ATMEGA_169P = 0x1E9405,
            ATMEGA_16A = 0x1E9403,
            ATMEGA_16 = 0x1E9403,
            ATMEGA_16HVA = 0x1E940C,
            ATMEGA_16HVB = 0x1E940D,
            ATMEGA_16ATMEGA_1 = 0x1E9484,
            ATMEGA_16U2 = 0x1E9489,
            ATMEGA_16U4 = 0x1E9488,
            ATMEGA_324A = 0x1E9515,
            ATMEGA_324PA = 0x1E9511,
            ATMEGA_324P = 0x1E9508,
            ATMEGA_3250A = 0x1E950E,
            ATMEGA_3250 = 0x1E9506,
            ATMEGA_3250PA = 0x1E950E,
            ATMEGA_3250P = 0x1E950E,
            ATMEGA_325A = 0x1E9505,
            ATMEGA_325 = 0x1E9505,
            ATMEGA_325PA = 0x1E9505,
            ATMEGA_325P = 0x1E950D,
            ATMEGA_328 = 0x1E9514,
            ATMEGA_328P = 0x1E950F,
            ATMEGA_3290A = 0x1E950C,
            ATMEGA_3290 = 0x1E9504,
            ATMEGA_3290PA = 0x1E950C,
            ATMEGA_3290P = 0x1E950C,
            ATMEGA_329A = 0x1E9503,
            ATMEGA_329 = 0x1E9503,
            ATMEGA_329PA = 0x1E950B,
            ATMEGA_329P = 0x1E950B,
            ATMEGA_32A = 0x1E9502,
            ATMEGA_32C1 = 0x1E9586,
            ATMEGA_32 = 0x1E9502,
            ATMEGA_32HVB = 0x1E9510,
            ATMEGA_32ATMEGA_1 = 0x1E9584,
            ATMEGA_32U2 = 0x1E958A,
            ATMEGA_32U4 = 0x1E9587,
            ATMEGA_406 = 0x1E9507,
            ATMEGA_48A = 0x1E9205,
            ATMEGA_48 = 0x1E9205,
            ATMEGA_48PA = 0x1E920A,
            ATMEGA_48P = 0x1E920A,
            ATMEGA_640 = 0x1E9608,
            ATMEGA_644A = 0x1E9609,
            ATMEGA_644 = 0x1E9609,
            ATMEGA_644PA = 0x1E960A,
            ATMEGA_644P = 0x1E960A
        }
        #endregion devices

        #region enumerations
        // TSB Command Variables
        public enum commands : int
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
        #endregion enumerations

        #region properties

        public delegate void TsbConnected(bool tsbConnectionStatus);
        public event TsbConnected TsbConnectedEventHandler;

        const int commandAttempts = 3;

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

        DEVICE_SIGNATURE deviceSignatureValue = new DEVICE_SIGNATURE();
        commands commandInProgress = new commands();

        SerialPortsExtended serialPorts;
        RichTextBox mainDisplay;
        ProgressBar progressBar;

        #endregion properties






        public void init(SerialPortsExtended serialPortMain, RichTextBox mainDisplayMain, ProgressBar mainProgressBar)
        {
            serialPorts = serialPortMain;
            mainDisplay = mainDisplayMain;
            progressBar = mainProgressBar;
        }



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
                Int32 combinedDeviceSignature = (Int32)(((signatureBytes[0] << 16) | signatureBytes[1] << 8) | signatureBytes[2]);
                deviceSignatureValue = (DEVICE_SIGNATURE)combinedDeviceSignature;

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
                         deviceSignatureValue.ToString()
                    + "\nFirmware Date:  " + firmwareDateString
                    + "\nStatus:         " + firmwareStatus.ToString("X2")
                    + "\nSignature:      " + deviceSignature
                    + "\nPage Size:      " + pageSizeString
                    + "\nFlash Free:     " + flashLeft
                    + "\nEEPROM size:    " + eeprom + "\n",
                    System.Drawing.Color.White);

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
            // 5. Check the dogear of the page (bottom  corner bytes)
            //    if last two bytes are FF FF, then break, as end of Flash.
            // 5. Print out formatted string to display.

            string localStringBuffer = "";
            int pageIndex = 0;

            // Start this thing
            serialPorts.WriteData(commandsAsStrings[(int)commands.readFlash]);
            System.Threading.Thread.Sleep(50);
            
            // Get all bytes in a page.
            while (pageIndex < numberOfPages)
            {
                localStringBuffer += getPage();
                Console.WriteLine("Chars: {0}  pageIndex: {1}  numberOfPages: {2}", localStringBuffer.Length, pageIndex, numberOfPages);
                pageIndex++;
                if (localStringBuffer[localStringBuffer.Length - 1] == 0xFF &&
                    localStringBuffer[localStringBuffer.Length - 1] == 0xFF)
                {
                    localStringBuffer += getPage();
                    break;
                }
            }

            int[] flashReadByteArray = getIntArrayFromString(localStringBuffer);
            parseAndPrintRawRead(flashReadByteArray);
          
        }

        public string getPage()
        {
            serialPorts.WriteData(commandsAsStrings[(int)commands.confirm]);
            System.Threading.Thread.Sleep(150);
            return serialPorts.ReadExistingAsString();
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
            // 0. Greeting
            // 1. Get number of pages reads.
            // 2. Define page array, lineBuffer, lineSize, location.
            //    and get doc path and stream.
            // 3. Loop through each page...
            // 4. Loop through page depth (pageDepth * lineSize = page)
            // 5. Loop through line
            // 6. Write assemble a HEX string a byte at a time.
            // 7. Write the assembled HEX string to display and file.
            // 8. Clear line buffer.
            // 9. Repeat 1-8 until end of int array.

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.IO.StreamWriter outputFile = new System.IO.StreamWriter(mydocpath + @"\Flash_Read_Output.hex");
            
            int numberOfPagesRead = (rawFlashRead.Length / pageSize);
            int[] pageByteArray = new int[pageSize];
            const int pageDepth = 8;
            const int pageWidth = 16;
            string lineBuffer = "";

            mainDisplay.AppendText("\nFlash readout for DEVICE TYPE\n\n", System.Drawing.Color.White);

            for(int i = 0; i < numberOfPagesRead; i++)
            {
                mainDisplay.AppendText("\n\t Page #:" + i + "\n", System.Drawing.Color.Yellow);
                for (int j = 0; j < pageDepth; j++)
                {
                    int location = ((i * pageSize) + (j * pageWidth));
                    mainDisplay.AppendText(location.ToString("X4") + ": ", System.Drawing.Color.Yellow);
                    for(int k = 0; k < pageWidth; k++)
                    {
                        lineBuffer += rawFlashRead[location + k].ToString("X2");
                        Console.WriteLine(lineBuffer);
                    }
                    outputFile.WriteLine(getIntelFileHexString(location.ToString("X4"), lineBuffer.ToString()), true);
                    mainDisplay.AppendText(lineBuffer.ToString() + "\n", System.Drawing.Color.LawnGreen);
                    lineBuffer = "";
                }
            }
            outputFile.Close();
        }

        public string getIntelFileHexString(string address, string data)
        {
            // 1. Get start code.
            // 2. Get and set byte count string.
            // 3. Set address string.
            // 4. Get record type.
            // 5. Set data
            // 6. Get and set checksum.
            // 7. Add newline at end.
            // 8. Return completed Intel HEX file line as string.

            string startCode = ":";
            string byteCount = (data.Length / 2).ToString("X2");
            // Address passed in.
            string recordType = "00"; // 00 = Data, 01 = EOF, 02 = Ext. Segment. Addr., 03 = Start Lin. Addr, 04 = Ext. Linear Addr., 05 = Start Linear Addr.
            // Checksum passed in

            string intelHexFileLine = startCode + byteCount + address + recordType + data;

            int checkSum = getCheckSumFromLine(intelHexFileLine);

            intelHexFileLine += checkSum.ToString("X2");

            return intelHexFileLine;
        }

        public int getCheckSumFromLine(string line)
        {
            // 1. Remove start character.
            // 2. Split the line into array of char pairs (e.g., "FFAC" -> { "FF", "AC" })
            // 3. Convert HEX string pairs to Int32, then cast as byte.
            // 4. Sum all bytes for the line.
            // 5. Take the two's complement.
            // 6. Return checksum.

            byte checkSum = 0;
            int halfLength = (line.Length / 2);
            int[] returnBuffer = new int[halfLength];
            string[] splitByTwoData = new string[halfLength];

            line = line.Replace(":", "");
            for(int i = 0; i < halfLength; i++ )
            {
                splitByTwoData[i] = line.Substring((i * 2),2);
            }
            for(int i = 0; i < halfLength; i++)
            {
                checkSum += (byte)Convert.ToInt32(splitByTwoData[i], 16);
            }
            checkSum = (byte)(~checkSum + 1);


            return checkSum;
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

        private DEVICE_SIGNATURE getDeviceInfo(UInt32 rawDeviceSignature)
        {
            DEVICE_SIGNATURE identifiedDevice = new DEVICE_SIGNATURE();

            return identifiedDevice;
        }
    } // End of Class
} // End of Namespace
