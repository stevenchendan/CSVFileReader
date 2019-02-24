using System;
using System.IO;
using System.Net.Sockets;
using FileReader.Models;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: make read file configurable
            var path = @"C:\dev\codingTest\LP_210095893_20150901T011608049.csv";
            var fileName = Path.GetFileName(path);
            Console.WriteLine("CSV File Reader");
            if (fileName.ToLower().StartsWith("lp"))
            {
                var lpFile = new LPFile();
                lpFile.ReadDataFromCsvFile(path);
            }
            else if (fileName.ToLower().StartsWith("tou"))
            {
                var touFile = new TOUFile();
                touFile.ReadDataFromCsvFile(path);
            }

            //TODO: Get Data from CSV File

            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}
