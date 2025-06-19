using ProductClient.API.DTOs.Requests;
using ProductClient.API.DTOs.Responses;
using ProductClient.API.Entities;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;

namespace ProductClient.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public async Task<ResponseClientJson> Execute(RequestClientJson request)
        {
            var validator = new RequestClientValidator();
            validator.ValidateClientData(request);

            var dbContext = new ProductClientHubDbContext();

            Client client = new ()
            {
                Name = request.Name,
                Email = request.Email,
            };

            dbContext.Clients.Add(client);
            await dbContext.SaveChangesAsync();

            return new ResponseClientJson { Id = client.Id, Name = client.Name };
        }
    }
}
