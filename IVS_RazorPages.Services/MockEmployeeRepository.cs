using IVS_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IVS_RazorPages.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee
                {
                    Id = 0, 
                    Name = "NatashaRomanoff", 
                    Email = "NatashaRomanoff@shield.com",
                    PhotoPath = "NatashaRomanoff.jpg",
                    Department = Dept.Avengers
                },

                new Employee
                {
                    Id = 1,
                    Name = "ClintBarton",
                    Email = "ClintBarton@shield.com",
                    PhotoPath = "ClintBarton.jpg",
                    Department = Dept.Avengers
                },

                new Employee
                {
                    Id = 2,
                    Name = "NickFury",
                    Email = "NickFury@shield.com",
                    PhotoPath = "NickFury.jpg",
                    Department = Dept.Shield
                },

                new Employee
                {
                    Id = 3,
                    Name = "PeggyCarter",
                    Email = "PeggyCarter@shield.com",
                    PhotoPath = "PeggyCarter.jpg",
                    Department = Dept.Shield
                },

                new Employee
                {
                    Id = 4,
                    Name = "CharlesXavier",
                    Email = "CharlesXavier@shield.com",
                    Department = Dept.Xmen
                },

                new Employee
                {
                    Id = 5,
                    Name = "JeanGrey",
                    Email = "JeanGrey@shield.com",
                    PhotoPath = "JeanGrey.jpg",
                    Department = Dept.Xmen
                }
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _employeeList.FirstOrDefault(x => x.Id == id);

            if (employeeToDelete != null)
                _employeeList.Remove(employeeToDelete);

            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;

            if (dept.HasValue)
                query = query.Where(x => x.Department == dept.Value);

            return query.GroupBy(x => x.Department)
                                .Select(x => new DeptHeadCount() 
                                {
                                    Department = x.Key.Value,
                                    Count = x.Count()
                                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == updatedEmployee.Id);

            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;
        }
    }
}
