using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefsstuffs.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsstuffs.Controllers
{
    public class HomeController : Controller
    {
        private chefContext dbContext;
        public HomeController(chefContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> returnedChefs = dbContext.chef.Include(p => p.Dishes).ToList();
            return View(returnedChefs);
        }
        [HttpGet("dishes")]
        public IActionResult dishes()
        {
            List<Dish> returnedDish = dbContext.dish.Include(p =>p.Chef).ToList();
            
           
            
            return View(returnedDish);
        }
        [HttpGet("add/chef")]
        public IActionResult addChef(){
            return View("addChef");
        }
        [HttpGet("add/dish")]
        public IActionResult addDish(){
            List<Chef> returnedChef = dbContext.chef.ToList();
            ViewBag.returned = returnedChef;
            return View();
        }
        [HttpPost("createChef")]
        public IActionResult createChef(Chef newChef){

            if(ModelState.IsValid){
                
                dbContext.chef.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("addChef");

            }
        }
        [HttpPost("create/dish")]
        public IActionResult createDish(Dish newDish){
            System.Console.WriteLine("88888888888888888888888888888888888888888888888888888888888");
            System.Console.WriteLine(newDish.dishName);
            System.Console.WriteLine(newDish.calories);
            System.Console.WriteLine(newDish.tasteLevel);
            System.Console.WriteLine(newDish.ChefId);
            System.Console.WriteLine("88888888888888888888888888888888888888888888888888888888888");

            if(ModelState.IsValid){
                // Chef returnedChef = dbContext.chef.SingleOrDefault(chef => chef.id ==newDish.ChefId);
                // newDish.Chef = returnedChef;
                dbContext.dish.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else{
                return View("addDish");

            }
        }

    }
}
