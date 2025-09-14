namespace NXPBugger
{
    partial class NXPBuggerv1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NXPBuggerv1));
            SwUpdate_ProgressBar = new ProgressBar();
            UartRadio = new RadioButton();
            COMM_MODE_GB = new GroupBox();
            CanRadio = new RadioButton();
            BAUD_GB = new GroupBox();
            BaudCombobox = new ComboBox();
            ConnectButton = new Button();
            CFG_GB = new GroupBox();
            UART_COM_GB = new GroupBox();
            UartComportCombobox = new ComboBox();
            select_file_button = new Button();
            filename_label = new Label();
            Sw_UpdateStartButton = new Button();
            SW_UPD_GB = new GroupBox();
            Sw_DuringTimeLabel = new Label();
            toolStripSplitButton1 = new ToolStripSplitButton();
            readConfigToolStripMenuItem = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
            COMM_MODE_GB.SuspendLayout();
            BAUD_GB.SuspendLayout();
            CFG_GB.SuspendLayout();
            UART_COM_GB.SuspendLayout();
            SW_UPD_GB.SuspendLayout();
            SuspendLayout();
            // 
            // SwUpdate_ProgressBar
            // 
            SwUpdate_ProgressBar.Location = new Point(6, 109);
            SwUpdate_ProgressBar.Name = "SwUpdate_ProgressBar";
            SwUpdate_ProgressBar.Size = new Size(230, 23);
            SwUpdate_ProgressBar.TabIndex = 0;
            // 
            // UartRadio
            // 
            UartRadio.AutoSize = true;
            UartRadio.Location = new Point(6, 16);
            UartRadio.Name = "UartRadio";
            UartRadio.Size = new Size(47, 19);
            UartRadio.TabIndex = 3;
            UartRadio.TabStop = true;
            UartRadio.Text = "Uart";
            UartRadio.UseVisualStyleBackColor = true;
            UartRadio.CheckedChanged += UartRadio_CheckedChanged;
            // 
            // COMM_MODE_GB
            // 
            COMM_MODE_GB.Controls.Add(CanRadio);
            COMM_MODE_GB.Controls.Add(UartRadio);
            COMM_MODE_GB.Location = new Point(5, 22);
            COMM_MODE_GB.Name = "COMM_MODE_GB";
            COMM_MODE_GB.Size = new Size(231, 41);
            COMM_MODE_GB.TabIndex = 4;
            COMM_MODE_GB.TabStop = false;
            COMM_MODE_GB.Text = "Communication Mode";
            // 
            // CanRadio
            // 
            CanRadio.AutoSize = true;
            CanRadio.Location = new Point(117, 16);
            CanRadio.Name = "CanRadio";
            CanRadio.Size = new Size(108, 19);
            CanRadio.TabIndex = 4;
            CanRadio.TabStop = true;
            CanRadio.Text = "Canbus (PCAN)";
            CanRadio.UseVisualStyleBackColor = true;
            // 
            // BAUD_GB
            // 
            BAUD_GB.Controls.Add(BaudCombobox);
            BAUD_GB.Location = new Point(5, 69);
            BAUD_GB.Name = "BAUD_GB";
            BAUD_GB.Size = new Size(105, 53);
            BAUD_GB.TabIndex = 5;
            BAUD_GB.TabStop = false;
            BAUD_GB.Text = "Baud";
            // 
            // BaudCombobox
            // 
            BaudCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            BaudCombobox.FormattingEnabled = true;
            BaudCombobox.Location = new Point(6, 22);
            BaudCombobox.Name = "BaudCombobox";
            BaudCombobox.Size = new Size(93, 23);
            BaudCombobox.TabIndex = 0;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(5, 128);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(231, 23);
            ConnectButton.TabIndex = 6;
            ConnectButton.Text = "Connect to Device";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // CFG_GB
            // 
            CFG_GB.Controls.Add(UART_COM_GB);
            CFG_GB.Controls.Add(ConnectButton);
            CFG_GB.Controls.Add(BAUD_GB);
            CFG_GB.Controls.Add(COMM_MODE_GB);
            CFG_GB.Location = new Point(5, 6);
            CFG_GB.Name = "CFG_GB";
            CFG_GB.Size = new Size(244, 164);
            CFG_GB.TabIndex = 7;
            CFG_GB.TabStop = false;
            CFG_GB.Text = "Settings";
            // 
            // UART_COM_GB
            // 
            UART_COM_GB.Controls.Add(UartComportCombobox);
            UART_COM_GB.Location = new Point(116, 69);
            UART_COM_GB.Name = "UART_COM_GB";
            UART_COM_GB.Size = new Size(120, 53);
            UART_COM_GB.TabIndex = 6;
            UART_COM_GB.TabStop = false;
            UART_COM_GB.Text = "Uart Com Port";
            // 
            // UartComportCombobox
            // 
            UartComportCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            UartComportCombobox.FormattingEnabled = true;
            UartComportCombobox.ItemHeight = 15;
            UartComportCombobox.Location = new Point(6, 22);
            UartComportCombobox.Name = "UartComportCombobox";
            UartComportCombobox.Size = new Size(104, 23);
            UartComportCombobox.TabIndex = 1;
            UartComportCombobox.Click += UartComportCombobox_Click;
            // 
            // select_file_button
            // 
            select_file_button.Location = new Point(6, 22);
            select_file_button.Name = "select_file_button";
            select_file_button.Size = new Size(231, 23);
            select_file_button.TabIndex = 7;
            select_file_button.Text = "Select File";
            select_file_button.UseVisualStyleBackColor = true;
            select_file_button.Click += select_file_button_Click;
            // 
            // filename_label
            // 
            filename_label.AutoSize = true;
            filename_label.Location = new Point(6, 48);
            filename_label.Name = "filename_label";
            filename_label.Size = new Size(61, 15);
            filename_label.TabIndex = 8;
            filename_label.Text = "Filename :";
            // 
            // Sw_UpdateStartButton
            // 
            Sw_UpdateStartButton.Location = new Point(6, 66);
            Sw_UpdateStartButton.Name = "Sw_UpdateStartButton";
            Sw_UpdateStartButton.Size = new Size(231, 23);
            Sw_UpdateStartButton.TabIndex = 9;
            Sw_UpdateStartButton.Text = "Software Update Start";
            Sw_UpdateStartButton.UseVisualStyleBackColor = true;
            Sw_UpdateStartButton.Click += Sw_UpdateStartButton_Click;
            // 
            // SW_UPD_GB
            // 
            SW_UPD_GB.Controls.Add(Sw_DuringTimeLabel);
            SW_UPD_GB.Controls.Add(select_file_button);
            SW_UPD_GB.Controls.Add(filename_label);
            SW_UPD_GB.Controls.Add(Sw_UpdateStartButton);
            SW_UPD_GB.Controls.Add(SwUpdate_ProgressBar);
            SW_UPD_GB.Location = new Point(5, 176);
            SW_UPD_GB.Name = "SW_UPD_GB";
            SW_UPD_GB.Size = new Size(244, 143);
            SW_UPD_GB.TabIndex = 10;
            SW_UPD_GB.TabStop = false;
            SW_UPD_GB.Text = "Software Update";
            // 
            // Sw_DuringTimeLabel
            // 
            Sw_DuringTimeLabel.AutoSize = true;
            Sw_DuringTimeLabel.Location = new Point(6, 91);
            Sw_DuringTimeLabel.Name = "Sw_DuringTimeLabel";
            Sw_DuringTimeLabel.Size = new Size(40, 15);
            Sw_DuringTimeLabel.TabIndex = 10;
            Sw_DuringTimeLabel.Text = "Time :";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(23, 23);
            // 
            // readConfigToolStripMenuItem
            // 
            readConfigToolStripMenuItem.Name = "readConfigToolStripMenuItem";
            readConfigToolStripMenuItem.Size = new Size(195, 22);
            readConfigToolStripMenuItem.Text = "Read Config";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(59, 22);
            toolStripLabel1.Text = "System ID";
            // 
            // NXPBuggerv1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(256, 325);
            Controls.Add(SW_UPD_GB);
            Controls.Add(CFG_GB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "NXPBuggerv1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NXPBugger v";
            FormClosing += NXPBuggerv1_FormClosing;
            Load += NXPBuggerv1_Load;
            MouseDoubleClick += NXPBuggerv1_MouseDoubleClick;
            COMM_MODE_GB.ResumeLayout(false);
            COMM_MODE_GB.PerformLayout();
            BAUD_GB.ResumeLayout(false);
            CFG_GB.ResumeLayout(false);
            UART_COM_GB.ResumeLayout(false);
            SW_UPD_GB.ResumeLayout(false);
            SW_UPD_GB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public static Button select_cfg_file_button;
        public static Label cfgfilename_label;
        public ProgressBar SwUpdate_ProgressBar;
        public RadioButton UartRadio;
        public GroupBox COMM_MODE_GB;
        public RadioButton CanRadio;
        public GroupBox BAUD_GB;
        public ComboBox BaudCombobox;
        public Button ConnectButton;
        public GroupBox CFG_GB;
        public Button select_file_button;
        public Label filename_label;
        public Button Sw_UpdateStartButton;
        public GroupBox SW_UPD_GB;
        public Label Sw_DuringTimeLabel;
        public GroupBox UART_COM_GB;
        public ComboBox UartComportCombobox;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem readConfigToolStripMenuItem;
        private ToolStripComboBox SYSTEMID;
        private ToolStripLabel toolStripLabel1;
    }
}
