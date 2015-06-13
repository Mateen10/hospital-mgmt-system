using Hospital_Information_System_Business.DAC;
using Hospital_Information_System_Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Information_System_Business.BizHandler
{
    public class EmployeeHandler
    {
        public EmployeeHandler()
        {
            new Employee();
        }

        private Employee getUser(string un, string p)
        {
            return new EmployeesDAC().Login(un,p);
        }

        public bool isAuthenticate(string un, string p)
        {
            Employee e = getUser(un, p);
            return e != null;
        }
        public List<Employee> SelectAllEmployee()
        {
            return new EmployeesDAC().SelectAllEmployee();
        }
        public List<Employee> SelectAllEmployeeByAccountType(string AccountType)
        {
            return new EmployeesDAC().SelectAllEmployeeByAccountType(AccountType);
        }

        public Employee DeleteEmployee(string CNIC)
        {
            return new EmployeesDAC().DeleteEmployee(CNIC);
        }

        public Employee SelectByIdEmployee(string UserName)
        {
            return new EmployeesDAC().SelectByIdEmployee(UserName);
        }
        public Employee ViewEmployee(string CNIC)
        {
            return new EmployeesDAC().ViewEmployee(CNIC);
        }
        public void InsertEmployee(Employee e)
        {
            EmployeesDAC EDAC = new EmployeesDAC();
            EDAC.InsertEmployee(e);
        }

        public void UpdateEmployee(Employee e)
        {
            EmployeesDAC EDAC = new EmployeesDAC();
            EDAC.UpdateEmployee(e);
        }
    }
}
