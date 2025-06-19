using Microsoft.EntityFrameworkCore;
using ProductClient.API.Infrastructure;
using ProductClient.API.DTOs.Responses;

namespace ProductClient.API.UseCases.Clients.Get
{
    public class GetAllClientsUseCase
    {
        public async Task<List<ResponseAllClientJson>> Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = await dbContext.Clients
                .Include(client => client.Products)
                .Select(client => new ResponseAllClientJson
                {
                    Email = client.Email,
                    Name = client.Name,
                    Products = client.Products
                }).ToListAsync();

            return clients;
        }
    }
}
