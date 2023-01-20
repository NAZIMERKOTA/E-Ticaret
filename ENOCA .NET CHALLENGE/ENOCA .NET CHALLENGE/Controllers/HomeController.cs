using ENOCA.NET_CHALLENGE.Entity;
using ENOCA.NET_CHALLENGE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ENOCA.NET_CHALLENGE.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context= new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(_context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image= i.Image,
                CategoryId= i.CategoryId,
                IsApproved = i.IsApproved


            }).ToList());
        }

        public ActionResult Details(int id)
        {
           
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            //.Where(i => i.IsApproved)
            var urunler = _context.Products.Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId,
                IsApproved = i.IsApproved


            }).AsQueryable();

            if (id != null) 
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            
            _context.SaveChanges();

            return View(urunler.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}