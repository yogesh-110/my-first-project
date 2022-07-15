using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext context;

        public StudentController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Students.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                var stu = new Student()
                {
                    Name = model.Name,
                    Age = model.Age,
                    Address = model.Address,
                    Phone = model.Phone,
                };
                context.Students.Add(stu);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Emply Field can't Submit";
                return View(model);
            }

        }
        public IActionResult Delete(int id)
        {
            var stu = context.Students.SingleOrDefault(e => e.Id == id);
            context.Students.Remove(stu);
            context.SaveChanges();
            TempData["error"] = "Record Delete";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var stu= context.Students.SingleOrDefault(e => e.Id == id);
            var result = new Student()
            {
                Name = stu.Name,
                Age = stu.Age,
                Address=stu.Address,
                Phone=stu.Phone
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            var stu = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Address = model.Address,
                Phone = model.Phone
            };
            context.Students.Update(stu);
            context.SaveChanges();
            TempData["error"] = "Record Updated";

            return RedirectToAction("Index");
        }
    }
}

