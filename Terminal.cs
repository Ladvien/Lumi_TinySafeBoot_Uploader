using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lumi_Uploader_for_TinySafeBoot
{
    public partial class frmTerminal : Form
    {
        public frmTerminal()
        {
            InitializeComponent();
        }

        private void tblTerminalMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTerminal_Load(object sender, EventArgs e)
        {
            
        }

        public void initializeControls(RichTextBox mainDisplay, TextBox sendTextBox, Button send, Button clearSendBox, Button toggleStringHexSendText)
        {

            mainDisplay = rtbMainDisplay;
            sendTextBox = txbSendTextBox;
            send = btnSend;
            clearSendBox = btnClearSendBox;
            btnToggleStringHexSendText = toggleStringHexSendText;
        }
    }
}
