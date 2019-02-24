using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using FileReader.Models;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = ConfigurationManager.AppSettings["Path"];
            var fileName = Path.GetFileName(filePath);
            Console.WriteLine("CSV File Reader");
            if (fileName.ToLower().StartsWith("lp"))
            {
                var lpFile = new LPFile();
                lpFile.ReadDataFromCsvFile(filePath);
                //get median value and then print value
                lpFile.DataValueList.RemoveAt(0);
                //convert string to double
                List<double> result = lpFile.DataValueList.Select(x => double.Parse(x)).ToList();
                var median = lpFile.CalculateMedian(result);
            }
            else if (fileName.ToLower().StartsWith("tou"))
            {
                var touFile = new TOUFile();
                touFile.ReadDataFromCsvFile(filePath);
                List<double> result = touFile.EnergyList.Select(x => double.Parse(x)).ToList();
                var median = touFile.CalculateMedian(result);
                //get median value and then print value
            }

            Console.WriteLine("Finish the program by pressing Enter Key");
            Console.ReadLine();
        }
    }
}
