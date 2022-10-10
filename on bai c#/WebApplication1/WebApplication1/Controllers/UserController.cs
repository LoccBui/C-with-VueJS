using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using WebApplication1.Models;
using System.Data.SqlClient;
using WebApplication1.DB;
using System.Data;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {

     
        [HttpGet]
        public JsonResult Test()
        {
          
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DBConnection.DBConnect;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "select * from Users";
                cmd.Connection = conn;
                cmd.CommandText = sql;

                object  user = cmd.ExecuteScalar();
                if (user != null)
                {
                    return Json(user, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra !!!" + ex);
            }
            finally
            {
                conn.Close();
            }

            return Json("", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult Get()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DBConnection.DBConnect;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Users", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    string a = row["username"].ToString();
                        string b = row["password"].ToString();
                        User u = new User(a, b);
                        return Json(u, JsonRequestBehavior.AllowGet);
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra !!!" + ex);
            }
            finally
            {
                conn.Close();
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
        
	}




  


}