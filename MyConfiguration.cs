using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class MyConfiguration
    {
        public int Cluster { get; set; }
        public int NumberOfStocks { get; set; }
        public int NumberOfDays { get; set; }
        public bool High { get; set; }
        public bool Low { get; set; }
        public bool Open { get; set; }
        public bool Close { get; set; }
        private float t1Original, t2Original, t1, t2;
        private int minimumDays, minimumParams;
        private int numberOfParams;

        public MyConfiguration()
        {
            t1Original = 8.0f;
            t2Original = 1.0f;
            minimumDays = 30;
            minimumParams = 1;
            numberOfParams = 0;
            t1 = -1;
            t2 = -1;
        }

        public MyConfiguration(int tClusters, int tNumOfStocks, int tNumOfDays, bool tOpen, bool tClose, bool tHigh, bool tLow) : this()
        {
            Cluster = tClusters;
            NumberOfDays = tNumOfDays;
            NumberOfStocks = tNumOfStocks;
            
            High = tHigh;
            if (tHigh)
                numberOfParams++;
            Low = tLow;
            if (tLow)
                numberOfParams++;
            Close = tClose;
            if (tClose)
                numberOfParams++;
            Open = tOpen;
            if (tOpen)
                numberOfParams++;
        }

        public float T1
        {
            get
            {
                if(t1 <= 0)
                    return (t1Original * ((NumberOfDays / minimumDays) + (numberOfParams/2) / minimumParams));
                return t1;
            }
            set
            {
                t1 = value;
            }
        }

        public float T2
        {
            get
            {
                if(t2 < 0)
                    return (t2Original * ((NumberOfDays / minimumDays) + (numberOfParams/2) / minimumParams));
                return t2;
            }
            set
            {
                t2 = value;
            }
        }


    }
}
