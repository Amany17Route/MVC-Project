using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IGenirecRepository<T> where T : BaseEntity
    {

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T department);

        void Update(T department);

        void Delete(T department);

    }
}
