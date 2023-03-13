using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository repo { get; set; }
        private Basket basket { get; set; }

        public SaleController(ISaleRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        } 

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Sale());
        }
        [HttpPost]
        public IActionResult Checkout(Sale sale)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {
                sale.Lines = basket.Items.ToArray();
                repo.SaveSale(sale);
                basket.ClearBasket();

                return RedirectToPage("/SaleCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
