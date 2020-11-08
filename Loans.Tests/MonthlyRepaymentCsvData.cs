using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Loans.Tests
{
    public class MonthlyRepaymentCsvData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);

            var testCases = new List<TestCaseData>();

            foreach(var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split(',');

                decimal prinicpal = decimal.Parse(values[0]);
                decimal interestRate = decimal.Parse(values[1]);
                int termsInYear = int.Parse(values[2]);
                decimal expectedResult = decimal.Parse(values[3]);

                testCases.Add(new TestCaseData(prinicpal, interestRate, termsInYear, expectedResult));
            }

            return testCases;
        }
    }
}
