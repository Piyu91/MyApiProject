using StudentCore.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCore.BusinessLayer
{
    public interface IBusiness
    {
       List<Emp> GetAllEmployee();

       Emp GetEmpById(int id);

        bool EmployeePost(Emp emp);

        bool EmployeePut(int id, Emp emp);

        bool EmployeeDelete(int id);
    }
}
