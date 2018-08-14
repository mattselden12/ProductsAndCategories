using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        public int ProductId {get;set;}

        public string Name {get;set;}

        public string Description {get;set;}

        public Decimal Price {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt {get;set;}
        

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt {get;set;}

        public List<Link> Links {get;set;}

        public Product(){
            Links = new List<Link>();
        }
    }
}
