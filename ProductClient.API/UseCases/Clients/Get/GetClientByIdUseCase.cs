using ProductClient.API.DTOs.Responses;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;

namespace ProductClient.API.UseCases.Clients.Get
{
    public class GetClientByIdUseCase
    {
        public async Task<ResponseAllClientJson> Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var user = await FindClientById.Execute(dbContext, id);

            var response = new ResponseAllClientJson
            {
                Email = user.Email,
                Name = user.Name,
                Products = user.Products
            };

            return response;
        }
    }
}
