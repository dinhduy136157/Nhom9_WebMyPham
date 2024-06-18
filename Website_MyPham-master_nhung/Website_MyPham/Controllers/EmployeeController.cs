using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Website_MyPham.Models;

namespace Website_MyPham.Controllers
{
    public class EmployeeController
    {
        SqlConnection con;
        public EmployeeController()
        {
            string sqlCon = "Data Source=Nhung\\SQLEXPRESS;Initial Catalog=ptud;Integrated Security=True;Trust Server Certificate=True";
            con = new SqlConnection(sqlCon);

        }
        public List<Employee> DsEmployee()
        {
            List<Employee> ds = new List<Employee>();
            string sql = "select * from Employee";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Employee emp = new Employee();
                emp.employee_id = (int)rd["employee_id"];
                emp.fullName = (string)rd["fullName"];
                emp.avatar = (string)rd["avatar"];
                emp.address = (string)rd["address"];
                emp.birthDate = (DateTime)rd["birthDate"];
                emp.gender = (string)rd["gender"];
                emp.phone = (string)rd["phone"];
                emp.email = (string)rd["email"];
                emp.password = (string)rd["password"];

                ds.Add(emp);
            }
            con.Close();
            return ds;
        }
        public void AddEmployee(Employee nv)
        {
            con.Open();
            string sql = "insert into Employee values(@fullName,@avatar,@address,@birthDate, @gender, @phone, @email, @password)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("fullName", nv.fullName);
            cmd.Parameters.AddWithValue("avatar", nv.avatar);
            cmd.Parameters.AddWithValue("address", nv.address);
            cmd.Parameters.AddWithValue("birthDate", nv.birthDate);
            cmd.Parameters.AddWithValue("gender", nv.gender);
            cmd.Parameters.AddWithValue("phone", nv.phone);
            cmd.Parameters.AddWithValue("email", nv.email);
            cmd.Parameters.AddWithValue("password", nv.password);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}