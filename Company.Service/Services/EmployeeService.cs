using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(EmployeeDto entityDto)
        {
            //Manual Mapping
            Employee employee = new Employee
            {
                Address = entityDto.Address,
                Age = entityDto.Age,
                DepartmentId=entityDto.DepartmentId,
                Email = entityDto.Email,
                HiringDate = entityDto.HiringDate,
                ImgUrl = entityDto.ImgUrl,
                Name = entityDto.Name,
                PhoneNumber = entityDto.PhoneNumber,
                Salary = entityDto.Salary

            };


            _unitOfWork.empolyeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto entity)
        {
            Employee employee = new Employee
            {
                Address = entity.Address,
                Age = entity.Age,
                DepartmentId = entity.DepartmentId,
                Email = entity.Email,
                HiringDate = entity.HiringDate,
                ImgUrl = entity.ImgUrl,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Salary = entity.Salary

            };

            _unitOfWork.empolyeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var emp = _unitOfWork.empolyeeRepository.GetAll();

            var MappedEmployee = emp.Select(x => new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Address = x.Address,
                Salary=x.Salary,
                HiringDate=x.HiringDate,
                ImgUrl=x.ImgUrl,
                Name = x.Name,
                PhoneNumber=x.PhoneNumber,
                CreatedAt = x.CreatedAt,

            });
            return MappedEmployee;
        }

        public EmployeeDto GetById(int? id)
        {
          if(id is null)
            {
                return null;
            }
          var emp = _unitOfWork.empolyeeRepository.GetById(id.Value);
            if(emp is null)           
                return null;
            
            EmployeeDto employeeDto = new EmployeeDto
            {
                Address = emp.Address,
                Age = emp.Age,
                DepartmentId = emp.DepartmentId,
                Email = emp.Email,
                HiringDate = emp.HiringDate,
                ImgUrl = emp.ImgUrl,
                Name = emp.Name,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary

            };

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        { 
           IEnumerable<Employee> emp= _unitOfWork.empolyeeRepository.GetEmployeeByName(name);

          IEnumerable<EmployeeDto> employeeDto = new EmployeeDto
            {
                Address = emp.Address,
                Age = emp.Age,
                DepartmentId = emp.DepartmentId,
                Email = emp.Email,
                HiringDate = emp.HiringDate,
                ImgUrl = emp.ImgUrl,
                Name = emp.Name,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary

            };
            return employeeDto;
        }

        //public void Update(EmployeeDto department)
        //{
        //    _unitOfWork.empolyeeRepository.Update(department);
        //    _unitOfWork.Complete();
        //}
    }
}
