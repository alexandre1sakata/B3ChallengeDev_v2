using B3ChallengeDev.WebAPI.Models.Types;

namespace B3ChallengeDev.WebAPI.Models
{
    public class CdbModel : InvestmentModel
    {
        const decimal Percentage_TB = 108;
        const decimal Percentage_CDI = 0.9m;

        public CdbModel(decimal initialValue, int rescueMonths)
            : base(initialValue, rescueMonths) { }

        public decimal GetValueOfTb() => Percentage_TB / 100;
        public decimal GetValueOfCdi() => Percentage_CDI / 100;

        public decimal GetTaxByMonth()
        {
            switch (RescueMonths)
            {
                case var months when months <= 6:
                    return TaxCdbStruct.Until6Months;
                case var months when months <= 12:
                    return TaxCdbStruct.Until12Months;
                case var months when months <= 24:
                    return TaxCdbStruct.Until24Months;
                default:
                    return TaxCdbStruct.MoreThan24Months;
            }
        }
    }
}