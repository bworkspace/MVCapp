using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoApp.Models
{
    public class CustomerDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CaseStudy;Data Source=(localdb)\\MSSQLLocalDB";
  
        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> lstemployee = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Customer employee = new Customer();

                    employee.Accountno = Convert.ToInt32(rdr["Accountno"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Branchname = rdr["Branchname"].ToString();
                    employee.IFSC = rdr["IFSC"].ToString();
                    employee.Balance = Convert.ToInt32(rdr["Balance"]);

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }
  
        public void AddCustomer(Customer employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accountno", employee.Accountno);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Branchname", employee.Branchname);
                cmd.Parameters.AddWithValue("@IFSC", employee.IFSC);
                cmd.Parameters.AddWithValue("@Balance", employee.Balance);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCustomer(Customer employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accountno", employee.Accountno);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Branchname", employee.Branchname);
                cmd.Parameters.AddWithValue("@IFSC", employee.IFSC);
                cmd.Parameters.AddWithValue("@Balance", employee.Balance);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Customer GetCustomerData(int? Accountno)
        {
            Customer cust = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Customers WHERE Accountno= " + Accountno;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cust.Accountno = Convert.ToInt32(rdr["Accountno"]);
                    cust.Name = rdr["Name"].ToString();
                    cust.Branchname = rdr["Branchname"].ToString();
                    cust.IFSC = rdr["IFSC"].ToString();
                    cust.Balance = Convert.ToInt32(rdr["Balance"]);
                }
            }
            return cust;
        }

        public void DeleteCustomer(int? Accountno)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Accountno", Accountno);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
