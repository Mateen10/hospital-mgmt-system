using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Information_System_Business.Entities
{
    public class Employee
    {
        private string cnic;

        public string Cnic
        {
            get { return cnic; }
            set { cnic = value; }
        }
        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string birthdate;

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        private string phoneNo;

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        private string qualification;

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }
        private string experience;

        public string Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        private string accountType;

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        private string joiningDate;

        public string JoiningDate
        {
            get { return joiningDate; }
            set { joiningDate = value; }
        }
        private string imageURL;

        public string ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
