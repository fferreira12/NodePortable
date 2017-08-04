using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodePortable
{
    public class NodeInstaller
    {

        string InstallationPath { get; set; }
        byte[] Node = Properties.Resources.node;
        string fullName;
        string nodePath, npmPath;
        public string userEnvVarValue { get; set; }
        string runningFolder;


        public NodeInstaller(string installationPath = "")
        {
            if (installationPath != "")
            {
                InstallationPath = installationPath; 
            } else
            {
                InstallationPath = GetActualFolder();
            }
            fullName = InstallationPath + "/node.zip";
            nodePath = InstallationPath + @"/node";
            npmPath = InstallationPath + @"/npm";
            userEnvVarValue = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
        }

        public void CopyNodeBinaryToFolder()
        {
            if (!File.Exists(fullName))
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fullName, FileMode.Create)))
                {
                    writer.Write(Node);
                } 
            }
        }

        public void ExtractBinary()
        {
            ZipFile.ExtractToDirectory(fullName, InstallationPath);
        }

        public void SetEnvironmentVariable()
        {
            string totalPath = userEnvVarValue + ";" + nodePath + ";" + npmPath;

            Environment.SetEnvironmentVariable("Path", totalPath, EnvironmentVariableTarget.User);

        }

        public string GetActualFolder()
        {
            runningFolder = AppDomain.CurrentDomain.BaseDirectory;
            return runningFolder;
        }


        public bool Install()
        {
            try
            {
                CopyNodeBinaryToFolder();
                ExtractBinary();
                SetEnvironmentVariable();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
