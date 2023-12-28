using B3ChallengeDev.WebAPI.Models;
using B3ChallengeDev.WebAPI.Models.Types;
using B3ChallengeDev.WebAPI.Services;
using NUnit.Framework;
using System;
using System.Reflection;

namespace B3ChallengeDev.WebAPI.UnitTests
{
    [TestFixture]
    public class InvestmentServiceTests
    {
        private readonly InvestmentService investmentService;

        public InvestmentServiceTests()
        {
            investmentService = new InvestmentService();
        }

        [Test]
        public void CalculateCDBReturns_CalculateSuccess()
        {
            var cdbValues = new CdbModel(1000, 5);

            var result = investmentService.CalculateCDBReturns(cdbValues);

            Assert.IsNotNull(result);
            Assert.AreEqual(1049.55, result.FinalValue);
            Assert.AreEqual(813.4, result.FinalValueWithTaxes);
        }

        [Test]
        public void CalculateCDBReturns_WithInitialValueZero()
        {
            var cdbValues = new CdbModel(0, 5);

            var result = investmentService.CalculateCDBReturns(cdbValues);

            Assert.IsNotNull(result);
            Assert.Zero(result.FinalValue);
            Assert.Zero(result.FinalValueWithTaxes);
        }

        [Test]
        public void CalculateCDBReturns_WithRescueMonthsZero()
        {
            var cdbValues = new CdbModel(1000, 0);

            var result = investmentService.CalculateCDBReturns(cdbValues);

            Assert.IsNotNull(result);
            Assert.AreEqual(1000, result.FinalValue);
            Assert.AreEqual(775, result.FinalValueWithTaxes);
        }

        [Test]
        public void CalculateCdbWithFormula_ReturnsExpectedValue()
        {
            var cdbValues = new CdbModel(1000, 12);
            decimal cdi = cdbValues.GetValueOfCdi();
            decimal tb = cdbValues.GetValueOfTb();

            var result = InvokePrivateMethod<decimal>(
                investmentService, 
                "CalculateCdbWithFormula", 
                cdbValues.InitialValue, 
                cdbValues.RescueMonths, 
                cdi, 
                tb);

            Assert.IsNotNull(result);
            Assert.AreEqual(1123.0820949653057631841036240m, result);
        }

        [Test]
        public void CalculateTax_Until6Months()
        {
            decimal result = 1500;
            decimal taxByMonth = TaxCdbStruct.Until6Months;
            var resultWithTax = InvokePrivateMethod<decimal>(investmentService, "CalculateTax", result, taxByMonth);

            Assert.IsNotNull(resultWithTax);
            Assert.AreEqual(1162.500m, resultWithTax);
        }

        [Test]
        public void CalculateTax_Until12Months()
        {
            decimal result = 1500;
            decimal taxByMonth = TaxCdbStruct.Until12Months;
            var resultWithTax = InvokePrivateMethod<decimal>(investmentService, "CalculateTax", result, taxByMonth);

            Assert.IsNotNull(resultWithTax);
            Assert.AreEqual(1200.00m, resultWithTax);
        }

        [Test]
        public void CalculateTax_Until24Months()
        {
            decimal result = 1500;
            decimal taxByMonth = TaxCdbStruct.Until24Months;
            var resultWithTax = InvokePrivateMethod<decimal>(investmentService, "CalculateTax", result, taxByMonth);

            Assert.IsNotNull(resultWithTax);
            Assert.AreEqual(1237.500m, resultWithTax);
        }

        [Test]
        public void CalculateTax_MoreThan24Months()
        {
            decimal result = 1500;
            decimal taxByMonth = TaxCdbStruct.MoreThan24Months;
            var resultWithTax = InvokePrivateMethod<decimal>(investmentService, "CalculateTax", result, taxByMonth);

            Assert.IsNotNull(resultWithTax);
            Assert.AreEqual(1275.00m, resultWithTax);
        }

        [Test]
        public void GetFinalValuesRounded_SuccessResult()
        {
            decimal result = 1500.45367m;
            decimal resultWithTax = 1200.86345m;
            (decimal finalValueRounded, decimal finalValueWithTaxRounded) 
                = InvokePrivateMethod<ValueTuple<decimal, decimal>>(
                    investmentService, 
                    "GetFinalValuesRounded", 
                    result, 
                    resultWithTax);

            Assert.IsNotNull(finalValueRounded);
            Assert.AreEqual(1500.45m, finalValueRounded);

            Assert.IsNotNull(finalValueWithTaxRounded);
            Assert.AreEqual(1200.86m, finalValueWithTaxRounded);
        }

        #region Private Methods

        private T InvokePrivateMethod<T>(object instance, string methodName, params object[] parameters)
        {
            var methodInfo = instance.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo == null)
                throw new InvalidOperationException($"Private method '{methodName}' not found.");

            return (T)methodInfo.Invoke(instance, parameters);
        }

        #endregion
    }
}