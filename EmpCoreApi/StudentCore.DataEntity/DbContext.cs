using System;
using System.Collections.Generic;

namespace StudentCore.DataEntity
{
    public class DbContext
    {
        public static List<Employee> emplyees = new List<Employee>()
        {
            new Employee {  Id =1, EmpName="Priyanka Saha", Salary=10,
                            Dept = new Department{Id=1,  DeptName="abc" } },

            new Employee {  Id =2, EmpName="Sukanta Saha", Salary=10,
                            Dept = new Department{ Id=2, DeptName="TRV"}}
        };

        //List<Department> departments = new List<Department>()
        //{
        //    new Department{ Id=1,  DeptName="abc"}  ,
        //    new Department{ Id=2, DeptName="TRV"}
        //};
        
    }
}
