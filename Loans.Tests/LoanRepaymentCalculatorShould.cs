﻿using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000,6.5,30,1264.14)]
        [TestCase(200_000,10,30,1755.14)]
        [TestCase(500_000,10,30,4387.86)]
        public void CalculateCorrectMonthlyRepayment(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears,
                                                     decimal expectedMontlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var montlyPayment = sut.CalculateMonthlyRepayment(
                                    new LoanAmount("USD", principal), interestRate,
                                    new LoanTerm(termInYears));

            Assert.That(montlyPayment, Is.EqualTo(expectedMontlyPayment));
        }


        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                       new LoanAmount("USD", principal), interestRate,
                       new LoanTerm(termInYears));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CalculateCorrectMonthlyRepayment_Centralized(decimal principal,
                                             decimal interestRate,
                                             int termInYears,
                                             decimal expectedMontlyRepayment)
        {
            var sut = new LoanRepaymentCalculator();

            var montlyRepayment = sut.CalculateMonthlyRepayment(
                       new LoanAmount("USD", principal), interestRate,
                       new LoanTerm(termInYears));

            Assert.That(montlyRepayment, Is.EqualTo(expectedMontlyRepayment));
        }

        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn),"TestCases")]
        public decimal CalculateCorrectMonthlyRepayment_CentralizedReturnTestCase(decimal principal,
                                             decimal interestRate,
                                             int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                       new LoanAmount("USD", principal), interestRate,
                       new LoanTerm(termInYears));
        }


        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases", new object[] { "Data.csv" })]
        public void CalculateCorrectMonthlyRepayment_Csv(decimal principal,
                                     decimal interestRate,
                                     int termInYears,
                                     decimal expectedMontlyRepayment)
        {
            var sut = new LoanRepaymentCalculator();

            var montlyRepayment = sut.CalculateMonthlyRepayment(
                       new LoanAmount("USD", principal), interestRate,
                       new LoanTerm(termInYears));

            Assert.That(montlyRepayment, Is.EqualTo(expectedMontlyRepayment));
        }

        [Test]
        public void CalculateCorrectMonthlyRepayment_Combinatorial(
            [Values(100_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 30)]decimal interestRate,
            [Values(10, 20, 30)]int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }

        [Test]
        [Sequential]
        public void CalculateCorrectMonthlyRepayment_Sequential(
            [Values(100_000, 200_000, 500_000)] decimal principal,
            [Values(6.5, 10, 30)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears,
            [Values(1135.48, 1930.04, 12501.72)]decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }


        [Test]
        public void CalculateCorrectMonthlyRepayment_Range(
            [Range(50_000, 1_000_000, 50_000)] decimal principal,
            [Range(0.5, 20.0, 0.5)] decimal interestRate,
            [Values(10, 20, 30)] int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        }
    }
}
