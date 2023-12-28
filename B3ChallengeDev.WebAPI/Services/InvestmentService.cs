using B3ChallengeDev.WebAPI.Services.Interfaces;
using B3ChallengeDev.WebAPI.Models;
using System;

namespace B3ChallengeDev.WebAPI.Services
{
    public class InvestmentService : IInvestmentService
    {
        public InvestmentReturnsModel CalculateCDBReturns(CdbModel cdbValues)
        {
            decimal result = cdbValues.InitialValue;
            int rescueMonths = cdbValues.RescueMonths;

            decimal cdi = cdbValues.GetValueOfCdi();
            decimal tb = cdbValues.GetValueOfTb();

            result = CalculateCdbWithFormula(result, rescueMonths, cdi, tb);

            decimal taxByMonth = cdbValues.GetTaxByMonth();

            decimal resultWithTax = CalculateTax(result, taxByMonth);

            (decimal finalValue, decimal finalValueWithTax) = GetFinalValuesRounded(result, resultWithTax);

            return new InvestmentReturnsModel(finalValue, finalValueWithTax);
        }

        #region Private Methods

        private decimal CalculateCdbWithFormula(decimal result, int rescueMonths, decimal cdi, decimal tb)
        {
            for (int i = 0; i < rescueMonths; i++)
            {
                result *= (1 + cdi * tb);
            }

            return result;
        }

        private decimal CalculateTax(decimal result, decimal taxesByMonth)
        {
            return result * (1 - taxesByMonth);
        }

        private (decimal, decimal) GetFinalValuesRounded(decimal result, decimal resultWithTax)
        {
            decimal factor = (decimal)Math.Pow(10, 2);
            decimal finalValue = Math.Round(result * factor) / factor;
            decimal finalValueWithTax = Math.Round(resultWithTax * factor) / factor;

            return (finalValue, finalValueWithTax);
        }

        #endregion
    }
}