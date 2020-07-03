using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Insurences.Commands.CreateInsurance;
using Application.Insurences.Commands.DeleteInsurance;
using Application.Insurences.Queries.GetInsuranceDetail;
using Application.Insurences.Queries.GetInsuranceList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : BaseController
    {
        /// <summary>
        /// Return list of all Insurances
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<InsuranceLookupDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetInsuranceListQuery()));
        }

        /// <summary>
        /// Return Insurance by Id on Url
        /// </summary>
        /// <param name="id">Id of Insurance to Search</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InsuranceDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetInsuranceDetailQuery(id)));
        }

        /// <summary>
        /// Calculate and save new Insurance 
        /// </summary>
        /// <param name="command">Insured Cpf, Vehicle Value, Vehicle Model, Vehicle Manufacture</param>
        /// <returns>Return id from Insurance saved</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInsuranceCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        /// <summary>
        /// Delete Insurance based on Id on Url
        /// </summary>
        /// <param name="id">Id of Insurance to Delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteInsuranceCommand(id));

            return NoContent();
        }
    }
}
