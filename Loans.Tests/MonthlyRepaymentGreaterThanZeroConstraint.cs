using Loans.Domain.Applications;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    class MonthlyRepaymentGreaterThanZeroConstraint : Constraint
    {
        public MonthlyRepaymentGreaterThanZeroConstraint(string expectedProductName,
                                                         decimal expectedInterestRate)
        {
            ExpectedInterestRate = expectedInterestRate;
            ExpectedProductName = expectedProductName;
        }

        public decimal ExpectedInterestRate { get; private set; }
        public string ExpectedProductName { get; private set; }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            MonthlyRepaymentComparison comparison = actual as MonthlyRepaymentComparison;

            if(comparison is null)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            }

            if(comparison.InterestRate == ExpectedInterestRate &&
                comparison.ProductName == ExpectedProductName &&
                comparison.MonthlyRepayment > 0)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            }

            return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
}
