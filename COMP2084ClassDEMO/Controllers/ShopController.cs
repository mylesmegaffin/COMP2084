using COMP2084ClassDEMO.Data;
using COMP2084ClassDEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084ClassDEMO.Controllers
{
    public class ShopController : Controller
    {
        // db connection
        private readonly ApplicationDbContext _context;

        // connect to the db whenever this controller is used 
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //get the list of categories to display to customers on the main shopping page 
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }

        // Shop/Browse/3
        public IActionResult Browse(int id)
        {
            // get teh products in the selected category
            var products = _context.Products.Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToList();

            // load the Browse page and pass it the list of products to display
            return View(products);
        }

        // Shop/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            //get the current price of the product in the database
            var price = _context.Products.Find(ProductId).Price;

            // identify the customer
            var customerId = GetCustomerId();

            //creat a new Cart object
            var cart = new Cart
            {
                ProductId = ProductId,
                Quantity = Quantity,
                Price = price,
                CustomerId = customerId,
                DateCreated = DateTime.Now
            };

            // use the Cart DbSet in ApplicationContext.cs to save to the datebase
            _context.Carts.Add(cart);
            //saves to the database
            _context.SaveChanges();

            // redirect to show the current cart
            return RedirectToAction("Cart");
        }

        private string GetCustomerId()
        {
            //is there already a session variable holding an identifier for this customer?
            if(HttpContext.Session.GetString("CustomerId") == null)
            {
                //cart is empty, user is unknown
                // the users is putting there first item in the cart
                var customerId = "";

                // use a Guid to generate a new unique identifier
                customerId = Guid.NewGuid().ToString();

                // now store the new identifier in a session variable
                HttpContext.Session.SetString("CustomerId", customerId);
            }

            // return the CUstomerId to the AddToCart method
            return HttpContext.Session.GetString("CustomerId");
        }
    }
}
