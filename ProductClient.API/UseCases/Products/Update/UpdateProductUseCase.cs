using Microsoft.EntityFrameworkCore;
using ProductClient.API.DTOs.Requests;
using ProductClient.API.DTOs.Responses;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Products.Shared;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Products.Update
{
    public class UpdateProductUseCase
    {
        public async Task<ResponseProductJson> Execute(Guid id, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            var validator = new RequestProductValidator();
            validator.ValidateProductData(request);

            product.Name = request.Name;
            product.Brand = request.Brand;
            product.Price = request.Price;

            ResponseProductJson response = new()
            {
                Id = id,
                Name = product.Name,
                Brand = product.Brand,
                Price = product.Price
            };

            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();

            return response;
        }
    }
}
