using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication49.Models
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Companyid { get; set; }
        public string Companyname { get; set; }
        public int? Locationid { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
