using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class GenericRepository<T>:IGenirecRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContext2 _context;

        public GenericRepository(CompanyDbContext2 context)
        {
            _context = context;
        }
        public void Add(T entity)
        { 
            _context.Add(entity); 
           
        
        }

        public void Delete(T entity)
        { _context.Remove(entity); 
          

        }

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);


        public void Update(T entity)
        { 
            _context.Set<T>().Update(entity); 
           

        
        }

    }
}
