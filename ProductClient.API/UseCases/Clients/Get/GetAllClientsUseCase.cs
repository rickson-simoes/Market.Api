using Microsoft.EntityFrameworkCore;
using ProductClient.API.Infrastructure;
using ProductClient.Communication.Responses;

namespace ProductClient.API.UseCases.Clients.Get
{
    public class GetAllClientsUseCase
    {
        public async Task<List<ResponseAllClientJson>> Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = await dbContext.Clients.Select(client => new ResponseAllClientJson { 
                Email = client.Email,
                Name = client.Name
            }).ToListAsync();

            return clients;
        }
    }
}
