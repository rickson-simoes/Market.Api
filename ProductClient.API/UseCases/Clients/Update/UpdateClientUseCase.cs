using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;
using ProductClient.Communication.Requests;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public async Task Execute(Guid id, RequestClientJson request)
        {
            var dbContext = new ProductClientHubDbContext();

            var user = await FindClientById.Execute(dbContext, id);

            var validator = new RequestClientValidator();
            validator.ValidateClientData(request);

            user.Name = request.Name;
            user.Email = request.Email;

            dbContext.Clients.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
