using System.ComponentModel.DataAnnotations.Schema;

namespace ProductClient.API.Entities
{
    [Table("Clients")]
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
