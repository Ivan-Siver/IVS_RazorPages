using IVS_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVS_RazorPages.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        Employee Update(Employee updatedEmployee);
    }
}
