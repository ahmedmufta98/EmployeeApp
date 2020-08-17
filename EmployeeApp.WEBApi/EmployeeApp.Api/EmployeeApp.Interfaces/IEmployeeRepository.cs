using EmployeeApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
    }
}
