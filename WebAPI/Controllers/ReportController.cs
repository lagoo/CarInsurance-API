using System.Threading.Tasks;
using Application.Insurences.Queries.GetInsuranceArithmeticAverage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        /// <summary>
        /// Return report of Insurance Arithmetic Average 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Insurance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InsuranceArithmeticAverageVm>> Insurance()
        {
            return Ok(await Mediator.Send(new GetInsuranceArithmeticAverageQuery()));
        }
    }
}
