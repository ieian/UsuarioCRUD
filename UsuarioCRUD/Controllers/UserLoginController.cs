using Microsoft.AspNetCore.Mvc;
using UsuarioCRUD.Models;
using System.Data;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace UsuarioCRUD.Controllers
{
    public class UserLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login lc)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn); 
            string sqlquery = "select Usuario,Pass from [dbo].[LoginU] where Usuario=@Usuario and Pass=@Pass";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Usuario", lc.UserName);
            sqlcomm.Parameters.AddWithValue("@Pass", lc.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                return RedirectToAction("Crear");
            }
            else
            {
                ViewData["Message"] = "Error con el login, intentelo otra vez";
            }
            
            sqlconn.Close();
            return View();
        }
        public IActionResult Crear()
        {
            return View();
        }
    }
}
