namespace MyClient
{
    partial class Form1
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
            this.hostName = new System.Windows.Forms.Label();
            this.hostNameTB = new System.Windows.Forms.TextBox();
            this.portNumber = new System.Windows.Forms.Label();
            this.portNumberTB = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.locationTB = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.protocolBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeoutTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostName
            // 
            this.hostName.AutoSize = true;
            this.hostName.Location = new System.Drawing.Point(38, 47);
            this.hostName.Name = "hostName";
            this.hostName.Size = new System.Drawing.Size(61, 13);
            this.hostName.TabIndex = 0;
            this.hostName.Text = "Host name:";
            // 
            // hostNameTB
            // 
            this.hostNameTB.Location = new System.Drawing.Point(41, 72);
            this.hostNameTB.Name = "hostNameTB";
            this.hostNameTB.Size = new System.Drawing.Size(100, 20);
            this.hostNameTB.TabIndex = 1;
            this.hostNameTB.TextChanged += new System.EventHandler(this.hostNameTB_TextChanged);
            // 
            // portNumber
            // 
            this.portNumber.AutoSize = true;
            this.portNumber.Location = new System.Drawing.Point(38, 118);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(67, 13);
            this.portNumber.TabIndex = 2;
            this.portNumber.Text = "Port number:";
            // 
            // portNumberTB
            // 
            this.portNumberTB.Location = new System.Drawing.Point(41, 149);
            this.portNumberTB.Name = "portNumberTB";
            this.portNumberTB.Size = new System.Drawing.Size(100, 20);
            this.portNumberTB.TabIndex = 3;
            this.portNumberTB.TextChanged += new System.EventHandler(this.portNumberTB_TextChanged);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(41, 194);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(58, 13);
            this.username.TabIndex = 4;
            this.username.Text = "Username:";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(41, 223);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(100, 20);
            this.usernameTB.TabIndex = 5;
            this.usernameTB.TextChanged += new System.EventHandler(this.usernameTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Location:";
            // 
            // locationTB
            // 
            this.locationTB.Location = new System.Drawing.Point(41, 301);
            this.locationTB.Name = "locationTB";
            this.locationTB.Size = new System.Drawing.Size(100, 20);
            this.locationTB.TabIndex = 7;
            this.locationTB.TextChanged += new System.EventHandler(this.locationTB_TextChanged);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(246, 187);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(107, 56);
            this.sendButton.TabIndex = 8;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Protocol:";
            // 
            // protocolBox
            // 
            this.protocolBox.FormattingEnabled = true;
            this.protocolBox.Items.AddRange(new object[] {
            "whois",
            "HTTP/0.9",
            "HTTP/1.0",
            "HTTP/1.1"});
            this.protocolBox.Location = new System.Drawing.Point(41, 375);
            this.protocolBox.Name = "protocolBox";
            this.protocolBox.Size = new System.Drawing.Size(121, 21);
            this.protocolBox.TabIndex = 10;
            this.protocolBox.SelectedIndexChanged += new System.EventHandler(this.protocolBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Timeout:";
            // 
            // timeoutTB
            // 
            this.timeoutTB.Location = new System.Drawing.Point(246, 72);
            this.timeoutTB.Name = "timeoutTB";
            this.timeoutTB.Size = new System.Drawing.Size(100, 20);
            this.timeoutTB.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 55);
            this.button1.TabIndex = 13;
            this.button1.Text = "Debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeoutTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.protocolBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.locationTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.username);
            this.Controls.Add(this.portNumberTB);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.hostNameTB);
            this.Controls.Add(this.hostName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostName;
        private System.Windows.Forms.TextBox hostNameTB;
        private System.Windows.Forms.Label portNumber;
        private System.Windows.Forms.TextBox portNumberTB;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox locationTB;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox protocolBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeoutTB;
        private System.Windows.Forms.Button button1;
    }
}