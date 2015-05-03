﻿namespace WebShop.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}