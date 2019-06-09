using Microsoft.Extensions.Logging;
using StudentCore.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCore.DataAccessLayer
{
    public class DataAccess : IDataLayer
    {
        private readonly DbContext _dbContext;
        private readonly ILogger _logger;

        public DataAccess(DbContext dbContext, ILogger<DataAccess> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public bool EmpDelete(int id)
        {
           var deletedemp = DbContext.emplyees.Find(x=>x.Id==id);
            DbContext.emplyees.Remove(deletedemp);
            return true;

        }

        public bool EmpPost(Employee employee)
        {
            try
            {
                employee.Id = DbContext.emplyees.Max(x => x.Id) + 1;
                employee.Dept.Id = DbContext.emplyees.Max(x => x.Dept.Id) + 1;
                DbContext.emplyees.Add(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EmpPut(int id, Employee employee)
        {
            var employeePut = DbContext.emplyees.Find(x => x.Id == id);
            employeePut.EmpName = employee.EmpName;
            employeePut.Salary = employee.Salary;
            employeePut.Dept.DeptName = employee.Dept.DeptName;
            

            return true;
        }

        public List<Employee> GetAllEmployee()
        {
            return DbContext.emplyees;
        }

        public Employee GetEmpById(int id)
        {
            var employee = DbContext.emplyees.Find(x =>x.Id == id);

            return employee;
        }
    }
}
