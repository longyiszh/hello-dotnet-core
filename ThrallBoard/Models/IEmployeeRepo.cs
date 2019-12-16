using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThrallBoard.Models
{
    public interface IEmployeeRepo
    {
        Employee GetAnEmployee(int ID);
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee changedEmployee);
        Employee Delete(int ID);
    }
}
