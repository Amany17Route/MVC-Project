using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
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

        public void Add(Employee department)
        {
            _unitOfWork.empolyeeRepository.Add(department);
            _unitOfWork.Complete();
        }

        public void Delete(Employee department)
        {
            _unitOfWork.empolyeeRepository.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
            var dept = _unitOfWork.empolyeeRepository.GetAll();
            return dept;
        }

        public Employee GetById(int? id)
        {
          if(id is null)
            {
                return null;
            }
          var dept = _unitOfWork.empolyeeRepository.GetById(id.Value);
            if(dept is null)
            {
                return null;
            }

            return dept;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
       => _unitOfWork.empolyeeRepository.GetEmployeeByName(name);

        public void Update(Employee department)
        {
            _unitOfWork.empolyeeRepository.Update(department);
            _unitOfWork.Complete();
        }
    }
}
