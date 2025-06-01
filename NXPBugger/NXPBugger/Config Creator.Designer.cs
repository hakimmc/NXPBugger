namespace NXPBugger
{
    partial class Config_Creator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config_Creator));
            CANGB = new GroupBox();
            CAN4_BAUD_CB = new ComboBox();
            label3 = new Label();
            CAN3_BAUD_CB = new ComboBox();
            label4 = new Label();
            CAN2_BAUD_CB = new ComboBox();
            label2 = new Label();
            CAN1_BAUD_CB = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            UARTBAUDCB = new ComboBox();
            label7 = new Label();
            PRINTFDEBUGCB = new ComboBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            BOOTTIMEOUT = new NumericUpDown();
            label10 = new Label();
            SYSTEMID = new NumericUpDown();
            label9 = new Label();
            BootModeCB = new ComboBox();
            label12 = new Label();
            groupBox3 = new GroupBox();
            BUGFIXVERSION = new NumericUpDown();
            label14 = new Label();
            MINORVERSION = new NumericUpDown();
            label11 = new Label();
            MAJORVERSION = new NumericUpDown();
            label13 = new Label();
            AssembleBinFile = new Button();
            GenerateCfg = new Button();
            ReadCfg = new Button();
            groupBox4 = new GroupBox();
            DAISYCHAINCOUNT = new NumericUpDown();
            label18 = new Label();
            PARALLELCELLCOUNT = new NumericUpDown();
            label5 = new Label();
            SERIESCELLCOUNT = new NumericUpDown();
            label6 = new Label();
            CELLCAPAH = new NumericUpDown();
            label15 = new Label();
            groupBox5 = new GroupBox();
            usernamenum = new NumericUpDown();
            usernamenumlabel = new Label();
            companynum = new NumericUpDown();
            label17 = new Label();
            macaddresstext = new Label();
            GenMacAddr = new Button();
            label16 = new Label();
            macalgorithmcb = new ComboBox();
            groupBox6 = new GroupBox();
            tempsensorcount = new NumericUpDown();
            label25 = new Label();
            mintemp = new NumericUpDown();
            maxtemp = new NumericUpDown();
            defaultsoh = new NumericUpDown();
            label23 = new Label();
            label26 = new Label();
            defaultsoc = new NumericUpDown();
            label21 = new Label();
            label24 = new Label();
            maxcellv = new TextBox();
            label20 = new Label();
            mincellv = new TextBox();
            label19 = new Label();
            tempsensorb = new TextBox();
            label22 = new Label();
            CANGB.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BOOTTIMEOUT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SYSTEMID).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BUGFIXVERSION).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MINORVERSION).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MAJORVERSION).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DAISYCHAINCOUNT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PARALLELCELLCOUNT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SERIESCELLCOUNT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CELLCAPAH).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usernamenum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companynum).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tempsensorcount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mintemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxtemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)defaultsoh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)defaultsoc).BeginInit();
            SuspendLayout();
            // 
            // CANGB
            // 
            CANGB.Controls.Add(CAN4_BAUD_CB);
            CANGB.Controls.Add(label3);
            CANGB.Controls.Add(CAN3_BAUD_CB);
            CANGB.Controls.Add(label4);
            CANGB.Controls.Add(CAN2_BAUD_CB);
            CANGB.Controls.Add(label2);
            CANGB.Controls.Add(CAN1_BAUD_CB);
            CANGB.Controls.Add(label1);
            CANGB.Location = new Point(16, 122);
            CANGB.Name = "CANGB";
            CANGB.Size = new Size(211, 117);
            CANGB.TabIndex = 0;
            CANGB.TabStop = false;
            CANGB.Text = "Canbus Settings";
            // 
            // CAN4_BAUD_CB
            // 
            CAN4_BAUD_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CAN4_BAUD_CB.FormattingEnabled = true;
            CAN4_BAUD_CB.Items.AddRange(new object[] { "125K", "250K", "500K", "1000K" });
            CAN4_BAUD_CB.Location = new Point(95, 83);
            CAN4_BAUD_CB.Name = "CAN4_BAUD_CB";
            CAN4_BAUD_CB.Size = new Size(99, 23);
            CAN4_BAUD_CB.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 87);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 7;
            label3.Text = "CAN4 BAUD : ";
            // 
            // CAN3_BAUD_CB
            // 
            CAN3_BAUD_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CAN3_BAUD_CB.FormattingEnabled = true;
            CAN3_BAUD_CB.Items.AddRange(new object[] { "125K", "250K", "500K", "1000K" });
            CAN3_BAUD_CB.Location = new Point(95, 61);
            CAN3_BAUD_CB.Name = "CAN3_BAUD_CB";
            CAN3_BAUD_CB.Size = new Size(99, 23);
            CAN3_BAUD_CB.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 65);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 5;
            label4.Text = "CAN3 BAUD : ";
            // 
            // CAN2_BAUD_CB
            // 
            CAN2_BAUD_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CAN2_BAUD_CB.FormattingEnabled = true;
            CAN2_BAUD_CB.Items.AddRange(new object[] { "125K", "250K", "500K", "1000K" });
            CAN2_BAUD_CB.Location = new Point(95, 39);
            CAN2_BAUD_CB.Name = "CAN2_BAUD_CB";
            CAN2_BAUD_CB.Size = new Size(99, 23);
            CAN2_BAUD_CB.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 43);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 3;
            label2.Text = "CAN2 BAUD : ";
            // 
            // CAN1_BAUD_CB
            // 
            CAN1_BAUD_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            CAN1_BAUD_CB.FormattingEnabled = true;
            CAN1_BAUD_CB.Items.AddRange(new object[] { "125K", "250K", "500K", "1000K" });
            CAN1_BAUD_CB.Location = new Point(95, 17);
            CAN1_BAUD_CB.Name = "CAN1_BAUD_CB";
            CAN1_BAUD_CB.Size = new Size(99, 23);
            CAN1_BAUD_CB.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 1;
            label1.Text = "CAN1 BAUD : ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(UARTBAUDCB);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(PRINTFDEBUGCB);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(468, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 79);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Uart Settings";
            // 
            // UARTBAUDCB
            // 
            UARTBAUDCB.DropDownStyle = ComboBoxStyle.DropDownList;
            UARTBAUDCB.FormattingEnabled = true;
            UARTBAUDCB.Items.AddRange(new object[] { "9600", "115200" });
            UARTBAUDCB.Location = new Point(112, 43);
            UARTBAUDCB.Name = "UARTBAUDCB";
            UARTBAUDCB.Size = new Size(99, 23);
            UARTBAUDCB.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 46);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 3;
            label7.Text = "UART BAUD  :";
            // 
            // PRINTFDEBUGCB
            // 
            PRINTFDEBUGCB.DropDownStyle = ComboBoxStyle.DropDownList;
            PRINTFDEBUGCB.FormattingEnabled = true;
            PRINTFDEBUGCB.Items.AddRange(new object[] { "DISABLE", "ENABLE" });
            PRINTFDEBUGCB.Location = new Point(112, 21);
            PRINTFDEBUGCB.Name = "PRINTFDEBUGCB";
            PRINTFDEBUGCB.Size = new Size(99, 23);
            PRINTFDEBUGCB.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 26);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 1;
            label8.Text = "PRINTF DBG : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BOOTTIMEOUT);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(SYSTEMID);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(BootModeCB);
            groupBox2.Controls.Add(label12);
            groupBox2.Location = new Point(16, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(211, 104);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Boot Settings";
            // 
            // BOOTTIMEOUT
            // 
            BOOTTIMEOUT.Location = new Point(95, 68);
            BOOTTIMEOUT.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            BOOTTIMEOUT.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            BOOTTIMEOUT.Name = "BOOTTIMEOUT";
            BOOTTIMEOUT.Size = new Size(99, 23);
            BOOTTIMEOUT.TabIndex = 2;
            BOOTTIMEOUT.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 70);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 5;
            label10.Text = "TIMEOUT (s) :";
            // 
            // SYSTEMID
            // 
            SYSTEMID.Location = new Point(95, 46);
            SYSTEMID.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            SYSTEMID.Name = "SYSTEMID";
            SYSTEMID.Size = new Size(99, 23);
            SYSTEMID.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 48);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 3;
            label9.Text = "SYSTEM ID    :";
            // 
            // BootModeCB
            // 
            BootModeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            BootModeCB.FormattingEnabled = true;
            BootModeCB.Items.AddRange(new object[] { "CANBUS", "UART" });
            BootModeCB.Location = new Point(95, 22);
            BootModeCB.Name = "BootModeCB";
            BootModeCB.Size = new Size(99, 23);
            BootModeCB.TabIndex = 0;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 26);
            label12.Name = "label12";
            label12.Size = new Size(83, 15);
            label12.TabIndex = 1;
            label12.Text = "BOOT MODE : ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BUGFIXVERSION);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(MINORVERSION);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(MAJORVERSION);
            groupBox3.Controls.Add(label13);
            groupBox3.Location = new Point(233, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(229, 104);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Application Settings";
            // 
            // BUGFIXVERSION
            // 
            BUGFIXVERSION.Location = new Point(112, 64);
            BUGFIXVERSION.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            BUGFIXVERSION.Name = "BUGFIXVERSION";
            BUGFIXVERSION.Size = new Size(99, 23);
            BUGFIXVERSION.TabIndex = 9;
            BUGFIXVERSION.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 66);
            label14.Name = "label14";
            label14.Size = new Size(99, 15);
            label14.TabIndex = 7;
            label14.Text = "BUGFIX VER         :";
            // 
            // MINORVERSION
            // 
            MINORVERSION.Location = new Point(112, 44);
            MINORVERSION.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MINORVERSION.Name = "MINORVERSION";
            MINORVERSION.Size = new Size(99, 23);
            MINORVERSION.TabIndex = 8;
            MINORVERSION.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 45);
            label11.Name = "label11";
            label11.Size = new Size(99, 15);
            label11.TabIndex = 5;
            label11.Text = "MINOR VER         :";
            // 
            // MAJORVERSION
            // 
            MAJORVERSION.Location = new Point(112, 22);
            MAJORVERSION.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            MAJORVERSION.Name = "MAJORVERSION";
            MAJORVERSION.Size = new Size(99, 23);
            MAJORVERSION.TabIndex = 7;
            MAJORVERSION.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 24);
            label13.Name = "label13";
            label13.Size = new Size(100, 15);
            label13.TabIndex = 3;
            label13.Text = "MAJOR VER         :";
            // 
            // AssembleBinFile
            // 
            AssembleBinFile.Location = new Point(468, 245);
            AssembleBinFile.Name = "AssembleBinFile";
            AssembleBinFile.Size = new Size(463, 23);
            AssembleBinFile.TabIndex = 11;
            AssembleBinFile.Text = "Assemble App File";
            AssembleBinFile.UseVisualStyleBackColor = true;
            AssembleBinFile.Click += AssembleBinFile_Click;
            // 
            // GenerateCfg
            // 
            GenerateCfg.Location = new Point(233, 245);
            GenerateCfg.Name = "GenerateCfg";
            GenerateCfg.Size = new Size(229, 23);
            GenerateCfg.TabIndex = 12;
            GenerateCfg.Text = "Generate Cfg File";
            GenerateCfg.UseVisualStyleBackColor = true;
            GenerateCfg.Click += GenerateCfg_Click;
            // 
            // ReadCfg
            // 
            ReadCfg.Location = new Point(16, 245);
            ReadCfg.Name = "ReadCfg";
            ReadCfg.Size = new Size(211, 23);
            ReadCfg.TabIndex = 13;
            ReadCfg.Text = "Read Cfg File";
            ReadCfg.UseVisualStyleBackColor = true;
            ReadCfg.Click += ReadCfg_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(DAISYCHAINCOUNT);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(PARALLELCELLCOUNT);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(SERIESCELLCOUNT);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(CELLCAPAH);
            groupBox4.Controls.Add(label15);
            groupBox4.Location = new Point(233, 122);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(229, 117);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "BMS Settings";
            // 
            // DAISYCHAINCOUNT
            // 
            DAISYCHAINCOUNT.Location = new Point(112, 86);
            DAISYCHAINCOUNT.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            DAISYCHAINCOUNT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DAISYCHAINCOUNT.Name = "DAISYCHAINCOUNT";
            DAISYCHAINCOUNT.Size = new Size(99, 23);
            DAISYCHAINCOUNT.TabIndex = 13;
            DAISYCHAINCOUNT.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 88);
            label18.Name = "label18";
            label18.Size = new Size(97, 15);
            label18.TabIndex = 14;
            label18.Text = "DAISY CHAIN     :";
            // 
            // PARALLELCELLCOUNT
            // 
            PARALLELCELLCOUNT.Location = new Point(112, 64);
            PARALLELCELLCOUNT.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            PARALLELCELLCOUNT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PARALLELCELLCOUNT.Name = "PARALLELCELLCOUNT";
            PARALLELCELLCOUNT.Size = new Size(99, 23);
            PARALLELCELLCOUNT.TabIndex = 12;
            PARALLELCELLCOUNT.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 66);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 7;
            label5.Text = "PARALLEL CELL  :";
            // 
            // SERIESCELLCOUNT
            // 
            SERIESCELLCOUNT.Location = new Point(112, 44);
            SERIESCELLCOUNT.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            SERIESCELLCOUNT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            SERIESCELLCOUNT.Name = "SERIESCELLCOUNT";
            SERIESCELLCOUNT.Size = new Size(99, 23);
            SERIESCELLCOUNT.TabIndex = 11;
            SERIESCELLCOUNT.Value = new decimal(new int[] { 24, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 45);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 5;
            label6.Text = "SERIES CELL        :";
            // 
            // CELLCAPAH
            // 
            CELLCAPAH.Location = new Point(112, 22);
            CELLCAPAH.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            CELLCAPAH.Name = "CELLCAPAH";
            CELLCAPAH.Size = new Size(99, 23);
            CELLCAPAH.TabIndex = 10;
            CELLCAPAH.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 24);
            label15.Name = "label15";
            label15.Size = new Size(97, 15);
            label15.TabIndex = 3;
            label15.Text = "CELL CAP (Ah)   :";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(usernamenum);
            groupBox5.Controls.Add(usernamenumlabel);
            groupBox5.Controls.Add(companynum);
            groupBox5.Controls.Add(label17);
            groupBox5.Controls.Add(macaddresstext);
            groupBox5.Controls.Add(GenMacAddr);
            groupBox5.Controls.Add(label16);
            groupBox5.Controls.Add(macalgorithmcb);
            groupBox5.Location = new Point(468, 97);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(228, 142);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "MAC Settings";
            // 
            // usernamenum
            // 
            usernamenum.Location = new Point(114, 110);
            usernamenum.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            usernamenum.Name = "usernamenum";
            usernamenum.Size = new Size(99, 23);
            usernamenum.TabIndex = 19;
            // 
            // usernamenumlabel
            // 
            usernamenumlabel.AutoSize = true;
            usernamenumlabel.Location = new Point(8, 112);
            usernamenumlabel.Name = "usernamenumlabel";
            usernamenumlabel.Size = new Size(105, 15);
            usernamenumlabel.TabIndex = 18;
            usernamenumlabel.Text = "USERNAME NUM :";
            // 
            // companynum
            // 
            companynum.Location = new Point(114, 88);
            companynum.Maximum = new decimal(new int[] { 63, 0, 0, 0 });
            companynum.Name = "companynum";
            companynum.Size = new Size(99, 23);
            companynum.TabIndex = 11;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(8, 91);
            label17.Name = "label17";
            label17.Size = new Size(105, 15);
            label17.TabIndex = 10;
            label17.Text = "COMPANY NUM  :";
            // 
            // macaddresstext
            // 
            macaddresstext.AutoSize = true;
            macaddresstext.Location = new Point(8, 72);
            macaddresstext.Name = "macaddresstext";
            macaddresstext.Size = new Size(40, 15);
            macaddresstext.TabIndex = 17;
            macaddresstext.Text = "MAC :";
            // 
            // GenMacAddr
            // 
            GenMacAddr.Location = new Point(8, 47);
            GenMacAddr.Name = "GenMacAddr";
            GenMacAddr.Size = new Size(203, 23);
            GenMacAddr.TabIndex = 16;
            GenMacAddr.Text = "Generate MAC Address";
            GenMacAddr.UseVisualStyleBackColor = true;
            GenMacAddr.Click += GenMacAddr_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(8, 25);
            label16.Name = "label16";
            label16.Size = new Size(71, 15);
            label16.TabIndex = 16;
            label16.Text = "MAC ALG   :";
            // 
            // macalgorithmcb
            // 
            macalgorithmcb.DropDownStyle = ComboBoxStyle.DropDownList;
            macalgorithmcb.FormattingEnabled = true;
            macalgorithmcb.Items.AddRange(new object[] { "SHA256", "MD5", "CRC32", "HMAC-SHA256" });
            macalgorithmcb.Location = new Point(112, 20);
            macalgorithmcb.Name = "macalgorithmcb";
            macalgorithmcb.Size = new Size(99, 23);
            macalgorithmcb.TabIndex = 16;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(tempsensorcount);
            groupBox6.Controls.Add(label25);
            groupBox6.Controls.Add(mintemp);
            groupBox6.Controls.Add(maxtemp);
            groupBox6.Controls.Add(defaultsoh);
            groupBox6.Controls.Add(label23);
            groupBox6.Controls.Add(label26);
            groupBox6.Controls.Add(defaultsoc);
            groupBox6.Controls.Add(label21);
            groupBox6.Controls.Add(label24);
            groupBox6.Controls.Add(maxcellv);
            groupBox6.Controls.Add(label20);
            groupBox6.Controls.Add(mincellv);
            groupBox6.Controls.Add(label19);
            groupBox6.Controls.Add(tempsensorb);
            groupBox6.Controls.Add(label22);
            groupBox6.Location = new Point(702, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(229, 227);
            groupBox6.TabIndex = 15;
            groupBox6.TabStop = false;
            groupBox6.Text = "Cell Settings";
            // 
            // tempsensorcount
            // 
            tempsensorcount.Location = new Point(147, 187);
            tempsensorcount.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            tempsensorcount.Name = "tempsensorcount";
            tempsensorcount.Size = new Size(76, 23);
            tempsensorcount.TabIndex = 28;
            tempsensorcount.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(9, 191);
            label25.Name = "label25";
            label25.Size = new Size(132, 15);
            label25.TabIndex = 27;
            label25.Text = "TEMP SENSOR COUNT :";
            // 
            // mintemp
            // 
            mintemp.Location = new Point(123, 165);
            mintemp.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            mintemp.Name = "mintemp";
            mintemp.Size = new Size(100, 23);
            mintemp.TabIndex = 27;
            mintemp.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // maxtemp
            // 
            maxtemp.Location = new Point(123, 143);
            maxtemp.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            maxtemp.Name = "maxtemp";
            maxtemp.Size = new Size(100, 23);
            maxtemp.TabIndex = 26;
            maxtemp.Value = new decimal(new int[] { 70, 0, 0, 0 });
            // 
            // defaultsoh
            // 
            defaultsoh.Location = new Point(123, 122);
            defaultsoh.Name = "defaultsoh";
            defaultsoh.Size = new Size(100, 23);
            defaultsoh.TabIndex = 24;
            defaultsoh.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(9, 167);
            label23.Name = "label23";
            label23.Size = new Size(105, 15);
            label23.TabIndex = 26;
            label23.Text = "MIN TEMP             :";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(7, 125);
            label26.Name = "label26";
            label26.Size = new Size(108, 15);
            label26.TabIndex = 25;
            label26.Text = "DEFAULT % SOH    :";
            // 
            // defaultsoc
            // 
            defaultsoc.Location = new Point(123, 100);
            defaultsoc.Name = "defaultsoc";
            defaultsoc.Size = new Size(100, 23);
            defaultsoc.TabIndex = 10;
            defaultsoc.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 38);
            label21.Name = "label21";
            label21.Size = new Size(107, 15);
            label21.TabIndex = 3;
            label21.Text = "MAX CELL mV       :";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(9, 145);
            label24.Name = "label24";
            label24.Size = new Size(105, 15);
            label24.TabIndex = 25;
            label24.Text = "MAX TEMP            :";
            // 
            // maxcellv
            // 
            maxcellv.Location = new Point(123, 34);
            maxcellv.Name = "maxcellv";
            maxcellv.Size = new Size(100, 23);
            maxcellv.TabIndex = 15;
            maxcellv.Text = "3200";
            maxcellv.TextChanged += CELLSETTINGS_TextChanged;
            maxcellv.KeyPress += cellsettings_KeyPress;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 59);
            label20.Name = "label20";
            label20.Size = new Size(107, 15);
            label20.TabIndex = 5;
            label20.Text = "MIN CELL mV        :";
            // 
            // mincellv
            // 
            mincellv.Location = new Point(123, 56);
            mincellv.Name = "mincellv";
            mincellv.Size = new Size(100, 23);
            mincellv.TabIndex = 16;
            mincellv.Text = "2800";
            mincellv.TextChanged += CELLSETTINGS_TextChanged;
            mincellv.KeyPress += cellsettings_KeyPress;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(7, 82);
            label19.Name = "label19";
            label19.Size = new Size(106, 15);
            label19.TabIndex = 7;
            label19.Text = "TEMP SNSR BETA  :";
            // 
            // tempsensorb
            // 
            tempsensorb.Location = new Point(123, 78);
            tempsensorb.Name = "tempsensorb";
            tempsensorb.Size = new Size(100, 23);
            tempsensorb.TabIndex = 17;
            tempsensorb.Text = "3988";
            tempsensorb.TextChanged += CELLSETTINGS_TextChanged;
            tempsensorb.KeyPress += cellsettings_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(7, 103);
            label22.Name = "label22";
            label22.Size = new Size(107, 15);
            label22.TabIndex = 23;
            label22.Text = "DEFAULT % SOC    :";
            // 
            // Config_Creator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 277);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(ReadCfg);
            Controls.Add(GenerateCfg);
            Controls.Add(AssembleBinFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(CANGB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Config_Creator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NXPCreator";
            FormClosing += Config_Creator_FormClosing;
            Load += Config_Creator_Load;
            CANGB.ResumeLayout(false);
            CANGB.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BOOTTIMEOUT).EndInit();
            ((System.ComponentModel.ISupportInitialize)SYSTEMID).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BUGFIXVERSION).EndInit();
            ((System.ComponentModel.ISupportInitialize)MINORVERSION).EndInit();
            ((System.ComponentModel.ISupportInitialize)MAJORVERSION).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DAISYCHAINCOUNT).EndInit();
            ((System.ComponentModel.ISupportInitialize)PARALLELCELLCOUNT).EndInit();
            ((System.ComponentModel.ISupportInitialize)SERIESCELLCOUNT).EndInit();
            ((System.ComponentModel.ISupportInitialize)CELLCAPAH).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usernamenum).EndInit();
            ((System.ComponentModel.ISupportInitialize)companynum).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tempsensorcount).EndInit();
            ((System.ComponentModel.ISupportInitialize)mintemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxtemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)defaultsoh).EndInit();
            ((System.ComponentModel.ISupportInitialize)defaultsoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox CANGB;
        private Label label1;
        private ComboBox CAN4_BAUD_CB;
        private Label label3;
        private ComboBox CAN3_BAUD_CB;
        private Label label4;
        private ComboBox CAN2_BAUD_CB;
        private Label label2;
        private ComboBox CAN1_BAUD_CB;
        private GroupBox groupBox1;
        private ComboBox UARTBAUDCB;
        private Label label7;
        private ComboBox PRINTFDEBUGCB;
        private Label label8;
        private GroupBox groupBox2;
        private ComboBox BootModeCB;
        private Label label12;
        private NumericUpDown SYSTEMID;
        private Label label9;
        private NumericUpDown BOOTTIMEOUT;
        private Label label10;
        private GroupBox groupBox3;
        private NumericUpDown MINORVERSION;
        private Label label11;
        private NumericUpDown MAJORVERSION;
        private Label label13;
        private NumericUpDown BUGFIXVERSION;
        private Label label14;
        private Button AssembleBinFile;
        private Button GenerateCfg;
        private Button ReadCfg;
        private GroupBox groupBox4;
        private NumericUpDown PARALLELCELLCOUNT;
        private Label label5;
        private NumericUpDown SERIESCELLCOUNT;
        private Label label6;
        private NumericUpDown CELLCAPAH;
        private Label label15;
        private GroupBox groupBox5;
        private NumericUpDown DAISYCHAINCOUNT;
        private Label label18;
        private Label label16;
        private ComboBox macalgorithmcb;
        private GroupBox groupBox6;
        private Label label19;
        private Label label20;
        private Label label21;
        private Button GenMacAddr;
        private TextBox tempsensorb;
        private TextBox mincellv;
        private TextBox maxcellv;
        private Label macaddresstext;
        private Label label25;
        private Label label23;
        private Label label24;
        private Label label22;
        private NumericUpDown defaultsoc;
        private NumericUpDown maxtemp;
        private NumericUpDown defaultsoh;
        private Label label26;
        private NumericUpDown tempsensorcount;
        private NumericUpDown mintemp;
        private NumericUpDown usernamenum;
        private Label usernamenumlabel;
        private NumericUpDown companynum;
        private Label label17;
    }
}