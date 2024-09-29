using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Models
{
    public class ApplicationUser
    {
        public string? FirastName { get; set; }
       
        public string? LastName { get; set; }
        
        public bool IsActive { get; set; }

    }
}
