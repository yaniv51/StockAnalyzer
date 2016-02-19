namespace WindowsFormsApplication2
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.hostLable = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectLable = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.downloadFileButton = new System.Windows.Forms.Button();
            this.stocksButton = new System.Windows.Forms.Button();
            this.chartsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(328, 35);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(87, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "training";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(70, 35);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(143, 20);
            this.userNameTextBox.TabIndex = 5;
            this.userNameTextBox.Text = "training";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "User Name";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(328, 6);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(87, 20);
            this.portTextBox.TabIndex = 7;
            this.portTextBox.Text = "22";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(70, 6);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(143, 20);
            this.hostTextBox.TabIndex = 9;
            this.hostTextBox.Text = "192.168.";
            // 
            // hostLable
            // 
            this.hostLable.AutoSize = true;
            this.hostLable.Location = new System.Drawing.Point(6, 9);
            this.hostLable.Name = "hostLable";
            this.hostLable.Size = new System.Drawing.Size(29, 13);
            this.hostLable.TabIndex = 8;
            this.hostLable.Text = "Host";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(9, 78);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 10;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectLable
            // 
            this.connectLable.AutoSize = true;
            this.connectLable.Location = new System.Drawing.Point(111, 83);
            this.connectLable.Name = "connectLable";
            this.connectLable.Size = new System.Drawing.Size(14, 13);
            this.connectLable.TabIndex = 11;
            this.connectLable.Text = "A";
            // 
            // selectFileButton
            // 
            this.selectFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectFileButton.Location = new System.Drawing.Point(151, 437);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(126, 23);
            this.selectFileButton.TabIndex = 12;
            this.selectFileButton.Text = "Run Project";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // commandTextBox
            // 
            this.commandTextBox.Location = new System.Drawing.Point(86, 113);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(370, 20);
            this.commandTextBox.TabIndex = 14;
            this.commandTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Command";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.outputTextBox.Location = new System.Drawing.Point(15, 160);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(468, 271);
            this.outputTextBox.TabIndex = 16;
            this.outputTextBox.Text = "";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(408, 468);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(151, 468);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(126, 23);
            this.progressBar.TabIndex = 18;
            this.progressBar.Visible = false;
            // 
            // downloadFileButton
            // 
            this.downloadFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downloadFileButton.Location = new System.Drawing.Point(15, 468);
            this.downloadFileButton.Name = "downloadFileButton";
            this.downloadFileButton.Size = new System.Drawing.Size(126, 23);
            this.downloadFileButton.TabIndex = 19;
            this.downloadFileButton.Text = "Select File to download";
            this.downloadFileButton.UseVisualStyleBackColor = true;
            this.downloadFileButton.Click += new System.EventHandler(this.downloadFileButton_Click);
            // 
            // stocksButton
            // 
            this.stocksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stocksButton.Location = new System.Drawing.Point(15, 437);
            this.stocksButton.Name = "stocksButton";
            this.stocksButton.Size = new System.Drawing.Size(126, 23);
            this.stocksButton.TabIndex = 20;
            this.stocksButton.Text = "Analyze Stocks";
            this.stocksButton.UseVisualStyleBackColor = true;
            this.stocksButton.Click += new System.EventHandler(this.stocksButton_Click);
            // 
            // chartsButton
            // 
            this.chartsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chartsButton.Location = new System.Drawing.Point(408, 439);
            this.chartsButton.Name = "chartsButton";
            this.chartsButton.Size = new System.Drawing.Size(75, 23);
            this.chartsButton.TabIndex = 21;
            this.chartsButton.Text = "Show Offline";
            this.chartsButton.UseVisualStyleBackColor = true;
            this.chartsButton.Click += new System.EventHandler(this.chartsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 503);
            this.Controls.Add(this.chartsButton);
            this.Controls.Add(this.stocksButton);
            this.Controls.Add(this.downloadFileButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.connectLable);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.hostLable);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(516, 541);
            this.Name = "MainForm";
            this.Text = "Linux Connector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label hostLable;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectLable;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button downloadFileButton;
        private System.Windows.Forms.Button stocksButton;
        private System.Windows.Forms.Button chartsButton;
    }
}

