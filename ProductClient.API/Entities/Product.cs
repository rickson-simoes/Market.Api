﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProductClient.API.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClientId { get; set; }
    }
}
