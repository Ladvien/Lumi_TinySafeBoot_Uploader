using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Lumi_Uploader_for_TinySafeBoot;
using System.Configuration;

// Set version here.
[assembly: AssemblyVersion("1.1.*")]

namespace HM_1X_Aid_v01
{

    public partial class MainDisplay : Form
    {

        string version = System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString();

        enum displayableDataTypes : int { HEX, Decimal, String };
        enum charsAfterRXTX : int { None = 0, LineFeed, CarriageReturn, CarriageReturnLineFeed, LineFeedCarriageReturn };
        bool toggleSendBoxStringHex = true;

        // RX data callback delegate.
        delegate void SetTextCallback(string text);
        delegate void HM1XVariableUpdate(object sender, object originator, object value);

        // Used to handoff data from ports thread to main thread.
        string tempBuffer = "";

        private SerialPortsExtended serialPorts = new SerialPortsExtended();

        // TinySafeBootloader
        private tsb tsb = new tsb();
        tsb.commands commands = new tsb.commands();
        

        OpenFileDialog hexFile = new OpenFileDialog();

        public MainDisplay()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prevents the GUI from getting illegible.
            this.MinimumSize = new System.Drawing.Size(800, 600);

            // Form Title
            this.Text = "Lumi Serial Terminal Template " + version;

            // Populate COM info.
            loadCOMInfo();

            // Setup display.
            lblConnectionStatus.BackColor = Color.Red;
            ltbTSB.Enabled = false;

            tsb.init(serialPorts, rtbMainDisplay, pbSysStatus);

            tsb.TsbConnectedEventHandler += new tsb.TsbConnected(tsbConnected);

        }

        private void tsbConnected(bool isConnected)
        {
            // 1. Check to make sure not crossing threading.
            // 2. Update TSB connection status.

            // 1
            if (ltbTSB.InvokeRequired)
            {
                ltbTSB.Invoke(new Action<bool>(tsbConnected), new object[] { isConnected });
                return;
            }

            // 2
            if (isConnected == true)
            {
                ltbTSB.Enabled = true;

            }
            else
            {
                ltbTSB.Enabled = false;
            }
        }

        private void loadSettings()
        {
            serialSystemUpdate(this, "Loading settings.\r\n", 0);
            if (cmbPortNumberInPortSettingsTab.Items.Count > 0)
            {

                cmbPortNumberInPortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.tabIndex;
            }

            cmbBaudRatePortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.BaudRate;
            cmbDataBitsPortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.dataBits;
            cmbStopBitsPortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.stopBits;
            cmbParityPortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.parity;
            cmbHandshakingPortSettingsTab.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.handshaking;
            cmbDataAs.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.displayDataSettings;
            cmbCharAfterRx.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterRX;
            cmbCharsAfterTx.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterTX;
            tbcBottomPane.SelectedIndex = Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.bottomAreaTab;
            serialSystemUpdate(this, "Loaded settings.\r\n", 100);
        }

        private void saveSettings()
        {
            serialSystemUpdate(this, "Saving settings.\r\n", 0);
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.lastCom = cmbPortNumberInPortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.BaudRate = cmbBaudRatePortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.dataBits = cmbDataBitsPortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.stopBits = cmbStopBitsPortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.parity = cmbParityPortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.handshaking = cmbHandshakingPortSettingsTab.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.displayDataSettings = cmbDataAs.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterRX = cmbCharAfterRx.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterTX = cmbCharsAfterTx.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.bottomAreaTab = tbcBottomPane.SelectedIndex;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.Save();
            serialSystemUpdate(this, "Saved settings.\r\n", 100);
        }

        private void resetSettings()
        {
            serialSystemUpdate(this, "Clearing settings.\r\n", 0);
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.lastCom = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.BaudRate = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.dataBits = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.stopBits = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.parity = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.handshaking = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.displayDataSettings = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterRX = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.charsAfterTX = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.moduleType = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.hm1xCommand = 0;
            Lumi_Uploader_for_TinySafeBoot.Properties.Settings.Default.Save();
            serialSystemUpdate(this, "Cleared.\r\n", 100);
        }

        void setText(string text)
        {
            rtbMainDisplay.Text = text;
        }


        // RX event handler triggered by SerialPort.  Hands off data quick.  
        // If you try to update UI from this method, threads tangel.
        public void gotData(object sender, string data)
        {
            // Incoming data is on another thread UI cannot be updated without crashing.
            tempBuffer = data;
            this.BeginInvoke(new SetTextCallback(SetText), new object[] { tempBuffer });
        }

