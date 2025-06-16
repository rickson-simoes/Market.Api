using System.ComponentModel.DataAnnotations.Schema;

namespace ProductClient.API.Entities
{

    [Table("Products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClientId { get; set; }
    }
}
