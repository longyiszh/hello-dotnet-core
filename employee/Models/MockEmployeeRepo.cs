using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Models
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

        public Employee GetAnEmployee(int ID)
        {
            return employees.FirstOrDefault((emp) => { return emp.ID == ID; });
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
