using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Link
    {
        public int LinkId {get;set;}

        public int ProductId {get;set;}
        
        public Product Product {get;set;}

        public int CategoryId {get;set;}

        public Category Category {get;set;}
    }
}