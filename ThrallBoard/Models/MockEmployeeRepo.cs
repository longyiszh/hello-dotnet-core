using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThrallBoard.Models
{
    public class MockEmployeeRepo : IEmployeeRepo
    {
        private List<Employee> employees;

        public MockEmployeeRepo()
        {
            employees = new List<Employee>()
            {
                new Employee() {
                    ID = 0,
                    Name = "Jianjiaojiao",
                    Avatar = "jianjj-avatar.jpg",
                    Department = Dept.Comedy,
                    Email = "jdk@comediany.com"
                },
                new Employee() {
                    ID = 1,
                    Name = "prismtk",
                    Avatar = "prismtk-avatar.jpg",
                    Department = Dept.Security,
                    Email = "prismtk@comediany.com"
                },
                new Employee() {
                    ID = 2,
                    Name = "biscuito",
                    Avatar = "biscuito-avatar.jpg",
                    Department = Dept.News,
                    Email = "bsk@comediany.com"
                },
            };

        }

        public Employee Add(Employee employee)
        {
            employee.ID = employees.Max(emp => emp.ID) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee Delete(int ID)
        {
            Employee employee = employees.FirstOrDefault((emp) => { return emp.ID == ID; });
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return employee;
        }

        public Employee GetAnEmployee(int ID)
        {
            return employees.FirstOrDefault((emp) => { return emp.ID == ID; });
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee Update(Employee changedEmployee)
        {
            Employee employee = employees.FirstOrDefault((emp) => { return emp.ID == changedEmployee.ID; });
            if (employee != null)
            {
                employee.Avatar = changedEmployee.Avatar;
                employee.Department = changedEmployee.Department;
                employee.Email = changedEmployee.Email;
                employee.Name = changedEmployee.Name;
            }
            return employee;
        }
    }
}
