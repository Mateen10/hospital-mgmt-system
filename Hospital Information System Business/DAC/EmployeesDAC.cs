using Hospital_Information_System_Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Information_System_Business.DAC
{
    public class EmployeesDAC
    {
        private readonly string SELECT_ALL = "SELECT * FROM Employee WHERE AccountType !='Admin'";
        private readonly string SELECT_ALL_EMPLOYEE = "SELECT * FROM Employee WHERE AccountType=@AccountType";
        private readonly string DELETE_EMPLOYEE = "DELETE FROM Employee WHERE CNIC =@CNIC ";
        private readonly string VIEW_EMPLOYEE = "SELECT * FROM Employee WHERE CNIC=@CNIC";
        private readonly string SELECTBYID_EMPLOYEE = "SELECT * FROM Employee WHERE UserName=@UserName";
        private readonly string LOGIN = "SELECT * FROM Employee WHERE UserName = @UserName AND Password = @Password";

        public List<Employee> SelectAllEmployee()
        {
            SqlCommand cmd = new SqlCommand(SELECT_ALL, DACUtill.getConnection());
            return fetchEmployees(cmd);
        }
        public Employee Login(string UserName,string Password)
        {
            SqlCommand cmd = new SqlCommand(LOGIN, DACUtill.getConnection());
            cmd.Parameters.AddWithValue("@UserName",UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            List<Employee> temp = fetchEmployees(cmd);
            return (temp == null) ? null : temp[0];
 
        }

        public void UpdateEmployee(Employee e)
        {
            SqlConnection con = DACUtill.getConnection();
            SqlCommand cmd = new SqlCommand("Update_Employee", con);
            con.Open();
            using (con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CNIC", e.Cnic);
                cmd.Parameters.AddWithValue("@FullName", e.FullName);
                cmd.Parameters.AddWithValue("@Gender", e.Gender);
                cmd.Parameters.AddWithValue("@Address", e.Address);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Birthdate", e.Birthdate);
                cmd.Parameters.AddWithValue("@PhoneNo", e.PhoneNo);
                cmd.Parameters.AddWithValue("@Qualification", e.Qualification);
                cmd.Parameters.AddWithValue("@Experience", e.Experience);
                cmd.Parameters.AddWithValue("@AccountType", e.AccountType);
                cmd.Parameters.AddWithValue("@JoiningDate", e.JoiningDate);
                cmd.Parameters.AddWithValue("@ImageURL", e.ImageURL);
                cmd.Parameters.AddWithValue("@UserName", e.UserName);
                cmd.Parameters.AddWithValue("@Password", e.Password);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> SelectAllEmployeeByAccountType(string AccountType)
        {
            SqlCommand cmd = new SqlCommand(SELECT_ALL_EMPLOYEE,DACUtill.getConnection());
            cmd.Parameters.AddWithValue("@AccountType",AccountType);
            return fetchEmployees(cmd);
        }

        public Employee DeleteEmployee(string CNIC)
        {
            SqlCommand cmd = new SqlCommand(DELETE_EMPLOYEE,DACUtill.getConnection());
            cmd.Parameters.AddWithValue("@CNIC",CNIC);
            List<Employee> temp = fetchEmployees(cmd);
            return (temp==null)? null : temp[0];
        }

        public Employee SelectByIdEmployee(string UserName)
        {
            SqlCommand cmd = new SqlCommand(SELECTBYID_EMPLOYEE, DACUtill.getConnection());
            cmd.Parameters.AddWithValue("@UserName", UserName);
            List<Employee> temp = fetchEmployees(cmd);
            return (temp == null) ? null : temp[0];
        }
        public Employee ViewEmployee(string CNIC)
        {
            SqlCommand cmd = new SqlCommand(VIEW_EMPLOYEE, DACUtill.getConnection());
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            List<Employee> temp = fetchEmployees(cmd);
            return (temp == null) ? null : temp[0];
        }
        public void InsertEmployee(Employee e)
        {
            SqlConnection con = DACUtill.getConnection();
            SqlCommand cmd = new SqlCommand("Insert_Employee",con);
            con.Open();
            using(con)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CNIC",e.Cnic);
                cmd.Parameters.AddWithValue("@FullName", e.FullName);
                cmd.Parameters.AddWithValue("@Gender", e.Gender);
                cmd.Parameters.AddWithValue("@Address", e.Address);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Birthdate", e.Birthdate);
                cmd.Parameters.AddWithValue("@PhoneNo", e.PhoneNo);
                cmd.Parameters.AddWithValue("@Qualification", e.Qualification);
                cmd.Parameters.AddWithValue("@Experience", e.Experience);
                cmd.Parameters.AddWithValue("@AccountType", e.AccountType);
                cmd.Parameters.AddWithValue("@JoiningDate", e.JoiningDate);
                cmd.Parameters.AddWithValue("@ImageURL", e.ImageURL);
                cmd.Parameters.AddWithValue("@UserName", e.UserName);
                cmd.Parameters.AddWithValue("@Password", e.Password);
                cmd.ExecuteNonQuery();
            }
        }
        
        private List<Employee> fetchEmployees(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Employee> employees = null;
            con.Open();
            using(con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    employees = new List<Employee>();
                    while(dr.Read())
                    {
                        Employee e = new Employee();
                        e.Cnic = Convert.ToString(dr["CNIC"]);
                        e.FullName = Convert.ToString(dr["FullName"]);
                        e.Gender = Convert.ToString(dr["Gender"]);
                        e.Address = Convert.ToString(dr["Address"]);
                        e.Email = Convert.ToString(dr["Email"]);
                        e.Birthdate = Convert.ToString(dr["Birthdate"]);
                        e.PhoneNo = Convert.ToString(dr["PhoneNo"]);
                        e.Qualification = Convert.ToString(dr["Qualification"]);
                        e.Experience = Convert.ToString(dr["Experience"]);
                        e.AccountType = Convert.ToString(dr["AccountType"]);
                        e.JoiningDate = Convert.ToString(dr["JoiningDate"]);
                        e.ImageURL = Convert.ToString(dr["ImageURL"]);
                        e.UserName = Convert.ToString(dr["UserName"]);
                        e.Password = Convert.ToString(dr["Password"]);
                        employees.Add(e);
                    }
                    employees.TrimExcess();

                }
            }
            return employees;
        }
    }
}
