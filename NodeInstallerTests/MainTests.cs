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

        [TestMethod]
        public void TestGetUserPathVariable()
        {
            //Assert.AreEqual("success", installer.userEnvVarValue);
            string userPath = installer.userEnvVarValue;
        }

        [TestMethod]
        public void TestSetEnvironmentVariable()
        {
            installer.SetEnvironmentVariable();
            string userPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);

        }

        [TestMethod]
        public void TestGetActualFolder()
        {
            string actualFolder = installer.GetActualFolder();
        }
    }
}
