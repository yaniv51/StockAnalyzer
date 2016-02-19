using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Jarloo.YahooHistoricalLoader;
using Ionic.Zip;

namespace WindowsFormsApplication2
{
    public class FilesHelper
    {
        int currentFileRows;
        int currentFile;
        private int maxRowsInFile = 10;
        string stocksWorkingDirectory, fileName;
        int propNumbers, currentStock;
        MyConfiguration config;


        public FilesHelper(int propertiesNumber)
        {
            fileName = "stocks_";
            stocksWorkingDirectory = Directory.GetCurrentDirectory() + PathHelper.stockDirectory;
            currentFileRows = 0;
            currentFile = 0;
            propNumbers = propertiesNumber;
            currentStock = 0;
        }

        public MyConfiguration Config
        {
            get { return config; }
            set { config = value; }
        }

        public void SaveStockData(List<HistoricalStock> stocks, string stockName)
        {
            string currentFilePath;
            StreamWriter sw;

            if (currentFileRows > maxRowsInFile - 1)
            {
                currentFileRows = 0;
                currentFile++;
            }

            currentFilePath = stocksWorkingDirectory + "\\" + fileName + currentFile.ToString() + PathHelper.txtExtention;

            //if not exist, create file and close
            if (!File.Exists(currentFilePath))
                (File.Create(currentFilePath)).Close();

            sw = File.AppendText(currentFilePath);

            StringBuilder sb = new StringBuilder();
            sb.Append(stockName + ",");
            sb.Append(propNumbers.ToString() + ",");
            if (config.Open)
                sb.Append("O,");
            if (config.High)
                sb.Append("H,");
            if (config.Low)
                sb.Append("L,");
            if (config.Close)
                sb.Append("C");
            sb.Append("|");
            sw.Write(sb.ToString());
            sb.Clear();
            foreach (HistoricalStock historyStock in stocks)
            {
                if (config.Open)
                    sb.Append(historyStock.Open.ToString() + ",");
                if (config.High)
                    sb.Append(historyStock.High.ToString() + ",");
                if (config.Low)
                    sb.Append(historyStock.Low.ToString() + ",");
                if (config.Close)
                    sb.Append(historyStock.Close.ToString() + ",");

                sb.Append(";");
            }
            sw.Write(sb.ToString() + "\n");
            sw.Close();
            sb.Clear();
            currentFileRows++;
        }


        public void ClearWorkingDirectory(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public void CreateZipFile(string folderPath, string zipPath)
        {
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(folderPath);
                zip.Save(zipPath);
            };
        }

        public void WriteJsonFile(string path, string name, string content)
        {
            string currentPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            currentPath = path + "\\" + name + PathHelper.jsonExt;
            if (File.Exists(currentPath))
                File.Delete(currentPath);
            using (FileStream fs = File.Open(currentPath, FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
            }
        }

        //read stocks name from local path
        public List<String> GetStockNames(int numberOfStocks)
        {
            List<String> stocks = new List<string>();
            string line;
            int index = 0;
            string[] stockInfo;

            //read stocks info from local file
            string stocksPath = Directory.GetCurrentDirectory() + PathHelper.stockListFile;
            System.IO.StreamReader file = new System.IO.StreamReader(stocksPath);

            while ((line = file.ReadLine()) != null)
            {
                //ignore first line
                if (index == 0)
                {
                    index++;
                    continue;
                }

                stockInfo = line.Split('|');
                stocks.Add(stockInfo[0]);
                if (index == numberOfStocks)
                    break;
                index++;
            }

            file.Close();
            return stocks;
        }

        //convers historical stock to json file
        public String PrepareJsonFile(List<HistoricalStock> stockHistory)
        {
            HistoricalStock history;
            StringBuilder sb = new StringBuilder();
            bool firstIter = true;
            sb.Append("[");
            for (int index = stockHistory.Count - 1; index > -1; index--)
            {
                history = stockHistory[index];
                if (!firstIter)
                    sb.Append(",");
                else
                    firstIter = false;

                sb.Append("[" + history.UnixTimeStampUTC.ToString() + ",");
                sb.Append(history.GetAvgAsString(config.Open, config.High, config.Low, config.Close));
                sb.Append("]");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
