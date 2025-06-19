using ProductClient.API.Entities;

namespace ProductClient.API.DTOs.Responses
{
    public class ResponseAllClientJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>(); // collection navigation containing dependents
    }
}
