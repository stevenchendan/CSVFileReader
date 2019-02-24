using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using FileReader.Models;

namespace FileReader.Test
{
    public class FileReaderTest
    {
        [Fact]
        public void CalculateMedianTest()
        {
            var file = new CSVFile();
            var valueListOdd = new List<double>() { 1, 2 };
            var valueListEven = new List<double>() { 1, 2, 3 };
            var medianValueOdd = file.CalculateMedian(valueListOdd);
            var medianValueEven = file.CalculateMedian(valueListEven);
            Assert.Equal(1.5, medianValueOdd);
            Assert.Equal(2, medianValueEven);
        }
    }
}
