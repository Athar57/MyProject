using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminLTE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace AdminLTE.Controllers
{
    public class ProductController : Controller
    {
        private readonly SampleContext _context;
        public ProductController(SampleContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Products.Include(e => e.Category).ToList());
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Categorylist = new SelectList(_context.Categories.ToList(), "Id", "Name", "Description");
            if (id != 0)
            {
                var product = _context.Products.Find(id);
                ViewBag.Action = "Update";
                return View(product);
            }
            else
            {
                ViewBag.Action = "Create";
                return View(new Product());
            }
        }
        [HttpPost]
        public IActionResult Create(Product product, Exception ex)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.Id == 0)
                    {
                        _context.Products.Add(product);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _context.Products.Update(product);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                   
                    return View(product);
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.InnerException.Message);
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



     }
}
