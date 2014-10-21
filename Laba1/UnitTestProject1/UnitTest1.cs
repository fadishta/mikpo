using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba1;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double a = 100, b = 140, gamma = 90, c = 172.0465;
            double[] res = Program.Calculate(a, b, gamma);
            double[] answer = new double[] { 100, 140, 172.0465, 35.5377, 54.4623, 90 };
            CollectionAssert.AreEqual(answer, res);      
        }


        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundTest()
        {
            Program.ReadFile("../../../Laba1/bin/Debug/14947.txt", "../../../Laba1/bin/Debug/NotFoundTest.txt");
        }
        
        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void FileEmptyTest()
        {
            Program.ReadFile("../../../Laba1/bin/Debug/empty.txt", "../../../Laba1/bin/Debug/emptyTest.txt");
        }

        [TestMethod]
        public void FileTest()
        {
            Program.ReadFile("../../../Laba1/bin/Debug/FileTest.txt", "../../../Laba1/bin/Debug/FileTest2.txt");
            string res = File.ReadAllText("../../../Laba1/bin/Debug/FileTest1.txt");
            string answer = File.ReadAllText("../../../Laba1/bin/Debug/FileTest2.txt");
            Assert.AreEqual(answer, res);
        }

    }
}
