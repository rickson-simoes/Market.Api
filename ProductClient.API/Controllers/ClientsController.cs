using Microsoft.AspNetCore.Mvc;
using ProductClient.API.UseCases.Clients.Register;
using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCaseRegister = new RegisterClientUseCase();

                var response = useCaseRegister.Execute(request);

                return Created(string.Empty, response);
            } 
            catch (ProductClientHubException err)
            {
                List<string> errors = err.GetErrors();

                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson(err.Message));
            }
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
