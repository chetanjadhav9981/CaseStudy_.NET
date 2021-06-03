using BakerCakeClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakerCakeClient.Controllers
{
    public class CakeController : Controller
    {
        BakerCakeContext db;

        public CakeController(BakerCakeContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
