using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DTOs
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string FullName { get; set; }

        public string DepartmentName { get; set; }

        public decimal Salary { get; set; }
    }
}
