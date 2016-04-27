using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Threading;


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

        public enum displayFlash
        {
            asIntelHexFile = 0,
            dataOnly = 1,
            addressAndData = 2,
            none = 3
        }
        #endregion enumerations

        #region properties

        public delegate void TsbConnected(bool tsbConnectionStatus);
        public event TsbConnected TsbConnectedEventHandler;

        const int commandAttempts = 3;

        private string rxBuffer = "";

        string filePath = "";
        string fileName = "";

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
        displayFlash displayFlashType = displayFlash.asIntelHexFile;

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

        public void scrollToBottomOfTerminal()
        {
            mainDisplay.SelectionStart = mainDisplay.Text.Length;
            mainDisplay.ScrollToCaret();
        }

        public void setFilePath(string path)
        {
            filePath = path;
        }

        public void setFileName(string name)
        {
            fileName = name;
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
                Thread.Sleep(50);
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

                firmwareDateString = (month + " " + day + " " + "20" + year);

                // Atmel device signature.
                deviceSignature = signatureBytes[0].ToString("X2") + " " + signatureBytes[1].ToString("X2") + " " + signatureBytes[2].ToString("X2");
                Int32 combinedDeviceSignature = (Int32)(((signatureBytes[0] << 16) | signatureBytes[1] << 8) | signatureBytes[2]);
                deviceSignatureValue = (DEVICE_SIGNATURE)combinedDeviceSignature;

                // The size is in words, make it bytes.
                pageSize = (pagesizeInWords * 2);
                string pageSizeString = (pagesizeInWords * 2).ToString();

                // Get flash size.
                flashSize = ((freeFlash[1] << 8) | freeFlash[0])*2;
                string flashLeft = flashSize.ToString();

                // REPLACE WITH DEVICE INFO
                numberOfPages = flashSize / pageSize;
                //numberOfPages = 16;

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
                    //localStringBuffer += getPage();
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
            int pageDepth = (pageSize/16);
            const int pageWidth = 16;
            string lineBuffer = "";

            mainDisplay.AppendText("\nFlash readout for " + deviceSignatureValue + "\n\n", System.Drawing.Color.White);

            for(int i = 0; i < numberOfPagesRead; i++)
            {
                if (displayFlashType != displayFlash.none)
                { mainDisplay.AppendText("\n\t Page #:" + i + "\n", System.Drawing.Color.Yellow); }
                for (int j = 0; j < pageDepth; j++)
                {
                    int location = ((i * pageSize) + (j * pageWidth));
                    for(int k = 0; k < pageWidth; k++)
                    {
                        lineBuffer += rawFlashRead[location + k].ToString("X2");
                    }
                    outputFile.WriteLine(getIntelFileHexString(location.ToString("X4"), lineBuffer.ToString()), true);
                    lineBuffer = "";
                }
            }

            scrollToBottomOfTerminal();
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
            string checkSumString = checkSum.ToString("X2");
            intelHexFileLine += checkSumString;

            switch (displayFlashType)
            {
                case displayFlash.asIntelHexFile:
                    mainDisplay.AppendText(":", Color.Yellow);                  // Start code
                    mainDisplay.AppendText(byteCount, Color.Green);             // Byte count
                    mainDisplay.AppendText(address, Color.Purple);              // Address
                    mainDisplay.AppendText(recordType, Color.Pink);             // Record type.
                    mainDisplay.AppendText(data, Color.CadetBlue);              // Data
                    mainDisplay.AppendText(checkSumString + "\n", Color.Gray);  // Checksum
                    break;
                case displayFlash.none:
                    // No display.
                    break;
                case displayFlash.addressAndData:
                    mainDisplay.AppendText(address + ": ", Color.Yellow);
                    mainDisplay.AppendText(data + "\n", Color.LawnGreen);
                    break;
            }

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

        public void uploadFileToChip()
        {
            // 1. Open Intel HEX file.
            // 2. Read file into byte array.
            // 3. Print out the data.
            // 4. Write data to flash.

            intelHexFile intelHexFileHandler = new intelHexFile();
            byte[] bytesFromFile = intelHexFileHandler.intelHexFileToArray(filePath, pageSize);

            int[] intsFromFile = new int[bytesFromFile.Length];
            for(int i = 0; i < bytesFromFile.Length; i++)
            {
                intsFromFile[i] = bytesFromFile[i];
            }
            parseAndPrintRawRead(intsFromFile);
            writeDataToFlash(intsFromFile);

        }

        public bool writeDataToFlash(int[] dataToWrite)
        {
            // 1. Send Flash write character.
            // 2. Get response and check for RQ ('?').
            // 3. Write page of data.
            // 4. Wait and check for RQ ('?') or CF ('!').
            // 5. Repeat steps 3-4 until last page.
            // 6. Write RQ ('?').
            // 7. Wait and check for CF ('!').
            // 8. Return true if process successful.

            mainDisplay.AppendText("\n\n\nWrite in progress: \nPlease do not disconnect device or exit the application.\n", Color.Yellow);
            scrollToBottomOfTerminal();



            int pagesToWrite = dataToWrite.Length / pageSize;

            serialPorts.WriteData(commandsAsStrings[(int)commands.writeFlash]);
            Thread.Sleep(1200);

            string readyForData = serialPorts.ReadExistingAsString();

            if (readyForData.Contains("?"))
            {
                for(int i = 0; i < pagesToWrite; i++)
                {
                    // From byte array to string
                    string stringToWrite = getStringFromIntBytes(dataToWrite.Skip(i * pageSize).Take(pageSize).ToArray());
                    serialPorts.WriteData(commandsAsStrings[(int)commands.confirm]);
                    Thread.Sleep(100);
                    serialPorts.WriteData(stringToWrite);
                    Thread.Sleep(500);
                    readyForData = serialPorts.ReadExistingAsString();
                    if (readyForData.Contains("!"))
                    {
                        mainDisplay.AppendText("ERROR writing Page #" + i + "\n", Color.Red);
                        return false;
                    }
                    mainDisplay.AppendText("Page #" + i + " ", Color.Yellow); 
                    mainDisplay.AppendText("OK.\n", Color.LawnGreen);
                    scrollToBottomOfTerminal();
                }
                serialPorts.WriteData(commandsAsStrings[(int)commands.request]);
                Thread.Sleep(100);
                readyForData = serialPorts.ReadExistingAsString();
                if (readyForData.Contains("!"))
                {
                    scrollToBottomOfTerminal();
                    mainDisplay.AppendText("\nThe file ", Color.LawnGreen);
                    mainDisplay.AppendText(fileName, Color.Yellow);
                    mainDisplay.AppendText(" was written succesfully!", Color.LawnGreen);
                    scrollToBottomOfTerminal();
                    return true;
                }

            }

            return true;
        }

        public string getStringFromIntBytes(int[] bytes)
        {

            string str = "";
            for(int i = 0; i < bytes.Length; i++)
            {
                str += Convert.ToChar(bytes[i]);
            }

            return str;
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

    } // End TSB Class

    class intelHexFile
    {
        public byte[] intelHexFileToArray(string fileName, int pageSize)
        {
            // 1. Open file for file info.
            // 2. Get number of lines in file.
            // 3. Get number of bytes in file.
            // 3. Close and reopen the file for reading.
            // 4. Get the number of bytes needed so all pages to write are full.
            // 5. Get a byte array sized for number of needed pages (pageSize * neededPages).
            // 6. Open file for reading.
            // 7. Loop through lines in file, filling line buffer.
            // 8. If a line of data was found...
            // 9. Get the beginning address of the line.
            // 10. Loop through char in line buffer.
            // 11. If number of full lines is less than total bytes, then fill grab data from line.
            // 12. Otherwise, pad line in the byte array with 0xFF until end of line and get position.
            // 13. Find the difference between position and end of full page.
            // 14. If page is not filled, fill with 0xFF.
            // 15. Return the byte array filled with extracted data.

            if (File.Exists(fileName))
            {
                // Peek.
                StreamReader fileToGetNumberOfLines = new StreamReader(fileName);
                Tuple<int, int> numberOfBytesAndLines = linesInFile(fileToGetNumberOfLines);
                int numberOfBytesInFile = numberOfBytesAndLines.Item1;
                int numberOfLinesInFile = numberOfBytesAndLines.Item2;
                fileToGetNumberOfLines.Close();

                // Buffer.
                int neededPages = getNeededPagePadding(numberOfBytesInFile, pageSize);
                byte[] dataFromFile = new byte[neededPages * pageSize];

                // Read.
                StreamReader fileStream = new StreamReader(fileName);

                Tuple<byte[], Int16> lineOfDataAndAddress = new Tuple<byte[], Int16>(null, 0);
                int indexOfLastDataLine = 0;



                // Iterate
                for (int lineIndex = 0; lineIndex < numberOfLinesInFile; lineIndex++)
                {
                    lineOfDataAndAddress = readLineFromHexFile(fileStream);
                    if (lineOfDataAndAddress.Item1 != null)
                    {
                        Int16 startAddressOfLine = lineOfDataAndAddress.Item2;
                        for (int byteIndex = 0; byteIndex < lineOfDataAndAddress.Item1.Length; byteIndex++)
                        {
                            if ((byteIndex + lineIndex * 16) < numberOfBytesInFile)
                            { dataFromFile[byteIndex + startAddressOfLine] = lineOfDataAndAddress.Item1[byteIndex]; }
                            else { dataFromFile[byteIndex + startAddressOfLine] = 0xFF;
                                indexOfLastDataLine = (byteIndex + startAddressOfLine);
                            }
                        }
                    }
                }

                // Pad page.
                int blankBytesToFill = (neededPages * pageSize) - indexOfLastDataLine;
                for (int i = 0; i < blankBytesToFill; i++)
                {
                    dataFromFile[i + indexOfLastDataLine] = 0xFF;
                }
                return dataFromFile;
            } else
            {
                Console.WriteLine("Error");
                return null;
            }

            return null;
        }

        public Tuple<byte[], Int16> readLineFromHexFile(StreamReader fileStream)
        {
            // 1. Get a line from file.
            // 2. Remove the start character
            // 3. Get byte count and convert to byte, then to int.
            // 4. Get both address bytes, convert to Int16.
            // 5. Get data type, return null if not data.
            // 6. Loop through the data extracting a line of bytes.
            //    UNIMP: Checksum
            // 7. Return line of bytes and Int16 address a tuple.

            int parseLineIndex = 0;

            //To hold file hex values.
            int dataByteCount = 0;
            byte data_address1 = 0x00;
            byte data_address2 = 0x00;
            UInt16 fullDataAddress = 0x00;
            Int16 fullAddressAsInt = 0;
            byte data_record_type = 0x00;
            byte data_check_sum = 0x00;

            string line = "";
            line = fileStream.ReadLine();

            // Skip start code.
            parseLineIndex++;

            // Get byte count and convert to int.
            string byteCountStrBfr = line.Substring(parseLineIndex, 2);
            dataByteCount = getByteFrom2HexChar(byteCountStrBfr);
            parseLineIndex += 2;

            // Create the byte array for the read about to be read.
            byte[] bytesFromLine = new byte[dataByteCount];

            // Get data address and convert to memory address.
            string byteDataAddressStrBfr = line.Substring(parseLineIndex, 2);
            data_address1 = getByteFrom2HexChar(byteDataAddressStrBfr);
            parseLineIndex += 2;

            byteDataAddressStrBfr = line.Substring(parseLineIndex, 2);
            data_address2 = getByteFrom2HexChar(byteDataAddressStrBfr);
            parseLineIndex += 2;

            fullDataAddress = (UInt16)((data_address1 << 8) | data_address2);
            fullAddressAsInt = (Int16)fullDataAddress;

            // Data type.
            string dataRecordTypeStrBfr = line.Substring(parseLineIndex, 2);
            data_record_type = getByteFrom2HexChar(dataRecordTypeStrBfr);
            parseLineIndex += 2;

            // If not data, don't bother and return false.
            if (data_record_type != 0x00) { return new Tuple<byte[], Int16>(null , 0); }

            // Get the data.
            int dataIndex = 0;
            string dataStrBfr = "";
            while (dataIndex < dataByteCount) {
                dataStrBfr = line.Substring(parseLineIndex, 2);
                parseLineIndex += 2;
                bytesFromLine[dataIndex] = getByteFrom2HexChar(dataStrBfr);
                dataIndex++;
            }

            // Get checksum
            // IF CHECKSUM NEEDED, GET LATER.

            /*Console.WriteLine(
               "\nByte Count: " + dataByteCount.ToString("X2") +
               "  Full address: "+ fullAddressAsInt.ToString("X4") +
               "  Record type: " + data_record_type.ToString("X2") +
               "  Data: "
               );
               for (int i = 0; i < bytesFromLine.Length; i++)
               {
                   Console.Write(bytesFromLine[i].ToString("X2"));
               }*/

            return new Tuple<byte[],Int16>(bytesFromLine, fullAddressAsInt);
        }

        private Tuple<int, int> linesInFile(StreamReader file)
        {
            // 1. Read initial line.
            // 2. If line is null return empty tuple.
            // 3. loop through lines
            // 4. If the line is data
            // 5. Get how many bytes of data and add it to a running count.
            // 6. Increment line counter
            // 7. Read next line.
            // 8. Continue until EOF.
            // 9. Return bytes of data and number of lines in file.

            string line = "";
            int lineCount = 0;
            int dataBytes = 0;
            
            line = file.ReadLine();
            while(line != null)
            {   if(line.Substring(7, 2) == "00")
                {
                    dataBytes += getByteFrom2HexChar(line.Substring(1, 2));
                    lineCount++;
                }
                line = file.ReadLine();
            }
            return new Tuple<int, int>(dataBytes, lineCount);
        }

        public byte getByteFrom2HexChar(string twoHexChars)
        {
            return (byte)Convert.ToInt32(twoHexChars, 16);
        }

        public int getNeededPagePadding(int byteCount, int pageSize)
        {
            // 1. Find out if pageSize divides byteCount with no remainder.  If so, return 0.
            // 2. Else, get the number of pages with padding.
            // 3. Get total bytes with padding.
            // 4. Find number of padding bytes needed.
            // 5. Return how many padding bytes are required to make the last page full.

            if (byteCount % pageSize == 0)
            {
                return 0;
            }
            else
            {
                return ((int)Math.Floor((float)byteCount/(float)pageSize)+1);
            }
            return 0;
        }


    }// End Intel Hex File Class

} // End of Namespace
