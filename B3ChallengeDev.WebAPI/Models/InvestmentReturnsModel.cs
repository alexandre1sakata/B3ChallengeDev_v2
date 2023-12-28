namespace B3ChallengeDev.WebAPI.Models
{
    public class InvestmentReturnsModel
    {
        public decimal FinalValue { get; set; }
        public decimal FinalValueWithTaxes { get; set; }

        public InvestmentReturnsModel(decimal finalValue, decimal finalValueWithTaxes)
        {
            FinalValue = finalValue;
            FinalValueWithTaxes = finalValueWithTaxes;
        }
    }
}