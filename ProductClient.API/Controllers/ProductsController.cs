using Microsoft.AspNetCore.Mvc;
using ProductClient.API.DTOs.Requests;
using ProductClient.API.DTOs.Responses;
using ProductClient.API.UseCases.Products.Delete;
using ProductClient.API.UseCases.Products.Register;
using ProductClient.API.UseCases.Products.Update;

namespace ProductClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromRoute] Guid id, [FromBody] RequestProductJson request)
        {
            var registerUseCase = new RegisterProductUseCase();
            var response = await registerUseCase.Execute(id, request);

            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteUseCase = new DeleteProductUseCase();

            await deleteUseCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RequestProductJson req)
        {
            var updateUseCase = new UpdateProductUseCase();

            var response = await updateUseCase.Execute(id, req);

            return Ok(response);
        }
    }
}
