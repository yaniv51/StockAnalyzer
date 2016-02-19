using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication2
{
    public class ChartsGenerator
    {

        public void EditBatFile(string path, string htmlPath)
        {
            using (FileStream fs = File.Open(path, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(htmlPath);
            }
        }

        //replace stocks name in HTML file
        public void EditHtmlFile(List<String> stocksNames, string templateHtml, string outputHtml)
        {
            ReplaceTextInFile(templateHtml, outputHtml, PathHelper.htmlRegax, string.Empty);
        }

        private void ReplaceTextInFile(string originalFile, string outputFile, string searchTerm, string replaceTerm)
        {
            string tempLineValue;
            if (File.Exists(outputFile))
                File.Delete(outputFile);
            File.Create(outputFile).Close();

            //replace the regax with our new stocks names
            using (FileStream inputStream = File.OpenRead(originalFile))
            {
                using (StreamReader inputReader = new StreamReader(inputStream))
                {
                    using (StreamWriter outputWriter = File.AppendText(outputFile))
                    {
                        while (null != (tempLineValue = inputReader.ReadLine()))
                        {
                            outputWriter.WriteLine(tempLineValue.Replace(searchTerm, replaceTerm));
                        }
                    }
                }
            }
        }

        public void GenerateJsonArray(Dictionary<int, string[]> clusters)
        {
            string path, jsonPath;
            int counter;
            StringBuilder sb;
            StreamWriter sw;

            jsonPath = Directory.GetCurrentDirectory() + PathHelper.chartsDirectory + "\\" + PathHelper.stocksJsonFile;
            sb = new StringBuilder();
            path = Directory.GetCurrentDirectory() + PathHelper.jsonPath;
            if (File.Exists(jsonPath))
                File.Delete(jsonPath);
            File.Create(jsonPath).Close();
            sw = File.AppendText(jsonPath);

            counter = 0;
            sb.Append("[");
            foreach (int key in clusters.Keys)
            {
                sb.Append("[");
                sb.Append(ReadMultipleJsonFiles(path, clusters[key]));
                sb.Append("]");
                if (counter != clusters.Count - 1)
                    sb.Append(",");
                counter++;

                sw.Write(sb.ToString() + "\n");
                sb.Clear();
            }
            sb.Append("]");
            sw.Write(sb.ToString());
            sb.Clear();
            sw.Close();
        }

        //read json files by cluster names and merge for one string
        private string ReadMultipleJsonFiles(string path, string[] names)
        {
            StringBuilder sb = new StringBuilder();
            bool firstIter = true;

            foreach (string stockName in names)
            {
                if (string.IsNullOrEmpty(stockName))
                    continue;
                if (!firstIter)
                    sb.Append(",\n");
                else
                    firstIter = false;
                sb.Append(ReadJsonFileToSttring(path, stockName));
            }
            return sb.ToString();
        }

        //read single json file to string
        private String ReadJsonFileToSttring(string path, string name)
        {
            if (String.IsNullOrEmpty(name))
                return String.Empty;
            string currentPath;
            StringBuilder sb;
            string line;
            currentPath = path + "\\" + name + PathHelper.jsonExt;
            if (!File.Exists(currentPath))
                return String.Empty;

            sb = new StringBuilder();
            sb.Append("{\"name\":\"" + name + "\",\"data\":");
            using (FileStream fs = File.Open(currentPath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        public Dictionary<int, string[]> ReadClusters(string resultPath)
        {
            Dictionary<int, string[]> clusters;
            int clusterCounter;
            string[] currentResult, currentClusterStocks;
            string line;

            clusters = new Dictionary<int, string[]>();
            clusterCounter = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(resultPath);
            //generate clusters from result
            while ((line = file.ReadLine()) != null)
            {
                currentResult = line.Split('\t');
                if (currentResult.Length < 1)
                    continue;
                currentClusterStocks = currentResult[1].Split(',');
                clusterCounter++;
                clusters.Add(clusterCounter, currentClusterStocks);
            }
            file.Close();

            return clusters;
        }
    }
}
