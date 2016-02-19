using System;
using System.Collections.Generic;
using System.Net;

namespace Jarloo.YahooHistoricalLoader
{
    public class HistoricalStockDownloader
    {
        public static List<HistoricalStock> DownloadData(string ticker, int numberOfDays, bool open, bool high, bool low, bool close)
        {
            List<HistoricalStock> retval = new List<HistoricalStock>();
            DateTime startDate = DateTime.Now.AddDays(-numberOfDays);
            using (WebClient web = new WebClient())
            {
                //string data = web.DownloadString(string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&c={1}", ticker, yearToStartFrom));
                //string url =
                //    string.Format(
                //        "http://ichart.yahoo.com/table.csv?s={0}.TW&a={1}&b={2}&c={3}&d=0&e=31&f=2010&g=w&ignore=.csv",
                //        ticker, yearToStartFrom);
                string url =
                    string.Format(
                        "http://ichart.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&ignore=.csv",
                        ticker, startDate.Month-1, startDate.Day, startDate.Year, DateTime.Now.Month-1, DateTime.Now.Day, DateTime.Now.Year);

                string data = web.DownloadString(url);

                //data = data.Replace("r", "");
                data = data.Substring(data.IndexOfAny("0123456789".ToCharArray()));
                //string[] rows = data.Split('n');
                string[] rows = data.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                //First row is headers so Ignore it
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].Replace("n", "").Trim() == "") continue;

                    string[] cols = rows[i].Split(',');

                    HistoricalStock hs = new HistoricalStock();
                    hs.Date = Convert.ToDateTime(cols[0]);
                    if(open)
                        hs.Open = Convert.ToDouble(cols[1]);
                    if(high)
                        hs.High = Convert.ToDouble(cols[2]);
                    if(low)
                        hs.Low = Convert.ToDouble(cols[3]);
                    if(close)
                        hs.Close = Convert.ToDouble(cols[4]);

                    //hs.Volume = Convert.ToDouble(cols[5]);
                    //hs.AdjClose = Convert.ToDouble(cols[6]);

                    retval.Add(hs);
                }

                return retval;
            }
        }
    }
}