        public void serialSystemUpdate(object sender, string text, int progressBarValue)
        {
            addSysMsgText(text);
            txbSysMsg.SelectionStart = txbSysMsg.Text.Length + 10;
            txbSysMsg.ScrollToCaret();
            pbSysStatus.Value = progressBarValue;
        }

        // This is the callback method run each time the tempBuffer changes.
        public void SetText(string text)
        {
            string result = "";
            // Display the RX'ed data in user selected fashion.
            switch (cmbDataAs.SelectedIndex)
            {
                // HEX.
                case 0:
                    result = serialPorts.convertASCIIStringToHexString(text, true);
                    break;
                // String.
                case 1:
                    result = text;
                    break;
                // Decimal.
                case 2:
                    result = serialPorts.convertASCIIStringToDecimalString(text);
                    break;
                // Defaults to string.
                default:
                    //result = text;
                    break;
            }

            // Add user's selected character after RX.
            result += serialPorts.getSelectedEndChars(cmbCharAfterRx.SelectedIndex);

            addDisplayText(result);
        }

        private void loadCOMInfo()
        {
            //serialSystemUpdate(this, "Loading COM info.\n", 0);
            clearMainDisplay();
            clearSerialPortMenu();

            cmbDataAs.Items.Add(displayableDataTypes.HEX.ToString());
            cmbDataAs.Items.Add(displayableDataTypes.String.ToString());
            cmbDataAs.Items.Add(displayableDataTypes.Decimal.ToString());
            cmbDataAs.SelectedIndex = 1;

            cmbCharAfterRx.Items.Add("None");
            cmbCharAfterRx.Items.Add("LF");
            cmbCharAfterRx.Items.Add("CR");
            cmbCharAfterRx.Items.Add("LF CR");
            cmbCharAfterRx.Items.Add("CR LF");
            cmbCharAfterRx.SelectedIndex = 1;

            cmbCharsAfterTx.Items.Add("None");
            cmbCharsAfterTx.Items.Add("LF");
            cmbCharsAfterTx.Items.Add("CR");
            cmbCharsAfterTx.Items.Add("LF CR");
            cmbCharsAfterTx.Items.Add("CR LF");
            cmbCharsAfterTx.SelectedIndex = 1;


            // Get a list of COM ports.
            List<string> portList = serialPorts.getPortsList();
            portList.ForEach(delegate (String portInfo)
            {
                // Add discoverd ports to menus.
                ToolStripItem subItem = new ToolStripMenuItem(portInfo, null, new EventHandler(subMenuItem_Click));
                serialPortsToolStripMenuItem.DropDownItems.Add(subItem);
                cmbPortNumberInPortSettingsTab.Items.Add(portInfo);
            });
            serialSystemUpdate(this, "", 50);
            if (portList.Count > 0)
            {
                togglePortMenu(true);

                // Set the default COM port.
                cmbPortNumberInPortSettingsTab.SelectedIndex = 0;

                // Populate the setting boxes.
                serialPorts.AddBaudRatesToComboBox(cmbBaudRatePortSettingsTab, 4);
                serialPorts.AddDataBitsToComboBox(cmbDataBitsPortSettingsTab, 2);
                serialPorts.AddStopBitsToComboBox(cmbStopBitsPortSettingsTab, 0);
                serialPorts.AddParityToComboBox(cmbParityPortSettingsTab, 0);
                serialPorts.AddHandshakingToComboBox(cmbHandshakingPortSettingsTab, 0);

                loadSettings();

            }
            serialSystemUpdate(this, "Loaded COM info.\r\n", 100);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveSettings();
            serialPorts.closePort();
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void subMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                int index = (item.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(item);
                cmbPortNumberInPortSettingsTab.SelectedIndex = index;
            }
        }

