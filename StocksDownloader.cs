using Jarloo.YahooHistoricalLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Ionic.Zip;

namespace WindowsFormsApplication2
{
    class StocksDownloader
    {
        public event EventHandler<string> StockDataRead;
        public event EventHandler<double> TotalCompleted;
        int currentStock;
        MyConfiguration config;
        YahooStocksDownloader yahooDonwloader;
        FilesHelper fileHelper;

        public StocksDownloader(MyConfiguration tConfig)
        {
            config = tConfig;
            yahooDonwloader = new YahooStocksDownloader(config);
            int propNumbers = (config.High ? 1 : 0) + (config.Low ? 1 : 0) + (config.Open ? 1 : 0) + (config.Close ? 1 : 0);
            fileHelper = new FilesHelper(propNumbers);
            fileHelper.Config = config;
            currentStock = 0;
        }
        
        public MyConfiguration Config
        {
            get { return config; }
            set
            {
                config = value;
                fileHelper.Config = value;
            }
        }

        //read stocks names from file and download from web
        public void DonwloadStocks()
        {
            List<String> stocks = fileHelper.GetStockNames(config.NumberOfStocks);
            GetStocksData(stocks);
        }

        //read by clusters for offline view
        public void DownloadStocksJsonByClusters(Dictionary<int, string[]> clusters)
        {
            foreach (int key in clusters.Keys)
            {
                GetStocksData(new List<string>(clusters[key]));
            }
        }

        //download all stocks data from web
        public void GetStocksData(List<String> stocks)
        {
            string zipFile, workingDirectory;
            workingDirectory = Directory.GetCurrentDirectory() + PathHelper.stockDirectory;
            List<HistoricalStock> stockHistory;

            //create new working directory or clear working directory
            if (!Directory.Exists(workingDirectory))
                Directory.CreateDirectory(workingDirectory);
            else
                fileHelper.ClearWorkingDirectory(workingDirectory);

            //download stock info for each stock
            foreach(string stock in stocks)
            {
                NotifyLog("Downloading: "+stock);
                stockHistory = yahooDonwloader.DownloadStocks(stock);
                
                if(stockHistory == null)
                {
                    NotifyProccess();
                    continue;
                }
                NormalizationStock(stockHistory);
                fileHelper.SaveStockData(stockHistory, stock);
                SaveStockDataAsJson(stock, stockHistory);
                NotifyProccess();
            }
            zipFile = Directory.GetCurrentDirectory() + PathHelper.stocksZip;
            fileHelper.CreateZipFile(workingDirectory, zipFile);
        }

        //get stock data and convert to json array
        private void SaveStockDataAsJson(string name, List<HistoricalStock> stockData)
        {
            string content;
            string path;

            path = Directory.GetCurrentDirectory() + PathHelper.jsonPath;
            content = fileHelper.PrepareJsonFile(stockData);
            fileHelper.WriteJsonFile(path, name, content);
        }
        
        //re-calculate vector
        private void NormalizationStock(List<HistoricalStock> stockHistory)
        {
            double maxOpen, minOpen, maxHigh, minHigh, maxLow, minLow, maxClose, minClose;

            maxOpen = double.MinValue;
            maxHigh = double.MinValue;
            maxLow = double.MinValue;
            maxClose = double.MinValue;

            minOpen = double.MaxValue;
            minHigh = double.MaxValue;
            minLow = double.MaxValue;
            minClose = double.MaxValue;

            //find min/max value for each column
            foreach (HistoricalStock history in stockHistory)
            {
                if (config.Open)
                {
                    if (history.Open > maxOpen)
                        maxOpen = history.Open;
                    if (history.Open < minOpen)
                        minOpen = history.Open;
                }
                if (config.Close)
                {
                    if (history.Close > maxClose)
                        maxClose = history.Close;
                    if (history.Close < minClose)
                        minClose = history.Close;
                }
                if (config.High)
                {
                    if (history.High > maxHigh)
                        maxHigh = history.High;
                    if (history.High < minHigh)
                        minHigh = history.High;
                }
                if (config.Low)
                {
                    if (history.Low > maxLow)
                        maxLow = history.Low;
                    if (history.Low < minLow)
                        minLow = history.Low;
                }
            }

            foreach (HistoricalStock history in stockHistory)
            {
                if (config.Open)
                    history.Open = GetNormalizeValue(minOpen, maxOpen, history.Open);
                if (config.Close)
                    history.Close = GetNormalizeValue(minClose, maxClose, history.Close);
                if (config.High)
                    history.High = GetNormalizeValue(minHigh, maxHigh, history.High);
                if (config.Low)
                    history.Low = GetNormalizeValue(minLow, maxLow, history.Low);
            }
        }

        private double GetNormalizeValue(double min, double max, double x)
        {
            return ((x - min) / (max - min));
        }

        #region events
        private void NotifyLog(string str)
        {
            if (StockDataRead != null)
                StockDataRead(this, str);
        }

        private void NotifyProccess()
        {
            currentStock++;
            if (TotalCompleted != null)
                TotalCompleted(this, ((double)currentStock / (double)config.NumberOfStocks) * 100);
        }
        #endregion
    }
}
