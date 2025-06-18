using ProductClient.API.Infrastructure;
using ProductClient.Communication.Responses;

namespace ProductClient.API.UseCases.Clients.Get
{
    public class GetAllClientsUseCase
    {
        public IQueryable<ResponseAllClientsJson> Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = dbContext.Clients.Select(client => new ResponseAllClientsJson { 
                Email = client.Email,
                Name = client.Name
            });

            return clients;
        }
    }
}
