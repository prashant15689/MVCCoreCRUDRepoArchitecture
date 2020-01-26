using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models.Models;
using MVCCRUD.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCRUD.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CompanyDbContext companyDbContext;
        public EmployeesController(CompanyDbContext _companyDbContext)
        {
            companyDbContext = _companyDbContext;
        }
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = await (from emp in companyDbContext.Employees
                                   join dept in companyDbContext.Departments
                                   on emp.DepartmentId equals dept.DepartmentId
                                   select new Employees
                                   {   EmployeeId=emp.EmployeeId,
                                       FirstName = emp.FirstName,
                                       LastName = emp.LastName,
                                       Email = emp.Email,
                                       Mobile = emp.Mobile,
                                       Address = emp.Address,
                                       CreatedDate = emp.CreatedDate,
                                       IsActive = emp.IsActive,
                                       Departments = emp.Departments
                                   }).ToListAsync();
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Departments = companyDbContext.Departments.ToList();
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Employees employee = new Employees()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Email = collection["Email"],
                    Mobile = collection["Mobile"],
                    Address = collection["Address"],
                    DepartmentId = Convert.ToInt32(collection["Departments"]),
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                companyDbContext.Employees.Add(employee);
                companyDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = companyDbContext.Departments.ToList();
            Employees employee = companyDbContext.Employees.Find(id);
            return View(employee);
        }
      
        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Employees employee = companyDbContext.Employees.Find(id);

                employee.FirstName = collection["FirstName"];
                employee.LastName = collection["LastName"];
                employee.Email = collection["Email"];
                employee.Mobile = collection["Mobile"];
                employee.Address = collection["Address"];
                employee.DepartmentId = Convert.ToInt32(collection["Departments"]);
                employee.UpdatedDate = DateTime.Now;
                employee.IsActive = Convert.ToBoolean(collection["IsActive"][0]);
                companyDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            Employees employee = companyDbContext.Employees.Find(id); 
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employees employee = companyDbContext.Employees.Find(id);
                companyDbContext.Employees.Remove(employee);
                companyDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}