namespace WindowsFormsApplication2
{
    partial class AnalyzeConfiguration
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
            this.analyzeButton = new System.Windows.Forms.Button();
            this.openCheckBox = new System.Windows.Forms.CheckBox();
            this.highCheckBox = new System.Windows.Forms.CheckBox();
            this.lowCheckBox = new System.Windows.Forms.CheckBox();
            this.closeCheckBox = new System.Windows.Forms.CheckBox();
            this.stocksLable = new System.Windows.Forms.Label();
            this.stocksInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.daysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clusterTrackBar = new System.Windows.Forms.TrackBar();
            this.clusterNumberLable = new System.Windows.Forms.Label();
            this.autoTCheckBox = new System.Windows.Forms.CheckBox();
            this.t1TextBox = new System.Windows.Forms.TextBox();
            this.t2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stocksInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clusterTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzeButton.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzeButton.Location = new System.Drawing.Point(122, 184);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(78, 32);
            this.analyzeButton.TabIndex = 0;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // openCheckBox
            // 
            this.openCheckBox.AutoSize = true;
            this.openCheckBox.Checked = true;
            this.openCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openCheckBox.Location = new System.Drawing.Point(122, 87);
            this.openCheckBox.Name = "openCheckBox";
            this.openCheckBox.Size = new System.Drawing.Size(52, 17);
            this.openCheckBox.TabIndex = 1;
            this.openCheckBox.Text = "Open";
            this.openCheckBox.UseVisualStyleBackColor = true;
            this.openCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // highCheckBox
            // 
            this.highCheckBox.AutoSize = true;
            this.highCheckBox.Checked = true;
            this.highCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highCheckBox.Location = new System.Drawing.Point(180, 87);
            this.highCheckBox.Name = "highCheckBox";
            this.highCheckBox.Size = new System.Drawing.Size(48, 17);
            this.highCheckBox.TabIndex = 2;
            this.highCheckBox.Text = "High";
            this.highCheckBox.UseVisualStyleBackColor = true;
            this.highCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // lowCheckBox
            // 
            this.lowCheckBox.AutoSize = true;
            this.lowCheckBox.Checked = true;
            this.lowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lowCheckBox.Location = new System.Drawing.Point(234, 87);
            this.lowCheckBox.Name = "lowCheckBox";
            this.lowCheckBox.Size = new System.Drawing.Size(46, 17);
            this.lowCheckBox.TabIndex = 3;
            this.lowCheckBox.Text = "Low";
            this.lowCheckBox.UseVisualStyleBackColor = true;
            this.lowCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // closeCheckBox
            // 
            this.closeCheckBox.AutoSize = true;
            this.closeCheckBox.Checked = true;
            this.closeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closeCheckBox.Location = new System.Drawing.Point(286, 87);
            this.closeCheckBox.Name = "closeCheckBox";
            this.closeCheckBox.Size = new System.Drawing.Size(52, 17);
            this.closeCheckBox.TabIndex = 4;
            this.closeCheckBox.Text = "Close";
            this.closeCheckBox.UseVisualStyleBackColor = true;
            this.closeCheckBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // stocksLable
            // 
            this.stocksLable.AutoSize = true;
            this.stocksLable.Location = new System.Drawing.Point(12, 20);
            this.stocksLable.Name = "stocksLable";
            this.stocksLable.Size = new System.Drawing.Size(95, 13);
            this.stocksLable.TabIndex = 5;
            this.stocksLable.Text = "Number of Stocks:";
            // 
            // stocksInput
            // 
            this.stocksInput.Location = new System.Drawing.Point(121, 18);
            this.stocksInput.Maximum = new decimal(new int[] {
            3099,
            0,
            0,
            0});
            this.stocksInput.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.stocksInput.Name = "stocksInput";
            this.stocksInput.Size = new System.Drawing.Size(79, 20);
            this.stocksInput.TabIndex = 6;
            this.stocksInput.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.stocksInput.ValueChanged += new System.EventHandler(this.stocksInput_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Featurs";
            // 
            // daysNumericUpDown
            // 
            this.daysNumericUpDown.Location = new System.Drawing.Point(121, 53);
            this.daysNumericUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.daysNumericUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.daysNumericUpDown.Name = "daysNumericUpDown";
            this.daysNumericUpDown.Size = new System.Drawing.Size(79, 20);
            this.daysNumericUpDown.TabIndex = 9;
            this.daysNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.daysNumericUpDown.ValueChanged += new System.EventHandler(this.stocksInput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Analyze Days:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clusters";
            // 
            // clusterTrackBar
            // 
            this.clusterTrackBar.LargeChange = 1;
            this.clusterTrackBar.Location = new System.Drawing.Point(121, 110);
            this.clusterTrackBar.Minimum = 3;
            this.clusterTrackBar.Name = "clusterTrackBar";
            this.clusterTrackBar.Size = new System.Drawing.Size(159, 45);
            this.clusterTrackBar.TabIndex = 12;
            this.clusterTrackBar.Value = 5;
            this.clusterTrackBar.Scroll += new System.EventHandler(this.clusterTrackBar_Scroll);
            // 
            // clusterNumberLable
            // 
            this.clusterNumberLable.AutoSize = true;
            this.clusterNumberLable.Location = new System.Drawing.Point(294, 119);
            this.clusterNumberLable.Name = "clusterNumberLable";
            this.clusterNumberLable.Size = new System.Drawing.Size(13, 13);
            this.clusterNumberLable.TabIndex = 13;
            this.clusterNumberLable.Text = "5";
            // 
            // autoTCheckBox
            // 
            this.autoTCheckBox.AutoSize = true;
            this.autoTCheckBox.Checked = true;
            this.autoTCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoTCheckBox.Location = new System.Drawing.Point(15, 156);
            this.autoTCheckBox.Name = "autoTCheckBox";
            this.autoTCheckBox.Size = new System.Drawing.Size(80, 17);
            this.autoTCheckBox.TabIndex = 15;
            this.autoTCheckBox.Text = "Auto T1,T2";
            this.autoTCheckBox.UseVisualStyleBackColor = true;
            this.autoTCheckBox.CheckedChanged += new System.EventHandler(this.autoTCheckBox_CheckedChanged);
            // 
            // t1TextBox
            // 
            this.t1TextBox.Enabled = false;
            this.t1TextBox.Location = new System.Drawing.Point(145, 153);
            this.t1TextBox.Name = "t1TextBox";
            this.t1TextBox.Size = new System.Drawing.Size(29, 20);
            this.t1TextBox.TabIndex = 16;
            // 
            // t2TextBox
            // 
            this.t2TextBox.Enabled = false;
            this.t2TextBox.Location = new System.Drawing.Point(218, 153);
            this.t2TextBox.Name = "t2TextBox";
            this.t2TextBox.Size = new System.Drawing.Size(29, 20);
            this.t2TextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "T1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "T2";
            // 
            // AnalyzeConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 228);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t2TextBox);
            this.Controls.Add(this.t1TextBox);
            this.Controls.Add(this.autoTCheckBox);
            this.Controls.Add(this.clusterNumberLable);
            this.Controls.Add(this.clusterTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.daysNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stocksInput);
            this.Controls.Add(this.stocksLable);
            this.Controls.Add(this.closeCheckBox);
            this.Controls.Add(this.lowCheckBox);
            this.Controls.Add(this.highCheckBox);
            this.Controls.Add(this.openCheckBox);
            this.Controls.Add(this.analyzeButton);
            this.Name = "AnalyzeConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analyze Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.stocksInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clusterTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.CheckBox openCheckBox;
        private System.Windows.Forms.CheckBox highCheckBox;
        private System.Windows.Forms.CheckBox lowCheckBox;
        private System.Windows.Forms.CheckBox closeCheckBox;
        private System.Windows.Forms.Label stocksLable;
        private System.Windows.Forms.NumericUpDown stocksInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown daysNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar clusterTrackBar;
        private System.Windows.Forms.Label clusterNumberLable;
        private System.Windows.Forms.CheckBox autoTCheckBox;
        private System.Windows.Forms.TextBox t1TextBox;
        private System.Windows.Forms.TextBox t2TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}