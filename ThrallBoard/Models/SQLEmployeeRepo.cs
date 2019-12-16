using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ThrallBoard.Models
{
    public class SQLEmployeeRepo : IEmployeeRepo
    {
        private readonly AppDBContext context;

        public SQLEmployeeRepo(AppDBContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int ID)
        {
            Employee employee = context.Employees.Find(ID);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetAnEmployee(int ID)
        {
            return context.Employees.Find(ID);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        public Employee Update(Employee changedEmployee)
        {
            var employee = context.Employees.Attach(changedEmployee);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return changedEmployee;
        }
    }
}
