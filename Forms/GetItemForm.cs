using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class GetItemForm : Form
    {
        string fileName;
        string filePath;
        public GetItemForm()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
        }
        public string FilePath
        {
            get { return filePath; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            fileName = fileNameTextBox.Text;
            this.Dispose();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            fileName = "";
            filePath = "";
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void locationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();

            DialogResult userClickedOK = fd.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                filePath = fd.SelectedPath;
            }
        }
    }
}
