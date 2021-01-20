using System;
using System.Collections.Generic;
using System.Text;

namespace StructAndEnumHomeWork
{
    public struct Employee
    {
        public string Name { get; set; }
        public Vacancies vacancies { get; set; }
        public int Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
