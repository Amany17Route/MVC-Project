using Company.Data.Contexts;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext2 _context;

        public UnitOfWork(CompanyDbContext2 context)
        {
            departmentRepository = new DepartmentRepository(context);
            empolyeeRepository = new EmployeeRepository(context);
             _context = context;
        }

        public IDepartmentRepository departmentRepository { get ; set; }
        public IEmpolyeeRepository empolyeeRepository { get ; set; }

        public int Complete()
        => _context.SaveChanges();
    }
}
