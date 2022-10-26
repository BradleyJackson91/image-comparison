using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComparriosn.src
{
    internal class FileIO
    {
        internal static void WriteCSV(List<DeepAIComparison> results)
        {
            string filePath = String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "\\ImageComparison");
            string fileName = String.Concat("\\ImageComparisonResults_", DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", ""), ".csv");
            string fullFilePath = String.Concat(filePath, fileName);
            StringBuilder csv = new StringBuilder();

            string newLine = string.Format("{0}, {1}, {2}, {3}", "Image 1", "Image 2", "Result", "Notes");
            csv.AppendLine(newLine);

            foreach (DeepAIComparison r in results)
            {
                newLine = string.Format("{0}, {1}, {2}, {3}", r.img1, r.img2, r.distance.ToString(), r.notes);
                csv.AppendLine(newLine);
            }
            try
            {
                Console.WriteLine(String.Concat("Image Comparison: Writing Results to ", fullFilePath));
                File.WriteAllText(fullFilePath, csv.ToString());
                Console.WriteLine(String.Concat("Image Comparison: Finished Writing Results to ", fullFilePath));
                Console.WriteLine("Would you like to open this file now (Y/N)");
                string openFile = Console.ReadLine() ?? "";
                while (!openFile.ToUpper().Equals("Y") && !openFile.ToUpper().Equals("N"))
                {
                    Console.WriteLine("Please enter either \"Y\" or \"N\""); 
                    openFile = Console.ReadLine() ?? "";
                }
                if (openFile.ToUpper().Equals("Y"))
                {
                    Console.WriteLine("Opening file now.");
                    try
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(fullFilePath)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(String.Concat("Error: It has not been possible to open file ", fullFilePath));
                        System.Environment.Exit(3);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(String.Concat("Error: It has not bee possible to write the results to ", fullFilePath));
                System.Environment.Exit(4);
            }
        }
    }
}
