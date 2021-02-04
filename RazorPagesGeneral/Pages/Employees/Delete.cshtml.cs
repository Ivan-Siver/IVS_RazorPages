using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IVS_RazorPages.Models;
using IVS_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Employee deletedEmployee = _employeeRepository.Delete(Employee.Id);

            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Employees");
        }
    }
}