using ProductClient.API.DTOs.Requests;
using ProductClient.API.DTOs.Responses;
using ProductClient.API.Entities;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;
using ProductClient.API.UseCases.Products.Shared;

namespace ProductClient.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public async Task<ResponseProductJson> Execute(Guid id, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            var validator = new RequestProductValidator();
            validator.ValidateProductData(request);

            // Todo: change decimal to int
            var product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = id
            };

            await FindClientById.Execute(dbContext, product.ClientId);

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            ResponseProductJson response = new ()
            {
                Name = product.Name,
                Brand = product.Brand,
                Price = product.Price,
                Id = product.Id
            };

            return response;
        }
    }
}
