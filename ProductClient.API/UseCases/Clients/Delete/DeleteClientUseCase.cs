using ProductClient.API.Entities;
using ProductClient.API.Infrastructure;
using ProductClient.API.UseCases.Clients.Shared;

namespace ProductClient.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public async Task Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();
            Client user = await FindClientById.Execute(dbContext, id);

            dbContext.Clients.Remove(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
