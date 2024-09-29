using Company.Data.Models;
using Company.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
   public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);

        IEnumerable<EmployeeDto> GetAll();

        void Add(EmployeeDto department);

      //  void Update(EmployeeDto department);

        void Delete(EmployeeDto department);

        IEnumerable<EmployeeDto> GetEmployeeByName(string name) ;
    }
}
