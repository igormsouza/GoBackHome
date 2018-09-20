using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusGobackHome.WebCore.Models;

namespace BusGobackHome.WebCore.Controllers
{
    public class IntegrationController : Controller
    {
        public IActionResult Index()
        {
            var item = new TimeList();
            item.Refresh();
            return View(item);
        }
    }
}
