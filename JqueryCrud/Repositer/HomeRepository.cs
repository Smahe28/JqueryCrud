using JqueryCrud.Database;
using JqueryCrud.InterFace;
using JqueryCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JqueryCrud.Repositer
{
    public class HomeRepository :HomeInterface
    {
      public List<EmployeeModel> GetEmply()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
          //  EmployeeModel a_emp = null;
            Connection l_con = new Connection();
            DataTable l_data = new DataTable();
            string query = "select *from Employees";
            using(SqlConnection sqlcon = l_con.MyConnection())
            {
                sqlcon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlcon);
                sqlData.Fill(l_data);
                foreach(DataRow l_row in l_data.Rows)
                {
                    EmployeeModel a_emply = new EmployeeModel();
                    a_emply.EmployeeID = Convert.ToInt32(l_row["EmployeeID"].ToString());
                    a_emply.FirstName = l_row["FirstName"].ToString();
                    a_emply.LastName = l_row["LastName"].ToString();
                    a_emply.EmailID = l_row["EmailID"].ToString();
                    a_emply.City = l_row["City"].ToString();
                    a_emply.Country = l_row["Country"].ToString();
                    employees.Add(a_emply);
                }
            }
            return employees;
        }

        public void SaveEmply(EmployeeModel a_emp)
        {
            Connection l_con = new Connection();
            using(SqlConnection con = l_con.MyConnection())
            {
                con.Open();
                string query = "insert into Employee (FirstName,LastName,EmailID,City,Country) values(@FirstName,@LastName,@EmailID,@City,@Country)";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@FirstName", a_emp.FirstName);
                command.Parameters.AddWithValue("@LastName", a_emp.LastName);
                command.Parameters.AddWithValue("@EmailID", a_emp.EmailID);
                command.Parameters.AddWithValue("@City", a_emp.City);
                command.Parameters.AddWithValue("@Country", a_emp.Country);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}