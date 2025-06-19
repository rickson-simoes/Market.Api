using Microsoft.AspNetCore.Mvc;
using ProductClient.API.UseCases.Clients.Delete;
using ProductClient.API.UseCases.Clients.Get;
using ProductClient.API.UseCases.Clients.Register;
using ProductClient.API.UseCases.Clients.Update;
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
        public async Task<IActionResult> Register([FromBody] RequestClientJson request)
        {
            var useCaseRegister = new RegisterClientUseCase();

            var response = await useCaseRegister.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
        {
            var useCaseUpdateClient = new UpdateClientUseCase();

            await useCaseUpdateClient.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll() 
        {
            var useCaseGetAll = new GetAllClientsUseCase();

            var response = await useCaseGetAll.Execute();

            if (response.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseAllClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var useCaseGetById = new GetClientByIdUseCase();
            var users = await useCaseGetById.Execute(id);

            return Ok(users);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var useCaseDelete = new DeleteClientUseCase();
            await useCaseDelete.Execute(id);

            return NoContent();
        }
    }
}
