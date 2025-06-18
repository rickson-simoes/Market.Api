using Microsoft.AspNetCore.Mvc;
using ProductClient.API.UseCases.Clients.Get;
using ProductClient.API.UseCases.Clients.Register;
using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;

namespace ProductClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            var useCaseRegister = new RegisterClientUseCase();

            var response = useCaseRegister.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        public IActionResult Update() 
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll() 
        {
            var useCaseGetAll = new GetAllClientsUseCase();

            IQueryable<ResponseAllClientsJson> response = useCaseGetAll.Execute();

            if (response.Count() == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete() 
        {
            return Ok();
        }
    }
}
