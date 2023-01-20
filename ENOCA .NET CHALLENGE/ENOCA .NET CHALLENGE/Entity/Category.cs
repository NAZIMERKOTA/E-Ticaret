using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ENOCA.NET_CHALLENGE.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(maximumLength:20,ErrorMessage = "max 20 letter")]
        public string Name { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "max 100 letter")]
        public string Description { get; set; }

        public List<Product> Products { get; set;}

    }
}