namespace B3ChallengeDev.WebAPI.Models.Types
{
    public struct TaxCdbStruct
    {
        public const decimal Until6Months = 0.225m;//22,5%
        public const decimal Until12Months = 0.20m;//20%        
        public const decimal Until24Months = 0.175m;//17,5%        
        public const decimal MoreThan24Months = 0.15m;//15%
    }
}