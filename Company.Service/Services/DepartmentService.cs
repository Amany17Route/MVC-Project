using Company.Service.Dto;
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
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }


        public void Add(DepartmentDto employee)
        {
            var MappedDepartment = new Department
            {
                Code = employee.Code,
                Name = employee.Name,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.departmentRepository.Add(MappedDepartment);
            _unitOfWork.Complete();

           
        }

        public void Delete(DepartmentDto employee)
        {
         _unitOfWork.departmentRepository.Delete(employee);

        }

        public IEnumerable<DepartmentDto> GetAll()
        {
          var dept = _unitOfWork.departmentRepository.GetAll()/*Where(x => x.IsDeleted != true)*/;
            return dept;
        }

        public DepartmentDto GetById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            var dept = _unitOfWork.departmentRepository.GetById(id.Value);

            if (dept is null)
            {
                return null;
            }
            return dept;

        }

        public void Update(DepartmentDto employee)
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
            _unitOfWork.departmentRepository.Update(dept);
            _unitOfWork.Complete();
        }
    }
}
