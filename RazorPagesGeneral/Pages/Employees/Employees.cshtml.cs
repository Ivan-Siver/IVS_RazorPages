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
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public EmployeesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }
        
        public void OnGet()
        {
            Employees = _db.GetAllEmployees();
        }
    }
}
