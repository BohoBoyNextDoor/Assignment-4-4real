using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;


namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext _context;

        public EmployerController(JobDbContext dbContext)
        {
            _context = dbContext;
        }
    
        public IActionResult Index()
        {
            List<Employer> employers = _context.Employers
            .ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if(ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                _context.Employers.Add(newEmployer);
                _context.SaveChanges();
                return Redirect("/Employer");
            }
            return View("Add", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer employerName = _context.Employers.FirstOrDefault(e => e.Id == id);

            return View(theEmployer);
        }
    }
}
