namespace WindowsFormsApplication2
{
    partial class UploadFiles
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
            this.srcButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.srcTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // srcButton
            // 
            this.srcButton.Location = new System.Drawing.Point(12, 12);
            this.srcButton.Name = "srcButton";
            this.srcButton.Size = new System.Drawing.Size(100, 23);
            this.srcButton.TabIndex = 0;
            this.srcButton.Text = "Select SRC Zip";
            this.srcButton.UseVisualStyleBackColor = true;
            this.srcButton.Click += new System.EventHandler(this.srcButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(487, 99);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(83, 23);
            this.cancleButton.TabIndex = 1;
            this.cancleButton.Text = "Cancle";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(12, 56);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(100, 23);
            this.logButton.TabIndex = 2;
            this.logButton.Text = "Select Log Zip";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(380, 99);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(85, 23);
            this.analyzeButton.TabIndex = 3;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(118, 58);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(452, 20);
            this.logTextBox.TabIndex = 5;
            this.logTextBox.Text = "*.zip Log File";
            // 
            // srcTextBox
            // 
            this.srcTextBox.Location = new System.Drawing.Point(118, 14);
            this.srcTextBox.Name = "srcTextBox";
            this.srcTextBox.Size = new System.Drawing.Size(452, 20);
            this.srcTextBox.TabIndex = 6;
            this.srcTextBox.Text = "Package Folder";
            // 
            // UploadFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 129);
            this.Controls.Add(this.srcTextBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.srcButton);
            this.Name = "UploadFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UploadFiles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button srcButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox srcTextBox;
    }
}