using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinSCP;
using System.IO;

namespace WindowsFormsApplication2
{
    class Controller
    {
        Shell shell;
        SessionOptions sessionOptions;
        Session session;
        StocksDownloader stockDownloader;
        ChartsGenerator chartsGenerator;
        public event EventHandler<string> OutputRecived;
        public event EventHandler<double> FileTransferProgress;
        public event EventHandler<string> AnalyzeFileRecived;
        public event EventHandler<bool> DownloadStocks;

        public Controller()
        {
            chartsGenerator = new ChartsGenerator();

        }

        #region conection
        public void CreateNewShell()
        {
            shell = new Shell(session);
            shell.AnalyzeResultsRecived += Shell_AnalyzeResultsRecived;
        }

        public bool Connect(string hostName, int port, string userName, string password)
        {
            sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = hostName,
                UserName = userName,
                Password = password,
                PortNumber = port,
            };
            sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
            sessionOptions.TimeoutInMilliseconds = 120 * 1000;
            session = new Session();

            string pathExe = Directory.GetCurrentDirectory() + PathHelper.winScpExe;
            session.ExecutablePath = pathExe;
            try
            {
                session.Open(sessionOptions);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (session.Opened)
            {
                session.OutputDataReceived += Session_OutputDataReceived;
                CreateNewShell();
                Action<string> dlg = new Action<string>(ExcecuteCommand);
                dlg.BeginInvoke("ls", null, null);
            }

            return session.Opened;
        }

        public void CloseSession()
        {
            if (session != null)
                session.Close();
        }
        #endregion

        #region ShellCommands
        public bool TransferFile(string path)
        {
            return shell.TransferFile(path);
        }

        public bool DownloadFile(string fileName, string path)
        {
            return shell.DownloadFile(fileName, path);
        }

        public void ExcecuteCommand(string command)
        {
            if (shell != null)
                shell.ExcecuteCommand(command);
        }

        public bool AnalyzeProject(string srcFilesPath, string logFilesPath)
        {
            return shell.AnalyzProject(srcFilesPath, logFilesPath, stockDownloader.Config);
        }
        #endregion

        #region StocksDownloads
        public void AnalyzeStocks(MyConfiguration config)
        {
            Action<MyConfiguration> dlg = new Action<MyConfiguration>(AsyncDownloadStocks);
            dlg.BeginInvoke(config, null, null);
        }

        private void AsyncDownloadStocks(MyConfiguration config)
        {
            stockDownloader = new StocksDownloader(config);
            stockDownloader.StockDataRead += Sd_StockDataRead;
            stockDownloader.TotalCompleted += Sd_TotalCompleted;
            string resultPath = Directory.GetCurrentDirectory() + PathHelper.srcPath + PathHelper.resultName;
            try
            {
                NotifyStockProgress(true);
                stockDownloader.DonwloadStocks();
                
            }
            catch (Exception ex)
            {
                Sd_StockDataRead(this, "ERROR" + ex.Message);
            }
            finally
            {
                NotifyStockProgress(false);
                stockDownloader.StockDataRead -= Sd_StockDataRead;
                stockDownloader.TotalCompleted -= Sd_TotalCompleted;
            }
        }

        public void AnalyzeStocksOffline(string path, bool online, MyConfiguration config)
        {
            if (stockDownloader == null)
                stockDownloader = new StocksDownloader(config);
            else
                stockDownloader.Config = config;

            GenerateChartsView(path, online);
        }
        #endregion

        #region Charts
        private void GenerateChartsView(string resultPath, bool online = true)
        {
            if (!File.Exists(resultPath))
                return;

            Dictionary<int, string[]> clusters;

            clusters = chartsGenerator.ReadClusters(resultPath);
            if (!online)
                stockDownloader.DownloadStocksJsonByClusters(clusters);
            UpdateJson(clusters);
        }

        //convert cluster result to json file
        public void UpdateJson(Dictionary<int, string[]> clusters)
        {
            chartsGenerator.GenerateJsonArray(clusters);

            string templateHtml = Directory.GetCurrentDirectory() + PathHelper.chartsDirectory + "\\" + PathHelper.chartHtml;
            string outputHtml = Path.GetDirectoryName(templateHtml) + "\\" + PathHelper.myChartHtml;
            string pathToBatFile = Directory.GetCurrentDirectory() + PathHelper.chartsDirectory + PathHelper.batFile;

            chartsGenerator.EditHtmlFile(null, templateHtml, outputHtml);
            chartsGenerator.EditBatFile(pathToBatFile, outputHtml);

            System.Diagnostics.Process.Start(pathToBatFile);
        }
        #endregion

        #region events
        private void Sd_TotalCompleted(object sender, double e)
        {
            if (FileTransferProgress != null)
                FileTransferProgress(this, e);
        }

        private void Sd_StockDataRead(object sender, string e)
        {
            if (OutputRecived != null)
                OutputRecived(this, e);
        }

        private void Session_OutputDataReceived(object sender, OutputDataReceivedEventArgs e)
        {
            if (OutputRecived != null)
                OutputRecived(this, e.Data);
        }

        private void Session_FileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            if (FileTransferProgress != null)
                FileTransferProgress(this, e.FileProgress);
        }

        private void NotifyStockProgress(bool isRunning)
        {
            if (DownloadStocks != null)
                DownloadStocks(this, isRunning);
        }

        private void Shell_AnalyzeResultsRecived(object sender, string path)
        {
            if (!File.Exists(path))
                return;

            GenerateChartsView(path);
        }
        #endregion
    }
}
