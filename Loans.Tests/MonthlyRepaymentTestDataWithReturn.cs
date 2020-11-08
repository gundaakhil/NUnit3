﻿using System;
using System.Collections;
using System.Text;
using Loans.Domain.Applications;
using NUnit.Framework;

namespace Loans.Tests
{
    public class MonthlyRepaymentTestDataWithReturn
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200_000m, 6.5m, 30).Returns(1264.14m);
                yield return new TestCaseData(500_000m, 10m, 30).Returns(4387.86m);
            }
        }
    }
}