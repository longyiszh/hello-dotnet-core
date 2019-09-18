using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee.Models
{
    public interface IEmployeeRepo
    {
        Employee GetAnEmployee(int ID);
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee);
    }
}
