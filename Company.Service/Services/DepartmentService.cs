using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;
        }


        public void Add(Department employee)
        {
            _departmentRepository.Add(employee);
        }

        public void Delete(Department employee)
        {
           _departmentRepository.Delete(employee);
        }

        public IEnumerable<Department> GetAll()
        {
          var dept = _departmentRepository.GetAll().Where(x => x.IsDeleted != true);
            return dept;
        }

        public Department GetById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            var dept = _departmentRepository.GetById(id.Value);

            if (dept is null)
            {
                return null;
            }
            return dept;

        }

        public void Update(Department employee)
        {
            var dept = GetById(employee.Id);
            if(dept.Name != employee.Name)
            {
                if (GetAll().Any(x => x.Name == employee.Name))
                {
                    throw new Exception("Dublicated Departments Name");
                }
            }
            dept.Name = employee.Name;
            dept.Code = employee.Code;
            _departmentRepository.Update(dept);
        }
    }
}
