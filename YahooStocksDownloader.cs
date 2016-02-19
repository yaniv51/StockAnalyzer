using Jarloo.YahooHistoricalLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class YahooStocksDownloader
    {
        MyConfiguration config;

        public YahooStocksDownloader(MyConfiguration tConfig)
        {
            config = tConfig;
        }

        public List<HistoricalStock> DownloadStocks(string name)
        {
            try
            {
                List<HistoricalStock> stockList = HistoricalStockDownloader.DownloadData(name, config.NumberOfDays, config.Open, config.High, config.Low, config.Close);
                return stockList;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }


    }
}
