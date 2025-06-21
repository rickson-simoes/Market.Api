using Microsoft.EntityFrameworkCore;
using ProductClient.API.Infrastructure;
using ProductClient.Exceptions.ExceptionsBase;

namespace ProductClient.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public async Task Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();

            var product = await dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            if (product is null)
                throw new ProductNotFoundException("Product not found");

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
