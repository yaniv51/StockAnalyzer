using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace WindowsFormsApplication2
{
    class Shell
    {
        Session session;
        public event EventHandler<string> AnalyzeResultsRecived;
        string getIntoDirectory = "cd ";

        public Shell(Session newSession)
        {
            session = newSession;
        }

        public void ExcecuteCommand(string command)
        {
            if(!string.IsNullOrEmpty(command))
                session.ExecuteCommand(command);
        }

        private string ExcecuteCommandWithResult(string command)
        {
            if (!string.IsNullOrEmpty(command))
                return session.ExecuteCommand(command).Output;
            return null;
        }

        public bool DownloadFile(string fileName, string localPath)
        {
            if (!Directory.Exists(localPath))
                throw new Exception("Selected path does not exist");
            if (!session.FileExists(fileName))
                throw new Exception("Remote could not found selected file");
            if (File.Exists(localPath + "\\" + fileName))
                File.Delete(localPath + "\\" + fileName);
            localPath += "\\" + fileName;
            Action<string, string> dlg = new Action<string, string>(DownloadFileAsync);
            dlg.BeginInvoke(fileName,localPath,null, null);
            return true;
        }

        private void DownloadFileAsync(string fileName, string localPath)
        {
            try
            {
                session.GetFiles(fileName, localPath);
                if (fileName.Contains("part-r-0"))
                    if (AnalyzeResultsRecived != null)
                        AnalyzeResultsRecived(this, localPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool TransferFile(string path)
        {
            if (!File.Exists(path))
                return false;
            else
            {
                Action<string> dlg = new Action<string>(TransferFileAsync);
                dlg.BeginInvoke(path, null, null);
                return true;
            }
        }

        public bool AnalyzProject(string srcPath, string logPath, MyConfiguration config)
        {
            
            if (!File.Exists(srcPath))
                return false;
            if (!File.Exists(logPath))
                return false;

            Action<string, string, MyConfiguration> dlg = new Action<string, string, MyConfiguration>(AsycAnalyze);
            dlg.BeginInvoke(srcPath, logPath, config, null, null);
            return true;
            
        }

        public void AsycAnalyze(string srcPath, string logPath, MyConfiguration config)
        {
            string ticks = DateTime.Now.Ticks.ToString();
            string endWith = ticks.Substring(5, 5);
            string newDirName = "Final-" + endWith;
            string inputDirName = "StocksInput-" + newDirName;
            string hadoopDir = newDirName;
            string mkdirCommand = "mkdir " + newDirName;
            string hadoopMkDir = "hadoop fs -mkdir ";
            string outDirName = "output";

            ExcecuteCommandWithResult(mkdirCommand);
            ExcecuteCommandWithResult(getIntoDirectory + newDirName);
            TransferFileAsync(srcPath);
            TransferFileAsync(logPath);

            //create hadoop main EX directory
            ExcecuteCommandWithResult(hadoopMkDir + "/user/"+hadoopDir);
            UnzipCommand(srcPath, PathHelper.linuxWorkingDirectory);
            //transfer log files to hadoop
            TransferFilesToHadoop(logPath, inputDirName, hadoopDir);
            //compile and run
            CompileAndRun(newDirName, inputDirName, outDirName, config);
            //get and show output file
            GetAnalyzeResults(newDirName, outDirName);
        }

        private void TransferFilesToHadoop(string logPath, string logDir,string hadoopDir)
        {
            //unzip
            UnzipCommand(logPath, logDir);
            //transfer
            string putCommand = string.Format("hadoop fs -put {0} /user/{1}/{0}", logDir, hadoopDir);
            ExcecuteCommandWithResult(putCommand);
        }

        private void UnzipCommand(string zipPath, string newDirectory)
        {
            string unzipCommand = string.Format("unzip {0} -d {1}", Path.GetFileName(zipPath), newDirectory);
            ExcecuteCommandWithResult(unzipCommand);
        }

        private void CompileAndRun(string directoryName, string logDirHadoop, string outDir, MyConfiguration config)
        {
            string hadoopClassPath = "export HCP=`hadoop classpath`";
            string getIntoWorkingDirectory = getIntoDirectory + PathHelper.linuxWorkingDirectory;
            string compileJava = "javac -classpath $HCP Run/*.java model/*.java mapreduce/*.java";
            ExcecuteCommandWithResult(getIntoWorkingDirectory);
            ExcecuteCommandWithResult("ls");
            ExcecuteCommandWithResult(hadoopClassPath);
            ExcecuteCommandWithResult(compileJava);
            //make jar
            string jarCompress = "jar cvf final.jar  Run/*.class model/*.class mapreduce/*.class";
            ExcecuteCommandWithResult(jarCompress);
            string runHadoopJar = string.Format("hadoop jar final.jar Run.MyJob /user/{0}/{1} /user/{0}/{2} {3} {4} {5}", directoryName, logDirHadoop, outDir, config.Cluster, config.T1, config.T2);

            ExcecuteCommand(runHadoopJar);
        }

        private void GetAnalyzeResults(string exDirName ,string outDirName)
        {
            string hadoopGetCommand = string.Format("hadoop fs -get /user/{0}/{1}", exDirName, outDirName);
            ExcecuteCommand(hadoopGetCommand);
            ExcecuteCommand(getIntoDirectory + outDirName);
            string localPath = Directory.GetCurrentDirectory() + "\\SRC";
            string fileName = "part-r-00000";
            DownloadFile(fileName, localPath);
        }

        private void TransferFileAsync(string path)
        {
            string fileName = Path.GetFileName(path);
            session.PutFiles(path, fileName, true, null);
        }
    }
}
