using B3ChallengeDev.WebAPI.Models;

namespace B3ChallengeDev.WebAPI.Services.Interfaces
{
    interface IInvestmentService
    {
        InvestmentReturnsModel CalculateCDBReturns(CdbModel cdbValues);
    }
}
