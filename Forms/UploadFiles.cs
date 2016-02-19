using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class UploadFiles : Form
    {
        public string LogPath { get; set; }
        public string SrcPath { get; set; }
        public UploadFiles(string zipPath = null, string srcPath = null)
        {
            InitializeComponent();
            if (zipPath == null)
                logTextBox.Text = Directory.GetCurrentDirectory() + PathHelper.webLog;
            else
                logTextBox.Text = zipPath;
            if (srcPath == null)
                srcTextBox.Text = Directory.GetCurrentDirectory() + PathHelper.srcPath;
            else
                srcTextBox.Text = srcPath;
        }

        private void srcButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Zip Files|*.zip";
            if (!string.IsNullOrEmpty(logTextBox.Text))
                ofd.InitialDirectory = Path.GetDirectoryName(logTextBox.Text);

            DialogResult userClickedOK = ofd.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                SrcPath = ofd.FileName;
                srcTextBox.Text = SrcPath;
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Zip Files|*.zip";
            if (!string.IsNullOrEmpty(logTextBox.Text))
                ofd.InitialDirectory = Path.GetDirectoryName(logTextBox.Text);
            DialogResult userClickedOK = ofd.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                LogPath = ofd.FileName;
                logTextBox.Text = LogPath;
            }
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            LogPath = logTextBox.Text;
            SrcPath = srcTextBox.Text;
            this.Dispose();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            LogPath = "";
            SrcPath = "";
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
