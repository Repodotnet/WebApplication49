using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication49.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
        }

        public int Employeeid { get; set; }
        public string Employeename { get; set; }
        public int? Managerid { get; set; }
        public string Designation { get; set; }
        public int? Companyid { get; set; }
        public DateTime? Dob { get; set; }
        public int? Deptid { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? Hiredate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Department Dept { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
