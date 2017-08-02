using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NodePortable;
using System.IO;

namespace NodeInstallerTests
{
    [TestClass]
    public class MainTests
    {

        static NodeInstaller installer;
        static string installPath = "C:/tests";

        [ClassInitialize()]
        public static void Initiate(TestContext t)
        {
            installer = new NodeInstaller(installPath);
        }

        [TestMethod]
        public void TestCopyNodeBinaryToFolder()
        {
            installer.CopyNodeBinaryToFolder();
            Assert.IsTrue(File.Exists(installPath + "/node.zip"));
        }

        [TestMethod]
        public void TestExtractBinary()
        {
            installer.ExtractBinary();
        }
    }
}
