﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LanguageFeatures.Models;
using System.Linq;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() 
        {

            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M },
                new Product {Name = "Lifejacket", Price = 48.95M },
                new Product {Name = "Soccer ball", Price = 19.50M },
                new Product {Name = "Corner flag", Price = 34.95M }
            };

            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name?[0] == 'S';
            };

            decimal priceFilterTotal = productArray
                .Filter(p => (p?.Price ?? 0) >= 20)
                .TotalPrices();
            decimal nameFilterTotal = productArray
                .Filter(p => p?.Name?[0] == 'S')
                .TotalPrices();

            return View(Product.GetProducts().Select(p => p?.Name));
        }
    }
}
