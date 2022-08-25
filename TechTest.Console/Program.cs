using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Library;

namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                //Console.WriteLine("Enter Physical Path");
                string path = @"C:\Users\Rakesh Pattanayak\Downloads\CSharpTechTest-MariyamEkiya\CSharpTechTest-MariyamEkiya";

                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    //Console.WriteLine("{0} is not a valid file or directory.", path);
                }
                Console.WriteLine("Press Enter to continue");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

        }

        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        public static void ProcessFile(string filename)
        {
            var tradeLoader = new TradeLoader();
            foreach (var trade in tradeLoader.LoadTrades(filename))
            {
                Console.WriteLine(trade);
            }
        }
    }
}
