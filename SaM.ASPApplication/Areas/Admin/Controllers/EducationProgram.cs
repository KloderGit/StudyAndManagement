using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaM.BusinessLogic.AdminFacade;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaM.ASPApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationProgram : Controller
    {
        AdminFacade logic;        

        public EducationProgram()
        {
            logic = new AdminFacade();
        }

        // GET: /<controller>/
        public IActionResult Index(Guid guid)
        {
            var result = logic.GetProgram(guid);

            return View(result);
        }
    }
}
