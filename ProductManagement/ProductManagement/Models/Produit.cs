﻿using SQLite;

namespace ProductManagement.Models
{
    public class Produit
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
