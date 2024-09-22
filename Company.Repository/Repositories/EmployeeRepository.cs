using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee> , IEmpolyeeRepository
    {
        private readonly CompanyDbContext2 _context;

        public EmployeeRepository(CompanyDbContext2 context) : base(context) 
        {
            _context = context;
        }

        
    }
}
