using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCRUD.Data.Contexts;
using MVCCRUD.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCCRUD.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments

        private readonly CompanyDbContext companyDbContext;
        public DepartmentsController(CompanyDbContext _companyDbContext)
        {
            companyDbContext = _companyDbContext;
        }
        public ActionResult Index()
        {
            List<Departments> departments = companyDbContext.Departments.ToList();
            return View(departments);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
            Departments department = companyDbContext.Departments.Find(id);
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Departments departments = new Departments
                {
                    DepartmentName = collection["DepartmentName"].FirstOrDefault(),
                    Description = collection["Description"].FirstOrDefault(),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                companyDbContext.Departments.Add(departments);
                companyDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            Departments department = companyDbContext.Departments.Find(id);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Departments department = companyDbContext.Departments.Find(id);
                department.DepartmentName = collection["DepartmentName"].FirstOrDefault();
                department.Description = collection["Description"].FirstOrDefault();
                department.UpdatedDate = DateTime.Now;
                companyDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            Departments department = companyDbContext.Departments.Find(id);
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int count = companyDbContext.Employees.Count(emp => emp.DepartmentId == id);
                if (count <= 0)
                {
                    Departments department = companyDbContext.Departments.Find(id);
                    companyDbContext.Departments.Remove(department);
                    companyDbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}