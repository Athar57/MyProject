using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.Controllers
{
    public class AjaxCustomerController : Controller
    {
        private readonly SampleContext _context;
        public AjaxCustomerController(SampleContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult IndexAjax()
        {
            return View(_context.Customers.Include(c => c.City).ToList());
        }
        [HttpGet]
        public IActionResult CreateAjax(int id)
        {
            ViewBag.CityList = new SelectList(_context.Cities.ToList(), "Id", "Name");
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
        public IActionResult CreateAjax(Customer customer, Exception ex)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (customer.Id == 0)
                    {
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(IndexAjax));
                    }
                    else
                    {
                        _context.Customers.Update(customer);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(IndexAjax));
                    }
                }
                else
                {
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
        public IActionResult DeleteAjax(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(IndexAjax));
        }
    }
}
