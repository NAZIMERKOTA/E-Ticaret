using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ENOCA.NET_CHALLENGE.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var catagories = new List<Category>()
            {
                new Category(){ Name= "Kamera", Description="Kamera ürünleri"},
                new Category(){ Name= "Bilgisayar", Description="Bilgisayar ürünleri"},
                new Category(){ Name= "Elektronik", Description="Elektronik ürünleri"},
                new Category(){ Name= "Telefon", Description="Telefon ürünleri"},
                new Category(){ Name= "Kulaklık", Description="Kulaklık ürünleri"}

            };

            foreach (var catagory in catagories)
            {
                context.Categories.Add(catagory);
            }

            var products = new List<Product>()
            {
                new Product(){Name="a Fotoğraf makinesi",Description="a Fotoğraf makinesi",Price=1200, IsApproved=true,CategoryId=1,Stock=132,IsHome=true,Image="1.jpg"},
                new Product(){Name="b Fotoğraf makinesi",Description="b Fotoğraf makinesi",Price=100, IsApproved=false,CategoryId=1,Stock=132,Image="1.jpg"},
                new Product(){Name="a Bilgisayar",Description="a Bilgisayar",Price=1000, IsApproved=true,CategoryId=2,Stock=132,IsHome=true,Image="2.jpg"},
                new Product(){Name="b Bilgisayar",Description="b Bilgisayar",Price=1100, IsApproved=true,CategoryId=2,Stock=132,Image="2.jpg"},
                new Product(){Name="a Elektronik",Description="a Elektronik",Price=1300, IsApproved=true,CategoryId=3,Stock=132, Image = "3.jpg"},
                new Product(){Name="b Elektronik",Description="b Elektronik",Price=1400, IsApproved=false,CategoryId=3,Stock=132,IsHome=true, Image = "3.jpg"},
                new Product(){Name="a Telefon",Description="a Telefon",Price=900, IsApproved=true,CategoryId=4,Stock=132, Image = "4.jpg"},
                new Product(){Name="b Telefon",Description="b Telefon",Price=800, IsApproved=false,CategoryId=4,Stock=132,IsHome=true, Image = "4.jpg"},
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}