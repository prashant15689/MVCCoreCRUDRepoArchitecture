using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCRUD.BAL.Interfaces;
using MVCCRUD.Models.Models;

namespace MVCCRUD.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IRepository<Departments> repository;
        public DepartmentsController(IRepository<Departments> repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.GetAll());
        }
    }
}