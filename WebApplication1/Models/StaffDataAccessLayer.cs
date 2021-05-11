using WebApplication1.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    public class StaffDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Staff> GetAllStaff()
        {
            List<Staff> lstStaff = new List<Staff>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStaff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Staff Staff = new Staff();
                    Staff.ID = Convert.ToInt32(rdr["ID"]);

                    Staff.S_ID = rdr["S_ID"].ToString();
                    Staff.S_Name = rdr["S_Name"].ToString();
                    Staff.S_Birth = rdr["S_Birth"].ToString();
                    Staff.S_Gender = Convert.ToInt32(rdr["S_Gender"]);

                    Staff.S_Phone = rdr["S_Phone"].ToString();
                    Staff.S_Email = rdr["S_Email"].ToString();
                    Staff.S_Pass = rdr["S_Pass"].ToString();
                    Staff.D_ID = Convert.ToInt32(rdr["D_ID"]);

                    lstStaff.Add(Staff);
                }
                con.Close();
            }
            return lstStaff;
        }
        public void AddStaff(Staff Staff)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStaft", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@S_ID", Staff.S_ID);
                cmd.Parameters.AddWithValue("@S_Name", Staff.S_Name);
                cmd.Parameters.AddWithValue("@S_Birth", Staff.S_Birth);
                cmd.Parameters.AddWithValue("@S_Gender", Staff.S_Gender);
                cmd.Parameters.AddWithValue("@S_Phone", Staff.S_Phone);
                cmd.Parameters.AddWithValue("@S_Email", Staff.S_Email);
                cmd.Parameters.AddWithValue("@S_Pass", Staff.S_Pass);
                cmd.Parameters.AddWithValue("@D_ID", Staff.D_ID);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStaff(Staff Staff)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStaff", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@S_ID", Staff.S_ID);
                cmd.Parameters.AddWithValue("@S_Name", Staff.S_Name);
                cmd.Parameters.AddWithValue("@S_Birth", Staff.S_Birth);
                cmd.Parameters.AddWithValue("@S_Gender", Staff.S_Gender);
                cmd.Parameters.AddWithValue("@S_Phone", Staff.S_Phone);
                cmd.Parameters.AddWithValue("@S_Email", Staff.S_Email);
                cmd.Parameters.AddWithValue("@S_Pass", Staff.S_Pass);
                cmd.Parameters.AddWithValue("@D_ID", Staff.D_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Staff GetStaffData(int? id)
        {
            Staff Staff = new Staff();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Staff WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Staff.ID = Convert.ToInt32(rdr["ID"]);
                    Staff.S_ID = rdr["S_ID"].ToString();
                    Staff.S_Name = rdr["S_Name"].ToString();
                    Staff.S_Birth = rdr["S_Birth"].ToString();
                    Staff.S_Gender = Convert.ToInt32(rdr["S_Gender"]);

                    Staff.S_Phone = rdr["S_Phone"].ToString();
                    Staff.S_Email = rdr["S_Email"].ToString();
                    Staff.S_Pass = rdr["S_Pass"].ToString();
                    Staff.D_ID = Convert.ToInt32(rdr["D_ID"]);
                }
            }
            return Staff;
        }

        public void DeleteStaff(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStaff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
