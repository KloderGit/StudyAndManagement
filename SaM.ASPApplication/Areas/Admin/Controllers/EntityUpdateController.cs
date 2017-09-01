using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaM.ASPApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntityUpdateController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var ddd = "AAAAAAAAAAAAAAAAAAA";
            return View((object)ddd);
        }
    }
}
