﻿namespace Raze.Api.Domain.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        
        //TODO - Relationships with users
    }
}