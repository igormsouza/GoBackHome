using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusGobackHome.WebCore.Models;

namespace BusGobackHome.WebCore.Controllers
{
    [Route("api/[controller]")]
    public class ApiHomeController : Controller
    {
        [HttpGet("")]
        public RealTime Index()
        {
            var result = new RealTime();

            try
            {
                var item = new TimeList();
                item.Refresh();
                result.TimeList = item;
                result.Succed = true;
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message + " - " + ex.InnerException;
            }

            return result;
        }
    }
}
