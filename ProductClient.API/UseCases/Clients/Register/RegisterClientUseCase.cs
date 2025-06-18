using ProductClient.API.Entities;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;
using ProductClient.Communication.Requests;
using ProductClient.Communication.Responses;

namespace ProductClient.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var validator = new RequestClientValidator();
            validator.ValidateClientData(request);

            var dbContext = new ProductClientHubDbContext();

            Client client = new Client
            {
                Name = request.Name,
                Email = request.Email,
            };

            dbContext.Clients.Add(client);
            dbContext.SaveChanges();

            return new ResponseClientJson { Id = client.Id, Name = client.Name };
        }
    }
}
