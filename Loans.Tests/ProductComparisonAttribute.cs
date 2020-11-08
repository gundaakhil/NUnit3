using System;
using NUnit.Framework;

namespace Loans.Tests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    class ProductComparisonAttribute : CategoryAttribute
    {

    }
}
