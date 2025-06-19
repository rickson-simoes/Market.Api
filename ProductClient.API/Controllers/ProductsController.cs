using Microsoft.AspNetCore.Mvc;
using ProductClient.API.DTOs.Requests;
using ProductClient.API.DTOs.Responses;
using ProductClient.API.UseCases.Products.Register;

namespace ProductClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RequestProductJson request)
        {
            var registerUseCase = new RegisterProductUseCase();
            var response = await registerUseCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
