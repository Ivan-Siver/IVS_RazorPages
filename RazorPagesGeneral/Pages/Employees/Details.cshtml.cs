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
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
