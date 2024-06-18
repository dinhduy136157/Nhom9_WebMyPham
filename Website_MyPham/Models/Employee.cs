using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_MyPham.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string fullName { get; set; }
        public string avatar { get; set; }
        public string address { get; set; }
        public DateTime birthDate {  get; set; }
        public string gender { get; set; }
        public string phone {  get; set; }
        public string email { get; set; }
        public string password {  get; set; }
        public Employee()
        {

        }
        public Employee(int employee_id, string fullName, string avatar, string address, DateTime birthDate, string gender, string phone, string email, string password)
        {
            this.employee_id = employee_id;
            this.fullName = fullName;
            this.avatar = avatar;
            this.address = address;
            this.birthDate = birthDate;
            this.gender = gender;
            this.phone = phone;
            this.email = email;
            this.password = password;
        }
    }
}