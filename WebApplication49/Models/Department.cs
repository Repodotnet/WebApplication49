using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication49.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Required]
        [Range(maximum:30,minimum:2)]
        public int Deptid { get; set; }
        public string Deptname { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
