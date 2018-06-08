using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusGobackHome.WebCore.Models;
using Microsoft.Extensions.Configuration;

namespace BusGobackHome.WebCore.Controllers
{
    [Route("api/[controller]")]
    public class ApiHomeController : Controller
    {
        public ApiHomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        [HttpGet("")]
        public RealTime Index()
        {
            var result = new RealTime();

            try
            {
                bool enableSearch = Configuration.GetValue<bool>("ApiFlag:EnableSearch");

                if (!enableSearch)
                {
                    result.Succeed = false;
                    result.ErrorMsg = "Currently the system is set off.";
                    return result;
                }

                var item = new TimeList();
                item.Refresh();
                result.TimeList = item;
                result.Succeed = true;
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message + " - " + ex.InnerException;
            }

            return result;
        }
    }
}
