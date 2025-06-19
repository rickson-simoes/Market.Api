using Microsoft.EntityFrameworkCore;
using ProductClient.API.Entities;
using ProductClient.API.Infrastructure;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Clients.Shared
{
    public static class FindClientById
    {
        public static async Task<Client> Execute(ProductClientHubDbContext dbContext, Guid id)
        {
            Client? user = await dbContext.Clients
                .Include(f => f.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (user == null)
                throw new ClientNotFoundException("User not found");

            return user;
        }
    }
}
