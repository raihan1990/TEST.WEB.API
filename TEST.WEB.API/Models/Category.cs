﻿namespace TEST.WEB.API.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
