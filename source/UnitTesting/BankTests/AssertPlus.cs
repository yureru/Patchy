using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BankTests
{
    public class AssertPlus
    {
        // Allows similar functionality of Assert.AreEqual(double, double, double, string)
        public static void AreEqual(decimal expected, decimal actual, decimal delta, string message)
        {
            // expected and actual are different by a mayor difference of delta
            if (Math.Abs(expected - actual) > delta)
            {
                Assert.Fail(message);
            }
        }
    }
}
