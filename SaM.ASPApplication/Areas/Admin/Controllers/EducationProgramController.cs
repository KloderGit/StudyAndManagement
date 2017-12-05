using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaM.BusinessLogic.AdminFacade;
using Mapster;
using SaM.ASPApplication.Areas.Admin.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaM.ASPApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationProgramController : Controller
    {
        AdminFacade logic;        

        public EducationProgramController()
        {
            logic = new AdminFacade();
        }

        public IActionResult Index()
        {
            var result = logic.GetPrograms().Adapt<IEnumerable<ProgramViewModel>>();

            return View(result);
        }

        public IActionResult GetProgram(Guid guid)
        {
            var result = logic.GetProgram(guid).Adapt<ProgramViewModel>();

            return View(result);
        }

        public IActionResult DeleteSubject(Guid guid)
        {
            logic.DeleteSubject(guid);

            return Redirect("Index");
        }

        public IActionResult DeleteProgram(Guid guid)
        {
            logic.DeleteProgram(guid);

            return Redirect("Index");
        }

        public IActionResult ProgramActive(Guid guid, bool isActive)
        {
            logic.ProgramActive(guid, !isActive);

            return Redirect("Index");
        }
    }
}
