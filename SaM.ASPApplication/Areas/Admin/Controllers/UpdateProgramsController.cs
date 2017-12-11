using Microsoft.AspNetCore.Mvc;
using SaM.BusinessLogic.AdminFacade;
using System;
using System.Linq;

namespace SaM.ASPApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UpdateProgramsController : Controller
    {
        EducationProgramFacade logic;

        public UpdateProgramsController()
        {
            logic = new EducationProgramFacade();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {            
            var result = logic.GetPrograms();

            return View(result);
        }

        public IActionResult Update()
        {
            logic.UpdateEducation();
            
            return Redirect("Index");
        }
    }
}
