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

        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
       => _context.Employees.Where(x=>
       x.Name.Trim().ToLower().Contains(name.Trim().ToLower()) ||
       x.Email.Trim().ToLower().Contains(name.Trim().ToLower())||
       x.PhoneNumber.Trim().ToLower().Contains(name.Trim().ToLower()) ||
       x.PhoneNumber.Trim().ToLower().Contains(name.Trim().ToLower()) 
                         
       ).ToList();
    }
}
