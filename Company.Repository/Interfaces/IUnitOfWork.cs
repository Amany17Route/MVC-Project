using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepository departmentRepository { get; set; }
        public IEmpolyeeRepository empolyeeRepository { get; set; }

        int Complete();
    }
}
