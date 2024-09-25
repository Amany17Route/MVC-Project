﻿using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }

        public IActionResult Index()
        {
            var dept = _departmentService.GetAll();


            return View(dept);
        }

        [HttpGet]
        public IActionResult Create() { 
        return View();
        }


        [HttpPost]
        public IActionResult Create(Department department) {
            try
            {

                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);

                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");

                return View(department);
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("DepartmentError",ex.Message);
                return View(department);

            }

        }
        [HttpGet]
        public IActionResult Details(int? id , string viewname ="Details")
        {
            var dept = _departmentService.GetById(id);
            if (dept is null)
            {
                return NotFound();
            }


            return View(viewname , dept);

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id , "Update");

        }

        [HttpPost]
        public IActionResult Update(int? id , Department department)
        {
            if (department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
         _departmentService.Update(department);
            return RedirectToAction(nameof (Index));
        }
    }
}
