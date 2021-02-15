using IVS_RazorPages.Models;
using IVS_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

        [BindProperty(SupportsGet = true)] // по умолчанию работает только с ѕост-методами
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Employees = _db.Search(SearchTerm);
        }
    }
}
