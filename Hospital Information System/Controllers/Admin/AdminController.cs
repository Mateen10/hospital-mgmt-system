using Hospital_Information_System.Models.Admin;
using Hospital_Information_System_Business.BizHandler;
using Hospital_Information_System_Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Information_System.Controllers.Admin
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        
        public ActionResult Index()
        {
           
            string userName = Convert.ToString(Session["CurrentUser"]);
            EmployeeHandler employeeHandler = new EmployeeHandler();
            Employee e = employeeHandler.SelectByIdEmployee(userName);
            
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }
            if(e.AccountType==null)
            {
                return RedirectToAction("Login", "Account");
            }
            if(e.AccountType!="Admin")
            {
                return RedirectToAction("RestrictAccess", "Account");
            }
            string Dr = "Doctor";
            List<Employee> employees = employeeHandler.SelectAllEmployeeByAccountType(Dr);
            List<EmployeeModel> temp = null;

            if(employees!=null)
            {
                temp = new List<EmployeeModel>();
                foreach(var E in employees)
                {
                    EmployeeModel em = new EmployeeModel 
                    {
                         Cnic=E.Cnic,
                         FullName=E.FullName,
                         Gender=E.Gender,
                         Address=E.Address,
                         Email=E.Email,
                         Birthdate=E.Birthdate,
                         PhoneNo=E.PhoneNo,
                         Qualification=E.Qualification,
                         Experience=E.Experience,
                         AccountType=E.AccountType,
                         JoiningDate=E.JoiningDate,
                         ImageURL=E.ImageURL,
                         UserName=E.UserName,
                         Password=E.Password
                    };
                    temp.Add(em);
                }
            }
           
            return View(temp);
        }

        public ActionResult DeleteEmployee(string CNIC)
        {
            if(CNIC!=null)
            {
                new EmployeeHandler().DeleteEmployee(CNIC);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DetailEmployee(string CNIC)
        {
            Employee e = new EmployeeHandler().ViewEmployee(CNIC);
            EmployeeModel em = null;
            if(e!=null)
            {
                em = new EmployeeModel
                {
                    Cnic=e.Cnic,
                    FullName=e.FullName,
                    Gender=e.Gender,
                    Address=e.Address,
                    Email=e.Email,
                    Birthdate=e.Birthdate,
                    PhoneNo=e.PhoneNo,
                    Qualification=e.Qualification,
                    Experience=e.Experience,
                    AccountType=e.AccountType,
                    JoiningDate=e.JoiningDate,
                    ImageURL=e.ImageURL,
                    UserName=e.UserName,
                    Password=e.Password
            
                };
            }
            return View(em);
        }

        [HttpGet]
        public ActionResult EditEmployee(string CNIC)
        {
            Employee e = new EmployeeHandler().ViewEmployee(CNIC);
            EmployeeModel em = new EmployeeModel
            {
                Cnic = e.Cnic,
                FullName = e.FullName,
                Gender = e.Gender,
                Address = e.Address,
                Email = e.Email,
                Birthdate = e.Birthdate,
                PhoneNo = e.PhoneNo,
                Qualification = e.Qualification,
                Experience = e.Experience,
                AccountType = e.AccountType,
                JoiningDate = e.JoiningDate,
                ImageURL = e.ImageURL,
                UserName = e.UserName,
                Password = e.Password
            };
      
            return View(em);
        }
        [HttpPost]
        public ActionResult AddDoctor(EmployeeModel model)
        {
            int counter = 0;
            Employee e = new Employee();
            e.Cnic = model.Cnic;
            e.FullName = model.FullName;
            e.Gender = model.Gender;
            e.Address = model.Address;
            e.Email = model.Email;
            e.Birthdate = model.Birthdate;
            e.PhoneNo = model.PhoneNo;
            e.Qualification = model.Qualification;
            e.Experience = model.Experience;
            e.AccountType = "Doctor";
            e.JoiningDate = model.JoiningDate;
            foreach (string temp in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[temp];
                string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string weburl = "/Images/Employees/" + DateTime.Now.Ticks + "_" + ++counter + ext;
                string physicalPath = Request.MapPath(weburl);
                file.SaveAs(physicalPath);
                e.ImageURL = weburl;
                file.SaveAs(physicalPath);
                //cmd.Parameters["@ImageUrl"].Value = pm.ImageUrl;
            }
            e.UserName = model.UserName;
            e.Password = model.Password;
            new EmployeeHandler().InsertEmployee(e);
            return RedirectToAction("Index");
        }
        public ActionResult Nurse()
        {
            string userName = Convert.ToString(Session["CurrentUser"]);
            EmployeeHandler employeeHandler = new EmployeeHandler();
            Employee e = employeeHandler.SelectByIdEmployee(userName);

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }
            if (e.AccountType == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (e.AccountType != "Admin")
            {
                return RedirectToAction("RestrictAccess", "Account");
            }
            string Nurse = "Nurse";
            List<Employee> employees = employeeHandler.SelectAllEmployeeByAccountType(Nurse);
            List<EmployeeModel> temp = null;

            if (employees != null)
            {
                temp = new List<EmployeeModel>();
                foreach (var E in employees)
                {
                    EmployeeModel em = new EmployeeModel
                    {
                        Cnic = E.Cnic,
                        FullName = E.FullName,
                        Gender = E.Gender,
                        Address = E.Address,
                        Email = E.Email,
                        Birthdate = E.Birthdate,
                        PhoneNo = E.PhoneNo,
                        Qualification = E.Qualification,
                        Experience = E.Experience,
                        AccountType = E.AccountType,
                        JoiningDate = E.JoiningDate,
                        ImageURL = E.ImageURL,
                        UserName = E.UserName,
                        Password = E.Password
                    };
                    temp.Add(em);
                }
            }

            return View(temp);
        }

        [HttpPost]
        public ActionResult AddNurse(EmployeeModel model)
        {
            int counter = 0;
            Employee e = new Employee();
            e.Cnic = model.Cnic;
            e.FullName = model.FullName;
            e.Gender = "Female";
            e.Address = model.Address;
            e.Email = model.Email;
            e.Birthdate = model.Birthdate;
            e.PhoneNo = model.PhoneNo;
            e.Qualification = model.Qualification;
            e.Experience = model.Experience;
            e.AccountType = "Nurse";
            e.JoiningDate = model.JoiningDate;
            foreach (string temp in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[temp];
                string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                string weburl = "/Images/Employees/" + DateTime.Now.Ticks + "_" + ++counter + ext;
                string physicalPath = Request.MapPath(weburl);
                file.SaveAs(physicalPath);
                e.ImageURL = weburl;
                file.SaveAs(physicalPath);
                //cmd.Parameters["@ImageUrl"].Value = pm.ImageUrl;
            }
            e.UserName = model.UserName;
            e.Password = model.Password;
            new EmployeeHandler().InsertEmployee(e);
            return RedirectToAction("Nurse","Admin");
        }

    }
}
