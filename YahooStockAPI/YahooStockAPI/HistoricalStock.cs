using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarloo.YahooHistoricalLoader
{
    public class HistoricalStock
    {

        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }

        public HistoricalStock()
        {
            Open = 0;
            High = 0;
            Low = 0;
            Close = 0;
            Date = DateTime.Now;
        }

        public long  UnixTimeStampUTC
        {
            get
            {
                DateTime utcTime = Date.ToUniversalTime();
                DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return (long)(Date - unixEpoch).TotalMilliseconds;
            }
        }

        public String GetStringArray(bool open, bool high, bool low, bool close)
        {
            StringBuilder sb = new StringBuilder();
            bool isFirst = true;

            if (open)
            {
                sb.Append(Open.ToString());
                if (isFirst)
                {
                    isFirst = false;
                }
            }

            if (high)
            {
                if(!isFirst)
                    sb.Append(",");
                sb.Append(High.ToString());
                if (isFirst)
                {
                    isFirst = false;
                }
            }

            if(low)
            {
                if (!isFirst)
                    sb.Append(",");
                sb.Append(Low.ToString());
                if (isFirst)
                {
                    isFirst = false;
                }
            }

            if(close)
            {
                if (!isFirst)
                    sb.Append(",");
                sb.Append(Close.ToString());
                if (isFirst)
                {
                    isFirst = false;
                }
            }
            return sb.ToString();
        }

        public string GetAvgAsString(bool open, bool high, bool low, bool close)
        {
            double sum;
            int counter;
            counter = 0;
            sum = 0;
            if (open)
            {
                sum += Open;
                counter++;
            }
            if (high)
            {
                sum += High;
                counter++;
            }
            if (low)
            {
                sum += Low;
                counter++;
            }
            if (close)
            {
                sum += Close;
                counter++;
            }
            sum /= counter;
            return sum.ToString();
        }

    }
}
