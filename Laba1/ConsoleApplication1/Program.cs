using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            string dir = Environment.CurrentDirectory + "\\..\\..\\..\\Laba1\\bin\\Debug\\";
            p.StartInfo.FileName = dir + "Laba1.exe";

            string[] pars = new string[]{
                "1.txt 11.txt",
                "empty.txt emptyTest.txt",
                "RAR.txt notExists.txt"
            };

            foreach (string par in pars)
            {
                p.StartInfo.Arguments = par;
                p.Start();
                p.Close();
            }
        }
    }
}
