using StudentCore.DataEntity;
using System;
using System.Collections.Generic;

namespace StudentCore.DataAccessLayer
{
    public interface IDataLayer
    {
       List<Employee> GetAllEmployee();

        Employee GetEmpById(int id);

        bool EmpPost(Employee employee);

        bool EmpPut(int id, Employee employee);

        bool EmpDelete(int id);
    }
}
