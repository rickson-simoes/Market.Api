using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll() 
        {
            return Ok();
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
