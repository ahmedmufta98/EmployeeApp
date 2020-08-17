using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T model);
        T Update(int id, T model);
        void Delete(int id);
    }
}
