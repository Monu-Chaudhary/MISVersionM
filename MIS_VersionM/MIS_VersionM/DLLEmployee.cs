using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using MIS_VersionM.ATT;
using System.Configuration;

namespace MIS_VersionM.DLL
{
    public class DLLEmployee
    {
        public string SaveEmployee(ATTEmployee objEmployee)
        {
            string sp = "";
            string msg = "No Data To Save!!!";
            if (objEmployee.Action == "A")
            {
                sp = "dbo.ups_Employee_Save";
                msg = "Successfully Saved.";
            }
            else if (objEmployee.Action == "E")
            {
                sp = "dbo.ups_Employee_Edit";
                msg = "Successfully Edited.";
            }
            string connectionstring = ConfigurationManager.ConnectionStrings["MIS_VersionMConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);
            
            try
            {
                 connect.Open();
                SqlCommand cmd = new SqlCommand(sp, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpID", SqlDbType.Int, 50).Value = objEmployee.EmpID;
                cmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 50).Value = objEmployee.EmpName;
                cmd.Parameters.Add("@EmpEmail", SqlDbType.VarChar, 50).Value = objEmployee.EmpEmail;
                cmd.Parameters.Add("@EmpAddress", SqlDbType.VarChar, 50).Value = objEmployee.EmpAddress;
                cmd.Parameters.Add("@EmpPhone", SqlDbType.VarChar, 50).Value = objEmployee.EmpPhone;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
            {
                connect.Close();      
            }
            return msg;
        }

        public string DeleteEmployee(int? empID)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MIS_VersionMConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string sp = "dbo.ups_Employee_Delete";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("EmpID", SqlDbType.Int, 50).Value = empID;
                cmd.ExecuteNonQuery();
                return "Deleted Sucessfully.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<ATTEmployee> GetEmployee(int? empID)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MIS_VersionMConnectionString"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstring);

            List<ATTEmployee> lst = new List<ATTEmployee>();
            DataSet ds = new DataSet();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("dbo.usp_Employee_Select", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpID", SqlDbType.Int).Value = empID;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Employee");

                foreach (DataRow drow in ds.Tables[0].Rows)
                {
                    ATTEmployee obj = new ATTEmployee();
                    obj.EmpID = Int32.Parse(drow["EmpID"].ToString());
                    obj.EmpName = drow["EmpName"].ToString();
                    obj.EmpEmail = drow["EmpEmail"].ToString();
                    obj.EmpAddress = drow["EmpAddress"].ToString();
                    obj.EmpPhone = drow["EmpPhone"].ToString();
                    obj.Action = "";
                    lst.Add(obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                connect.Close();
            }
            
        }
    }
}