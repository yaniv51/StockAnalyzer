using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        Controller controller;
        bool startAlanyze;

        public MainForm()
        {
            InitializeComponent();
            controller = new Controller();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            SetOnlineView(false);
            controller.OutputRecived += Controller_OutputRecived;
            controller.AnalyzeFileRecived += Controller_AnalyzeFileRecived;
            controller.DownloadStocks += Controller_DownloadStocks;
            controller.FileTransferProgress += Controller_FileTransferProgress;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
            connectLable.Visible = false;
            outputTextBox.BackColor = Color.Black;
            outputTextBox.ForeColor = Color.Green;
        }

        #region events
        private void Controller_FileTransferProgress(object sender, double e)
        {
            UpdateOutputData(e);
        }

        private void Controller_DownloadStocks(object sender, bool e)
        {
            UpdateForm(e);
        }

        private void Controller_AnalyzeFileRecived(object sender, string e)
        {
            OutputDataRevied(e);
        }

        private void Controller_OutputRecived(object sender, string e)
        {
            UpdateOutputData(e);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowError(e.ToString());
        }
        #endregion

        #region dataUpdate
        private void ShowError(string message)
        {
            if (this.InvokeRequired)
            {
                Action<string> dlg = new Action<string>(ShowError);
                this.BeginInvoke(dlg, message);
            }
            else
            {
                MessageBox.Show("Could not execute. "+message);
                return;
            }
        }

        private void OutputDataRevied(string data)
        {
            if (this.InvokeRequired)
            {
                Action<string> dlg = new Action<string>(OutputDataRevied);
                this.BeginInvoke(dlg, data);
            }
            else
            {
                OutputForm of = new OutputForm(data);
                of.Show();
            }
        }

        private void UpdateForm(bool isAnalyzeRunning)
        {
            if (this.InvokeRequired)
            {
                Action<bool> dlg = new Action<bool>(UpdateForm);
                this.BeginInvoke(dlg, isAnalyzeRunning);
            }
            else
            {
                stocksButton.Enabled = !isAnalyzeRunning;
                selectFileButton.Enabled = !isAnalyzeRunning;
                downloadFileButton.Enabled = !isAnalyzeRunning;
                UpdateConnectionButtons(!isAnalyzeRunning);
                if (!isAnalyzeRunning)
                {
                    UpdateOutputData(100);
                    if(startAlanyze)
                    {
                        startAlanyze = false;
                        StartAnalyze(Directory.GetCurrentDirectory() + PathHelper.stocksZip, Directory.GetCurrentDirectory()+PathHelper.solutionZip);
                    }
                }
            }
        }

        private void UpdateOutputData(double progresss)
        {
            if (this.InvokeRequired)
            {
                Action<double> dlg = new Action<double>(UpdateOutputData);
                this.BeginInvoke(dlg, progresss);
            }
            else
            {
                progressBar.Value = (int)progresss;
                Invalidate();
            }
        }

        private void UpdateOutputData(string data)
        {
            if (this.InvokeRequired)
            {
                Action<string> dlg = new Action<string>(UpdateOutputData);
                this.BeginInvoke(dlg, data);
            }
            else
            {
                if (data.EndsWith("100%"))
                    UpdateOutputData(100);
                outputTextBox.AppendText(data+ "\n");
                outputTextBox.ScrollToCaret();
            }
        }
        #endregion
        private void sendCommandbutton_Click(object sender, EventArgs e)
        {
            controller.ExcecuteCommand(commandTextBox.Text);
            commandTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            controller.CloseSession();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            controller.CloseSession();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string host, user, password;
            int port;
            bool isSuccess;

            host = hostTextBox.Text;
            port = int.Parse(portTextBox.Text);
            user = userNameTextBox.Text;
            password = passwordTextBox.Text;
            connectLable.Text = "Wait For Connection...";
            connectLable.Visible = true;
            isSuccess = controller.Connect(host, port, user, password);

            if (isSuccess)
            {
                connectLable.Text = "Connection Established";
                UpdateConnectionButtons(false);
                SetOnlineView(true);
            }
            else
            {
                connectLable.Text = "Connection Failed";
                UpdateConnectionButtons(true);
                SetOnlineView(false);
            }
        }

        private void UpdateConnectionButtons(bool enable)
        {
            connectButton.Enabled = enable;
            hostTextBox.Enabled = enable;
            portTextBox.Enabled = enable;
            userNameTextBox.Enabled = enable;
            passwordTextBox.Enabled = enable;
        }
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            AnalyzeProject();
        }

        private void AnalyzeProject(string path1 = null, string path2 = null)
        {
            UploadFiles upFiles = new UploadFiles(path1, path2);
            DialogResult userClickedOK = upFiles.ShowDialog();
            bool isSuccess = false;
            if (userClickedOK == DialogResult.OK)
            {
                if (upFiles.LogPath == "")
                {
                    MessageBox.Show("Could not execute");
                    return;
                }

                StartAnalyze(upFiles.LogPath, upFiles.SrcPath);
            }
        }

        private void StartAnalyze(string inputFiles, string sourceFiles)
        {
            bool isSuccess;

            isSuccess = controller.AnalyzeProject(sourceFiles, inputFiles);
            if (isSuccess)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Visible = true;
            }
            else
                progressBar.Visible = false;
        }

        private void commandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                controller.ExcecuteCommand(commandTextBox.Text);
                commandTextBox.Text = "";
            }
        }

        private void downloadFileButton_Click(object sender, EventArgs e)
        {
            GetItemForm newForm;
            string fileName, filePath;
            newForm = new GetItemForm();
            DialogResult userClickedOK = newForm.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                fileName = newForm.FileName;
                filePath = newForm.FilePath;
                if (fileName == "")
                    return;

                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Visible = true;
                try
                {
                    controller.DownloadFile(fileName, filePath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void stocksButton_Click(object sender, EventArgs e)
        {
            AnalyzeConfiguration az = new AnalyzeConfiguration();
            if (az.ShowDialog() == DialogResult.OK)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Visible = true;
                startAlanyze = true;
                controller.AnalyzeStocks(az.Config);
                az.Dispose();
            }
        }

        private void SetOnlineView(bool online)
        {
            commandTextBox.Enabled = online;
            selectFileButton.Enabled = online;
            downloadFileButton.Enabled = online;

        }

        private void chartsButton_Click(object sender, EventArgs e)
        {
            AnalyzeConfiguration az = new AnalyzeConfiguration(true);
            string path;
            if (az.ShowDialog() == DialogResult.OK)
            {
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Visible = true;
                startAlanyze = true;
                path = az.OfflinePath;
                controller.AnalyzeStocksOffline(path, false, az.Config);
                az.Dispose();
            }
        }
    }
}
