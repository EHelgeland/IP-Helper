namespace IP_Helper
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxIPSelect = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textBoxCurrentIP = new System.Windows.Forms.TextBox();
            this.textBoxCurrentSubnet = new System.Windows.Forms.TextBox();
            this.textBoxCurrentGateway = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDHCP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxNIC = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Subnet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Gateway:";
            // 
            // comboBoxIPSelect
            // 
            this.comboBoxIPSelect.AutoCompleteCustomSource.AddRange(new string[] {
            "DHCP"});
            this.comboBoxIPSelect.FormattingEnabled = true;
            this.comboBoxIPSelect.Items.AddRange(new object[] {
            "192.168.1.9",
            "DHCP"});
            this.comboBoxIPSelect.Location = new System.Drawing.Point(114, 29);
            this.comboBoxIPSelect.MaxDropDownItems = 20;
            this.comboBoxIPSelect.Name = "comboBoxIPSelect";
            this.comboBoxIPSelect.Size = new System.Drawing.Size(233, 21);
            this.comboBoxIPSelect.TabIndex = 4;
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.Location = new System.Drawing.Point(20, 345);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(110, 23);
            this.buttonApply.TabIndex = 5;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // textBoxCurrentIP
            // 
            this.textBoxCurrentIP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCurrentIP.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxCurrentIP.Location = new System.Drawing.Point(114, 129);
            this.textBoxCurrentIP.Name = "textBoxCurrentIP";
            this.textBoxCurrentIP.ReadOnly = true;
            this.textBoxCurrentIP.Size = new System.Drawing.Size(233, 20);
            this.textBoxCurrentIP.TabIndex = 0;
            this.textBoxCurrentIP.TabStop = false;
            // 
            // textBoxCurrentSubnet
            // 
            this.textBoxCurrentSubnet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCurrentSubnet.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxCurrentSubnet.Location = new System.Drawing.Point(114, 162);
            this.textBoxCurrentSubnet.Name = "textBoxCurrentSubnet";
            this.textBoxCurrentSubnet.ReadOnly = true;
            this.textBoxCurrentSubnet.Size = new System.Drawing.Size(233, 20);
            this.textBoxCurrentSubnet.TabIndex = 0;
            this.textBoxCurrentSubnet.TabStop = false;
            // 
            // textBoxCurrentGateway
            // 
            this.textBoxCurrentGateway.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCurrentGateway.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxCurrentGateway.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxCurrentGateway.Location = new System.Drawing.Point(114, 195);
            this.textBoxCurrentGateway.Name = "textBoxCurrentGateway";
            this.textBoxCurrentGateway.ReadOnly = true;
            this.textBoxCurrentGateway.Size = new System.Drawing.Size(233, 20);
            this.textBoxCurrentGateway.TabIndex = 0;
            this.textBoxCurrentGateway.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.textBoxDHCP);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBoxCurrentGateway);
            this.groupBox2.Controls.Add(this.buttonRefresh);
            this.groupBox2.Controls.Add(this.textBoxCurrentSubnet);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxCurrentIP);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxNIC);
            this.groupBox2.Location = new System.Drawing.Point(20, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 230);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Network Interface Card";
            // 
            // textBoxDHCP
            // 
            this.textBoxDHCP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDHCP.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxDHCP.Location = new System.Drawing.Point(114, 96);
            this.textBoxDHCP.Name = "textBoxDHCP";
            this.textBoxDHCP.ReadOnly = true;
            this.textBoxDHCP.Size = new System.Drawing.Size(233, 20);
            this.textBoxDHCP.TabIndex = 3;
            this.textBoxDHCP.TabStop = false;
            this.textBoxDHCP.TextChanged += new System.EventHandler(this.TextBoxDHCP_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Status:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Location = new System.Drawing.Point(252, 60);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(95, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "&Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Show Disconnected";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(114, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Selected NIC";
            // 
            // comboBoxNIC
            // 
            this.comboBoxNIC.FormattingEnabled = true;
            this.comboBoxNIC.Location = new System.Drawing.Point(114, 30);
            this.comboBoxNIC.Name = "comboBoxNIC";
            this.comboBoxNIC.Size = new System.Drawing.Size(233, 21);
            this.comboBoxNIC.TabIndex = 1;
            this.comboBoxNIC.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNIC_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBoxIPSelect);
            this.groupBox1.Location = new System.Drawing.Point(20, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 72);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP Library";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Selected IP";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(146, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Address Book";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(272, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Options";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ButtonOptionClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 385);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBox2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "IP-Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboBoxIPSelect;
        private System.Windows.Forms.ComboBox comboBoxNIC;
        private System.Windows.Forms.TextBox textBoxCurrentIP;
        private System.Windows.Forms.TextBox textBoxCurrentSubnet;
        private System.Windows.Forms.TextBox textBoxCurrentGateway;
        private System.Windows.Forms.TextBox textBoxDHCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}