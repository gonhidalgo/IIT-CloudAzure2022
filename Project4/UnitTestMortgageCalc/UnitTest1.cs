using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator;

namespace UnitTestMortgageCalc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(10000, 5, 15, 7.91)]
        [DataRow(2000, 6, 20, 14.33)]
        [DataRow(15000, 10, 10, 198.23)]
        public void computeMonthlyPayment(double principal, double years, double rate, double expected)
        {
            var result = MortgageCalcHelper.ComputeMonthlyPayment(principal, years, rate);
            Assert.AreEqual(expected, result);
        }
    }
}