        private void togglePortMenu(bool offOrOn)
        {
            cmbPortNumberInPortSettingsTab.Enabled = offOrOn;
            cmbBaudRatePortSettingsTab.Enabled = offOrOn;
            cmbDataBitsPortSettingsTab.Enabled = offOrOn;
            cmbStopBitsPortSettingsTab.Enabled = offOrOn;
            cmbParityPortSettingsTab.Enabled = offOrOn;
            cmbHandshakingPortSettingsTab.Enabled = offOrOn;

            if (offOrOn)
            {
                btnConnectToTSB.Enabled = false;
            }
            else
            {
                btnConnectToTSB.Enabled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // My methods.
        private void clearMainDisplay()
        {
            rtbMainDisplay.Text = "";
        }

        private void setDisplayText(string text)
        {
            rtbMainDisplay.Text = text;
            //txbSysMsg.ScrollToCaret();
        }

        private void addDisplayText(string text)
        {
            rtbMainDisplay.AppendText(text);
            //mainDisplayTextBox.ScrollToCaret();
        }

        private void addSysMsgText(string text)
        {
            txbSysMsg.Text += text;
            txbSysMsg.ScrollToCaret();
        }

        private void setSysMsgText(string text)
        {
            txbSysMsg.Text = text;
        }


        private void clearSerialPortMenu()
        {
            serialPortsToolStripMenuItem.DropDownItems.Clear();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDisplayText(sender.ToString());
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPorts.isPortOpen() == false)
            {
                serialPorts.openPort(cmbPortNumberInPortSettingsTab.Text,
                    cmbBaudRatePortSettingsTab.Text,
                    cmbDataBitsPortSettingsTab.Text,
                    cmbStopBitsPortSettingsTab.Text,
                    cmbParityPortSettingsTab.Text,
                    cmbHandshakingPortSettingsTab.Text
                    );

                // If port did / didn't open, update timeouts and labels.
                if (serialPorts.isPortOpen())
                {
                    togglePortMenu(false);
                    serialPorts.setReadTimeout(1000);
                    serialPorts.setWriteTimeout(1000);
                    btnConnect.Text = "Disconnect";
                }
                else // If the port didn't connect, make sure UI reflects it.
                {
                    togglePortMenu(false);
                    btnConnect.Text = "Connect";
                    serialPorts.closePort();
                }
                serialPorts.updateConnectionLabel(lblConnectionStatus);
            }
            else // If connceted, disconnect.
            {
                serialPorts.closePort();
                togglePortMenu(true);
                serialPorts.updateConnectionLabel(lblConnectionStatus);
                btnConnect.Text = "Connect";
            }
        }

        private void String_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnToggleStringHexSendText_Click(object sender, EventArgs e)
        {
            string result = "";

            if (toggleSendBoxStringHex)
            {
                result = serialPorts.convertASCIIStringToHexString(txbSendTextBox.Text, true);
                toggleSendBoxStringHex = false;
                btnToggleStringHexSendText.Text = "Hex";
                txbSendTextBox.BackColor = Color.Black;
                txbSendTextBox.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                if (serialPorts.isValidHexString(txbSendTextBox.Text))
                {
                    result = serialPorts.convertHexStringToASCIIHex(txbSendTextBox.Text);
                    btnToggleStringHexSendText.Text = "String";
                    toggleSendBoxStringHex = true;
                    txbSendTextBox.BackColor = Color.White;
                    txbSendTextBox.ForeColor = Color.Black;
                }
                else
                {
                    addSysMsgText("Invalid hex string.\r\n");
                    result = txbSendTextBox.Text;
                    return;
                }
            }
            txbSendTextBox.Text = result;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            string result = txbSendTextBox.Text;

            // If data in send box is already stringy.
            // Else if it is HEX data, convert to string, then send.

            // Add user's selected character after RX.
            result += serialPorts.getSelectedEndChars(cmbCharsAfterTx.SelectedIndex);

            if (toggleSendBoxStringHex)
            {
                serialPorts.WriteData(result);
            }
            else if (!toggleSendBoxStringHex)
            {
                string data = serialPorts.convertHexStringToASCIIHex(result);
                serialPorts.WriteData(data);
            }
            else
            {
                serialPorts.WriteData(result);
                MessageBox.Show(null, "Problem sending data.", "Send error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSendBox_Click(object sender, EventArgs e)
        {
            txbSendTextBox.Clear();
        }

        private void btmClearMainDisplay_Click(object sender, EventArgs e)
        {
            clearMainDisplay();
        }

        private void btnClearSettings_Click(object sender, EventArgs e)
        {
            resetSettings();
        }

        private void btnOpenHexFile_Click(object sender, EventArgs e)
        {
            //ofdHexFile.ShowDialog();
        }


        private void btnWriteHexFile_Click(object sender, EventArgs e)
        {

        }


        private void btnReadHexFile_Click(object sender, EventArgs e)
        {
            tsb.readFlash();
            
        }

        private void btnConnectToTSB_Click(object sender, EventArgs e)
        {
            tsbConnected(false);
            tsb.helloProcessing();
        }

        private void MainDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.WindowsShutDown) 
            {
                saveSettings();
            }
        }
    }
}
