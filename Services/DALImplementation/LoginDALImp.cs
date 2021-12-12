using System;
using EntitiesProject.Models;
using DALInterfaces;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace DALImplementation
{
    public class LoginDALImp : ILoginDAL
    {
        string connStr = "server=localhost;user=root;database=baseframework;port=3306;password= ";
        //string connStr = "server=127.0.0.1;user=root;database=baseframework;port=3306;password=test@12345";
        string retstr = "";
        public string LoginDal(LoginEntity loginEntity)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                int iRowcount = 0;
                conn.Open();
                DataSet dsDetails = new DataSet();
                string ssql = "select count(" + "*) from tbl_users where  UserId='" + loginEntity.Username + "'";
                MySqlCommand cmd = new MySqlCommand(ssql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dsDetails);
                iRowcount = System.Convert.ToInt32(dsDetails.Tables[0].Rows[0][0]);
                //string rtn = "selectuser";
                //MySqlCommand cmd = new MySqlCommand(rtn, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@userid", loginEntity.Username);
                ////cmd.Parameters.AddWithValue("@userid", loginEntity.Password);
                //cmd.Parameters.AddWithValue("@total", MySqlDbType.Int64);
                //cmd.Parameters["@total"].Direction = ParameterDirection.Output;
                ////MySqlDataReader rdr = cmd.ExecuteReader();
                ////if (rdr.HasRows)

                //int i = cmd.ExecuteNonQuery();
                //if (i > 0)
                if (iRowcount > 0)
                {
                    retstr = "User Exist";
                    return JsonConvert.SerializeObject(retstr);
                }
                else
                {
                    retstr = "Invalid UserId or Password";
                    return JsonConvert.SerializeObject(retstr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public string RegisterDal(RegisterEntity registerEntity)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string rtn = "insertuser";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", registerEntity.username);
                cmd.Parameters.AddWithValue("@password", registerEntity.password);
                cmd.Parameters.AddWithValue("@name", registerEntity.name);
                cmd.Parameters.AddWithValue("@mobile", registerEntity.mobileno);
                cmd.Parameters.AddWithValue("@email", registerEntity.emailid);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    retstr = "User Details Inserted SuccessFully";
                    return JsonConvert.SerializeObject(retstr);
                }
                else
                {
                    retstr = "Insert Failed";
                    return JsonConvert.SerializeObject(retstr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
