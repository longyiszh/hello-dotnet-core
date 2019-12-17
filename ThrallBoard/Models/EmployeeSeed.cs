using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThrallBoard.Models
{
    public static class EmployeeSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    ID = 1,
                    Name = "funnyKitt",
                    Avatar = "avatar-funnyKitt.jpg",
                    Email = "funnyKitt@rmvb.cct",
                    Department = Dept.Comedy
                },

                new Employee
                {
                    ID = 2,
                    Name = "bigRuaDog",
                    Avatar = "brd.jpg",
                    Email = "puppyRua@cwrp.com",
                    Department = Dept.IT
                }

            );
        }
    }
}
