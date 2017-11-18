﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaM.BusinessLogic.AdminFacade;
using Mapster;
using SaM.Common.POCO;
using SaM.ASPApplication.Areas.Admin.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaM.ASPApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        AdminFacade logic;

        public HomeController()
        {
            logic = new AdminFacade();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = logic.GetPrograms()
                .Where( p => p.EducationType.Title == "Очная" )
                    .Select(p => new viewModel { Program = p.Title, Subjects = p.EducationalPlanList.Where(l => l.Certification != null).Select(i => i.Subject.Title) })
                    .Where(vw => vw.Subjects.Count() > 0);

            return View(result);
        }

        public IActionResult ProgramInfo(Guid guid)
        {
            var result = logic.GetProgram(guid).Adapt<ProgramViewModel>();

            return View(result);
        }
    }

    public class viewModel
    {
        public string Program;

        public IEnumerable<string> Subjects ;
    }


}
