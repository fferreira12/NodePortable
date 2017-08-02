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


        public NodeInstaller(string installationPath)
        {

            InstallationPath = installationPath;
            fullName = InstallationPath + "/node.zip";

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

    }
}
