using System;
using System.Collections.Generic;
using StudentCore.DataAccessLayer;
using StudentCore.DataModel;
using System.Linq;
using StudentCore.DataEntity;

namespace StudentCore.BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IDataLayer _dataLayer;

        public Business(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public bool EmployeeDelete(int id)
        {
            return _dataLayer.EmpDelete(id);
        }

        public bool EmployeePost(Emp emp)
        {
            var employee = new Employee();
            employee.EmpName = emp.EmpName;
            employee.Salary = emp.Salary;
            employee.Dept = new Department
            {
                DeptName = emp.DeptName,

            };
            
                return _dataLayer.EmpPost(employee);
            
        }

        public bool EmployeePut(int id, Emp emp)
        {
            var employee = new Employee();
            employee.EmpName = emp.EmpName;
            employee.Salary = emp.Salary;
            employee.Dept = new Department
            {
                DeptName = emp.DeptName
            };
          return  _dataLayer.EmpPut(id, employee);
           
      
        }

        public List<Emp> GetAllEmployee()
        {
            var employee = _dataLayer.GetAllEmployee().Select
                            (x=>new Emp { EmpName = x.EmpName, DeptName = x.Dept.DeptName, Salary = x.Salary}).ToList();
            return employee;
        }

        public Emp GetEmpById(int id)
        {
            var employee = _dataLayer.GetEmpById(id);
            var empbyid = new Emp { EmpName = employee.EmpName, DeptName = employee.Dept.DeptName, Salary = employee.Salary };
            return empbyid;
        }
    }
}
