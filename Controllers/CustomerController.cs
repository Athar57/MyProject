using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SampleContext _context;

        public CustomerController(SampleContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(_context.Customers.Include(c => c.City).ToList());
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Citylist = new SelectList(_context.Cities.ToList(), "Id", "Name");
            if (id != 0)
            {
                var customer = _context.Customers.Find(id);
                ViewBag.Action = "Update";
                return View(customer);
            }
            else
            {
                ViewBag.Action = "Create";
                return View(new Customer());
            }
        }
        [HttpPost]

        public IActionResult Create(Customer customer ,  Exception ex)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (customer.Id == 0)
                    {
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _context.Customers.Update(customer);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return View(customer);
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
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
       
    }
}