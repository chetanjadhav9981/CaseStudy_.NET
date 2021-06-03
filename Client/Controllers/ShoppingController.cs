using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakerCakeClient.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
