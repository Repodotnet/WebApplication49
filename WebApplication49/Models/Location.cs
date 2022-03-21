using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication49.Models
{
    public partial class Location
    {
        public Location()
        {
            Companies = new HashSet<Company>();
        }

        public int Locationid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
