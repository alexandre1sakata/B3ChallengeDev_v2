using B3ChallengeDev.WebAPI.Models;
using B3ChallengeDev.WebAPI.Services;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace B3ChallengeDev.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InvestmentCdbController : ApiController
    {
        private readonly InvestmentService _investmentService;

        public InvestmentCdbController()
        {
            _investmentService = new InvestmentService();
        }

        [HttpPost]
        public IHttpActionResult CalculateCdbReturns([FromBody] CdbModel cdbValues)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = _investmentService.CalculateCDBReturns(cdbValues);

                return Json(result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
