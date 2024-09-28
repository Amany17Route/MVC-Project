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
using AutoMapper;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork , IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(DepartmentDto entityDto)
        {
            //var MappedDepartment = new Department
            //{
            //    Code = employee.Code,
            //    Name = employee.Name,
            //    CreatedAt = DateTime.Now
            //};
            Department department = _mapper.Map<Department>(entityDto);
            _unitOfWork.departmentRepository.Add(department);
            _unitOfWork.Complete();

           
        }

        public void Delete(DepartmentDto entityDto)
        {
            Department department = _mapper.Map<Department>(entityDto);

            _unitOfWork.departmentRepository.Delete(department);

        }

        public IEnumerable<DepartmentDto> GetAll()
        {
          var dept = _unitOfWork.departmentRepository.GetAll()/*Where(x => x.IsDeleted != true)*/;
            IEnumerable<DepartmentDto> MappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(dept);
            return MappedDepartment;
        }

        public DepartmentDto GetById(int? id)
        {
            if(id is null)
            {
                return null;
            }
            var dept = _unitOfWork.departmentRepository.GetById(id.Value);

            if (dept is null)            
                return null;

            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(dept);
            return departmentDto;

        }

        //public void Update(DepartmentDto employee)
        //{
        //    var dept = GetById(employee.Id);
        //    if(dept.Name != employee.Name)
        //    {
        //        if (GetAll().Any(x => x.Name == employee.Name))
        //        {
        //            throw new Exception("Dublicated Departments Name");
        //        }
        //    }
        //    dept.Name = employee.Name;
        //    dept.Code = employee.Code;
        //    _unitOfWork.departmentRepository.Update(dept);
        //    _unitOfWork.Complete();
        //}
    }
}
