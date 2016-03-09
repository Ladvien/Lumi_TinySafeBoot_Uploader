namespace Lumi_Uploader_for_TinySafeBoot
{
    partial class frmTerminal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminal));
            this.tblTerminalMain = new System.Windows.Forms.TableLayoutPanel();
            this.rtbMainDisplay = new System.Windows.Forms.RichTextBox();
            this.tblCommandTable = new System.Windows.Forms.TableLayoutPanel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClearSendBox = new System.Windows.Forms.Button();
            this.btnToggleStringHexSendText = new System.Windows.Forms.Button();
            this.txbSendTextBox = new System.Windows.Forms.TextBox();
            this.tblTerminalMain.SuspendLayout();
            this.tblCommandTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblTerminalMain
            // 
            this.tblTerminalMain.ColumnCount = 1;
            this.tblTerminalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTerminalMain.Controls.Add(this.rtbMainDisplay, 0, 0);
            this.tblTerminalMain.Controls.Add(this.tblCommandTable, 0, 1);
            this.tblTerminalMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTerminalMain.Location = new System.Drawing.Point(0, 0);
            this.tblTerminalMain.Name = "tblTerminalMain";
            this.tblTerminalMain.RowCount = 2;
            this.tblTerminalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.73034F));
            this.tblTerminalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.269663F));
            this.tblTerminalMain.Size = new System.Drawing.Size(1091, 712);
            this.tblTerminalMain.TabIndex = 0;
            this.tblTerminalMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tblTerminalMain_Paint);
            // 
            // rtbMainDisplay
            // 
            this.rtbMainDisplay.BackColor = System.Drawing.SystemColors.Desktop;
            this.rtbMainDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMainDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainDisplay.ForeColor = System.Drawing.Color.Lime;
            this.rtbMainDisplay.Location = new System.Drawing.Point(3, 3);
            this.rtbMainDisplay.Name = "rtbMainDisplay";
            this.rtbMainDisplay.Size = new System.Drawing.Size(1085, 640);
            this.rtbMainDisplay.TabIndex = 5;
            this.rtbMainDisplay.Text = "";
            // 
            // tblCommandTable
            // 
            this.tblCommandTable.ColumnCount = 5;
            this.tblCommandTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.01717F));
            this.tblCommandTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99571F));
            this.tblCommandTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99571F));
            this.tblCommandTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99571F));
            this.tblCommandTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99571F));
            this.tblCommandTable.Controls.Add(this.btnSend, 1, 0);
            this.tblCommandTable.Controls.Add(this.btnClearSendBox, 2, 0);
            this.tblCommandTable.Controls.Add(this.btnToggleStringHexSendText, 1, 0);
            this.tblCommandTable.Controls.Add(this.txbSendTextBox, 0, 0);
            this.tblCommandTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCommandTable.Location = new System.Drawing.Point(3, 649);
            this.tblCommandTable.Name = "tblCommandTable";
            this.tblCommandTable.RowCount = 1;
            this.tblCommandTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommandTable.Size = new System.Drawing.Size(1085, 60);
            this.tblCommandTable.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(697, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(124, 54);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnClearSendBox
            // 
            this.btnClearSendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearSendBox.Location = new System.Drawing.Point(827, 3);
            this.btnClearSendBox.Name = "btnClearSendBox";
            this.btnClearSendBox.Size = new System.Drawing.Size(124, 54);
            this.btnClearSendBox.TabIndex = 3;
            this.btnClearSendBox.Text = "Clear";
            this.btnClearSendBox.UseVisualStyleBackColor = true;
            // 
            // btnToggleStringHexSendText
            // 
            this.btnToggleStringHexSendText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleStringHexSendText.Location = new System.Drawing.Point(567, 3);
            this.btnToggleStringHexSendText.Name = "btnToggleStringHexSendText";
            this.btnToggleStringHexSendText.Size = new System.Drawing.Size(124, 54);
            this.btnToggleStringHexSendText.TabIndex = 2;
            this.btnToggleStringHexSendText.Text = "String";
            this.btnToggleStringHexSendText.UseVisualStyleBackColor = true;
            // 
            // txbSendTextBox
            // 
            this.txbSendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSendTextBox.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSendTextBox.Location = new System.Drawing.Point(3, 3);
            this.txbSendTextBox.Multiline = true;
            this.txbSendTextBox.Name = "txbSendTextBox";
            this.txbSendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbSendTextBox.Size = new System.Drawing.Size(558, 54);
            this.txbSendTextBox.TabIndex = 1;
            // 
            // frmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 712);
            this.Controls.Add(this.tblTerminalMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTerminal";
            this.Text = "Terminal";
            this.Load += new System.EventHandler(this.frmTerminal_Load);
            this.tblTerminalMain.ResumeLayout(false);
            this.tblCommandTable.ResumeLayout(false);
            this.tblCommandTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblTerminalMain;
        private System.Windows.Forms.TableLayoutPanel tblCommandTable;
        public System.Windows.Forms.RichTextBox rtbMainDisplay;
        public System.Windows.Forms.TextBox txbSendTextBox;
        public System.Windows.Forms.Button btnToggleStringHexSendText;
        public System.Windows.Forms.Button btnClearSendBox;
        public System.Windows.Forms.Button btnSend;
    }
}