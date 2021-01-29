using System;
using System.IO;

namespace csUnins
{
    class Program
    {
        static void Main()
        {
            DeleteFiles();
        }
        public static void DeleteFiles()
        {
            string sourceDir = @"c:\games\CounterStrike1.6";
            string copyDir = @"c:\games\cs1.6copy";

            try
            {
                string[] dllList = Directory.GetFiles(sourceDir, "*.dll");
                string[] exeList = Directory.GetFiles(sourceDir, "*.exe");
                //string[] folderFinder = Directory.GetDirectories(sourceDir, "cstrike");
                //string[] folderFinder2 = Directory.GetDirectories(sourceDir, "config");

                foreach (string file in dllList)
                {
                    string fileName = file.Substring(sourceDir.Length + 1);
                    File.Copy(Path.Combine(sourceDir, fileName), Path.Combine(copyDir, fileName), true);
                }

                foreach (string file in exeList)
                {
                    string fileName = file.Substring(sourceDir.Length + 1);

                    try
                    {
                        File.Copy(Path.Combine(sourceDir, fileName), Path.Combine(copyDir, fileName), true);
                    }

                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }

                foreach (string f in dllList)
                {
                    File.Delete(f);
                }

                foreach (string f in exeList)
                {
                    File.Delete(f);
                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }
    }
}