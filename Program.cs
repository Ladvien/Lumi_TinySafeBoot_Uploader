using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using HM_1X_Aid_v01;
using System.Globalization;


/// <summary>
/// Serial terminal template for Windows.
/// Icon provided by Shlyapnikova (https://www.iconfinder.com/iconsets/Icons_Pack___Web_Cartoon___by_shlyapnikova)
/// 
/// Code written by C. Thomas Brittain -- aka, Ladvien
/// Copyright 2016
/// 
/// </summary>



namespace HM_1X_Aid_v01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDisplay());        
        }        
        
    }
}

class SerialPortsExtended: SerialPort
{

    SerialPort ComPort = new SerialPort();

    enum charsAfterRXTX : int { None = 0, LineFeed, CarriageReturn, CarriageReturnLineFeed, LineFeedCarriageReturn };
    
    // Open port flag.
    private bool portOpen = false;
    bool dataHandlerAttached = false;

    // HM-1X //////////////////////
    private string captureBuffer = "";
    private bool captureStream = false;

    // Response timeout
    int responseTimeout = 300;

    // HM-1X END //////////////////

    delegate void HM1XVariableUpdate(object sender, object originator, object value);

    // List containing all discovered COMs.
    List<String> portList = new List<String>();

    // Port setup.
    int readTimeout = 0;
    int writeTimeout = 0;

    // Callback and event handler for passing serial data to the main object.
    public delegate void DataReceivedCallback(object sender, string data);
    public event DataReceivedCallback DataReceivedEventHandler;

    // Callback and event handler for passing serial data to the main object.
    public delegate void HM1Xupdated(object sender, object originator, object value);
    public event HM1Xupdated HM1XupdatedEventHandler;

    // Callback and event handler for passing serial data to the main object.
    public delegate void SerialSystemUpdate(object sender, string text, int progressBarValue);
    public event SerialSystemUpdate SerialSystemUpdateEventHandler;

    // Received data buffer.
    private string InputData = string.Empty;

    // Settings AT suffix.
    List<string> atCommandSuffixList = new List<string>();

    // Setters for the timeouts.
    public void setReadTimeout(int timeout)
    {
        ComPort.ReadTimeout = timeout;
        readTimeout = timeout;
    }

    public void setWriteTimeout(int timeout)
    {
        ComPort.WriteTimeout = timeout;
        writeTimeout = timeout;
    }


    public List<string> getPortsList()
    {
        // Updates the COMs port list and returns it.
        foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
        {
            portList.Add(portName);
        }
        return portList;
    }

