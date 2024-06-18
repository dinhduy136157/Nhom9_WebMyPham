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
            string sqlCon = "Data Source=DESKTOP-7BK339H;Initial Catalog=ptud;Integrated Security=True; TrustServerCertificate=True";
            con = new SqlConnection(sqlCon);

        }
        //public List<Employee> DsEmployee()
        //{
        //    List<Employee> ds = new List<Employee>();
        //    string sql = "select * from Employee";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataReader rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        Employee emp = new Employee();
        //        emp.employee_id = (int)rd["employee_id"];
        //        emp.fullName = (string)rd["fullName"];
        //        emp.avatar = (string)rd["avatar"];
        //        emp.address = (string)rd["address"];
        //        emp.birthDate = (DateTime)rd["birthDate"];
        //        emp.gender = (string)rd["gender"];
        //        emp.phone = (string)rd["phone"];
        //        emp.email = (string)rd["email"];
        //        emp.password = (string)rd["password"];

        //        ds.Add(emp);
        //    }
        //    con.Close();
        //    return ds;
        //}
        public List<Employee> DsEmployee()
        {
            List<Employee> ds = new List<Employee>();
            string sql = "select * from Employee";

            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

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
        public void xoanv(int employee_id)
        {
            try
            {
                con.Open();
                string sql = "delete from employee where employee_id = @employee_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@employee_id", employee_id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Xóa thành công
                    Console.WriteLine("Xóa nhân viên thành công");
                }
                else
                {
                    // Không có khách hàng nào được xóa
                    Console.WriteLine("Không tìm thấy nhân viên cần xóa");
                }
            }
            catch (Exception ex)
            {
                // Xảy ra lỗi khi xóa
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public Employee layra1NV(int employee_id)
        {
            List<Employee> ds = new List<Employee>();
            string sql = "select * from employee where employee_id=@employee_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("employee_id", employee_id);

            Employee c = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                c = new Employee();
                c.employee_id = (int)rd["employee_id"];
                c.fullName = (string)rd["fullName"];
                c.avatar = (string)rd["avatar"];
                c.address = (string)rd["address"];
                c.birthDate = (DateTime)rd["birthDate"];
                c.gender = (string)rd["gender"];
                c.phone = (string)rd["phone"];
                c.email = (string)rd["email"];
                c.password = (string)rd["password"];
            }
            con.Close();
            return c;
        }
        public void capNhat(Employee c)
        {
            try
            {
                con.Open();
                string sql = "update Employee set fullName=@fullName,avatar=@avatar,address=@address,birthDate=@birthDate," +
                             "gender=@gender,phone=@phone,email=@email,password=@password " +
                             "where employee_id=@employee_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@fullName", c.fullName);
                cmd.Parameters.AddWithValue("@avatar", c.avatar);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@birthDate", c.birthDate);
                cmd.Parameters.AddWithValue("@gender", c.gender);
                cmd.Parameters.AddWithValue("@phone", c.phone);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@password", c.password);
                cmd.Parameters.AddWithValue("@employee_id", c.employee_id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Cập nhật thành công
                    Console.WriteLine("Cập nhật nhân viên thành công");
                }
                else
                {
                    // Không tìm thấy nhân viên cần cập nhật
                    Console.WriteLine("Không tìm thấy nhân viên cần cập nhật");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
