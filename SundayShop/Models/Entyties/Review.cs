﻿namespace SundayShop.Models.Entyties;

public class Review
{
    public int Id { get; set; }
    public int Rate { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedIn { get; set; } = DateTime.Now;
    
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}