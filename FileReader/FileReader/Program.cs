using System;
using System.Configuration;
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
            var filePath = ConfigurationManager.AppSettings["Path"];
            var fileName = Path.GetFileName(filePath);
            Console.WriteLine("CSV File Reader");
            if (fileName.ToLower().StartsWith("lp"))
            {
                var lpFile = new LPFile();
                lpFile.ReadDataFromCsvFile(filePath);
            }
            else if (fileName.ToLower().StartsWith("tou"))
            {
                var touFile = new TOUFile();
                touFile.ReadDataFromCsvFile(filePath);
            }

            //TODO: Get Data from CSV File

            Console.WriteLine("Finish");
            Console.ReadLine();
        }
    }
}