    // Open port using string identifiers.
    public void openPort(string port, string baudRate, string dataBits, string stopBits, string parity, string handshaking)
    {
        SerialSystemUpdateHandler(this, "Trying port " + port + "\n", 0);
        // Open if port isn't and there is at least one port listed.
        if (portOpen == false && portList.Count > 0)
        {
            ComPort.PortName = Convert.ToString(port);
            ComPort.BaudRate = Convert.ToInt32(baudRate);
            ComPort.DataBits = Convert.ToInt16(dataBits);
            ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
            ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshaking);
            ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
            ComPort.WriteTimeout = SerialPort.InfiniteTimeout;
            ComPort.ReadTimeout = SerialPort.InfiniteTimeout;
            try
            {
                ComPort.Open();

                // Only create one data handler, otherwise to whom do we listen?
                if (!dataHandlerAttached)
                {
                    ComPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    dataHandlerAttached = true;
                }

                SerialSystemUpdateHandler(this, ("Opened port " + port + "\r\n"), 100);
            }
            catch (UnauthorizedAccessException ex)
            {
                SerialSystemUpdateHandler(this, "Failed to open port " + port + "\r\n", 0);
                MessageBox.Show(ex.Message);
            }
            portOpen = true;
        }
        else if (portOpen == false)
        {
            closePort();
        }
    }

    public void closePort()
    {
        SerialSystemUpdateHandler(this, "Closing all ports.\r\n", 0);
        try
        {
            ComPort.Close();
            portOpen = false;
            SerialSystemUpdateHandler(this, "Closed all ports.\r\n", 100);
        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message);
            SerialSystemUpdateHandler(this, "Failed to close port(s).\r\n", 100);
        }
    }

    public bool isPortOpen()
    {
        // Well, is it?
        return portOpen;
    }


    // Helper methods.
    public void AddBaudRatesToComboBox(ComboBox comboBox, int defaultIndex)
    {
        // Fills a referenced combobox with common baud rates.
        comboBox.Items.Add(300);
        comboBox.Items.Add(600);
        comboBox.Items.Add(1200);
        comboBox.Items.Add(2400);
        comboBox.Items.Add(9600);
        comboBox.Items.Add(14400);
        comboBox.Items.Add(19200);
        comboBox.Items.Add(38400);
        comboBox.Items.Add(57600);
        comboBox.Items.Add(115200);
        comboBox.Items.Add(230400);

        if (defaultIndex > comboBox.Items.Count)
        {
            defaultIndex = comboBox.Items.Count;
        } else if (defaultIndex < 0)
        {
            defaultIndex = 0;
        }
        // Default to 
        comboBox.SelectedIndex = defaultIndex;
    }

    public void AddDataBitsToComboBox(ComboBox comboBox, int defaultIndex)
    {
        // Fills a referenced combobox with data bits settings.
        comboBox.Items.Add(6);
        comboBox.Items.Add(7);
        comboBox.Items.Add(8);
        comboBox.Items.Add(9);
        comboBox.Items.ToString();
        if (defaultIndex > comboBox.Items.Count)
        {
            defaultIndex = comboBox.Items.Count;
        }
        else if (defaultIndex < 0)
        {
            defaultIndex = 0;
        }
        // Default to 
        comboBox.SelectedIndex = defaultIndex;
    }

    public void AddStopBitsToComboBox(ComboBox comboBox, int defaultIndex)
    {
        // Fills a referenced combobox with stop bits settings.
        comboBox.Items.Add(1);
        comboBox.Items.Add(1.5);
        comboBox.Items.Add(2);
        comboBox.Items.ToString();
        if (defaultIndex > comboBox.Items.Count)
        {
            defaultIndex = comboBox.Items.Count;
        }
        else if (defaultIndex < 0)
        {
            defaultIndex = 0;
        }
        // Default to 
        comboBox.SelectedIndex = defaultIndex;
    }

    public void AddParityToComboBox(ComboBox comboBox, int defaultIndex)
    {
        // Fills a referenced combobox with parity settings.
        comboBox.Items.Add("None");
        comboBox.Items.Add("Odd");
        comboBox.Items.Add("Even");
        comboBox.Items.Add("Mark");
        comboBox.Items.Add("Space");
        if (defaultIndex > comboBox.Items.Count)
        {
            defaultIndex = comboBox.Items.Count;
        }
        else if (defaultIndex < 0)
        {
            defaultIndex = 0;
        }
        // Default to 
        comboBox.SelectedIndex = defaultIndex;
    }

    public void AddHandshakingToComboBox(ComboBox comboBox, int defaultIndex)
    {
        // Fills a referenced combobox with Handshaking settings.
        comboBox.Items.Add("None");
        comboBox.Items.Add("XOnXOff");
        comboBox.Items.Add("RequestToSend");
        comboBox.Items.Add("RequestToSendXOnXOff");
        if (defaultIndex > comboBox.Items.Count)
        {
            defaultIndex = comboBox.Items.Count;
        }
        else if (defaultIndex < 0)
        {
            defaultIndex = 0;
        }
        // Default to 
        comboBox.SelectedIndex = defaultIndex;
    }

    public void updateConnectionLabel(Label connectionLabel)
    {
        // Updates a referenced label with current port status and 
        // corresponding colors.
        if (portOpen == false)
        {
            connectionLabel.Text = "Disconnected";
            connectionLabel.BackColor = Color.Red;
        }
        else if (portOpen == true)
        {
            connectionLabel.Text = "Connected";
            connectionLabel.BackColor = Color.LimeGreen;
        }
    }

    // Read Data.
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        // Gets incoming data from open port and passes it to a handler.
        InputData = ComPort.ReadExisting();
        Console.WriteLine("RXed: {0}", InputData);
        
        // If not empty and we want to foreit capture to delegate.
        if (InputData != String.Empty && captureStream == false)
        {
            try
            {
                this.DataReceivedEventHandler(this, InputData);
            }
            catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
        } else if (InputData != String.Empty && captureStream == true)
        {
            captureBuffer = InputData;
            Console.WriteLine("Debug1: {0}", captureBuffer);
            captureBuffer = "";
        }
        else
        {
            // We retain capture. 
            captureBuffer = InputData;
        }
    }



    private void SerialSystemUpdateHandler(object sender, string text, int progressBarValue)
    {
        try
        {
            this.SerialSystemUpdateEventHandler(this, text, progressBarValue);
        } catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
    }

    //Write Data
    public void WriteData(string dataToWrite)
    {
        if (isPortOpen())
        {
            try
            {
                ComPort.Write(dataToWrite);
                //Console.WriteLine("Data Sent: {0}", dataToWrite);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(null, "Device on " + ComPort.PortName + " is not responding...", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        } else
            {
                MessageBox.Show(null, "No open port.", "Port error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    // Gets are single character from InputData buffer, removing it from the buffer.
    public char getChar()
    {
        char returnChar = '\0';
        try
        {
            returnChar = InputData[0];
            InputData.Remove(1, 1);
        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
        return returnChar;
    }

    // Mutate data
    public string convertASCIIStringToHexString(string text)
    {
        string result = "";
        // Replace the string "NULL" with an actual ASCII null.
        text = text.Replace("NULL", "\0");
        try
        {
            char[] values = text.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form.
                string hexOutput = string.Format("0x{0:X2} ", value);
                result += hexOutput;
            }

        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
        return result;
    }

    public string convertASCIIStringToDecimalString(string text)
    {
        string result = "";
        try
        {
            char[] values = text.ToCharArray();
            // Convert each Char value to a Decimal.
            foreach (var value in values)
            {
                decimal decValue = value;
                string decimalOutput = string.Format("{0} ", decValue);
                result += decimalOutput;
            }
        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }

        return result;
    }

    public string convertHexStringToASCIIHex(string text)
    {
        string result = "";
        string resultString = "";
        // Checked for null.  Good.
        try
        {
            result = text.Replace(" ", "");
            result = result.Replace("0x", "");

            byte[] byteArray = StringToByteArrayFastest(result);

            int index = 0;
            while (index < byteArray.Length)
            {
                if (byteArray[index] == 0x00)
                {
                    resultString += "NULL";
                    index++;
                }
                else
                {
                    resultString += System.Text.Encoding.Default.GetString(byteArray, index, 1);
                    index++;
                }
            }
        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }
        return resultString;
    }

    public bool isValidHexString(string text)
    {
        text = text.Replace(" ", "");
        text = text.Replace("0x", "");

        if (text.Count() % 2 != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public byte[] handleOddByteArray(byte[] byteArray)
    {
        if (byteArray.Count() % 2 == 1)
        {
            int newArrayLength = byteArray.Length - 1;
            byte[] tempByteArray = new byte[newArrayLength];
            Array.Copy(byteArray, tempByteArray, newArrayLength);
            return tempByteArray;
        } else
        {
            return byteArray;
        }
    }

    public static byte[] StringToByteArrayFastest(string hex)
    {
        // Checked for null.  Good.
        byte[] arr = new byte[hex.Length >> 1];
        try
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                var bfr = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
                if (bfr == 0)
                {
                    arr[i] = 0x00;
                } else
                {
                    arr[i] = bfr;
                }
            }

        }
        catch (UnauthorizedAccessException ex) { MessageBox.Show(ex.Message); }

        return arr;
    }

    public static int GetHexVal(char hex)
    {
        int val = (int)hex;
        //Or the two combined, but a bit slower:
        return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
    }

    public string getSelectedEndChars(int caseNumber)
    {
        string result = "";

        // Add user's selected character after RX.
        switch (caseNumber)
        {
            case (int)charsAfterRXTX.None:
                break;
            case (int)charsAfterRXTX.LineFeed:
                result += "\n";
                break;
            case (int)charsAfterRXTX.CarriageReturn:
                result += "\r";
                break;
            case (int)charsAfterRXTX.LineFeedCarriageReturn:
                result += "\n\r";
                break;
            case (int)charsAfterRXTX.CarriageReturnLineFeed:
                result += "\r\n";
                break;
        }

        return result;
    }

    private bool canConvertASCIIToInt(string text)
    {
        char[] byteArray = text.ToCharArray();
        foreach (char letter in byteArray)
        {
            if (letter > '/' && letter < ':') {; } else { return false; }
        }
        return true;
    }

   

}

// Borrowed from http://stackoverflow.com/questions/1926264/color-different-parts-of-a-richtextbox-string
public static class RichTextBoxExtensions
{
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
    }
}