using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator;

namespace UnitTestMortgageCalc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(1000, 5, 15, 7.907936267415464)]   //7,907936267415464
        [DataRow(2000, 6, 20, 14.328621169563455)]   //14,328621169563455
        [DataRow(15000, 10, 10, 198.22610532264287)]    //198,22610532264287
        public void computeMonthlyPayment(double principal, double years, double rate, double expected)
        {
            var result = MortgageCalcHelper.ComputeMonthlyPayment(principal,rate, years);
            Assert.AreEqual(expected, result);
        }
    }
}
