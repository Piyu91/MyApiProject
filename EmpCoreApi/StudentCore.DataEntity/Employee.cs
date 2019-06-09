using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCore.DataEntity
{
   public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public Department Dept { get; set; }

       
        

    }
}
