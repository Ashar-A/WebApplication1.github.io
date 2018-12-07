using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class UsersController : ApiController
    {
        static public string conString = "Data Source = 192.168.10.220,1433; Initial Catalog = mobireminder; Integrated Security = True";

      //  string conString = ConfigurationManager.ConnectionStrings["dbconnection2"].ConnectionString;



        //static public string conString = "Data Source = db761580736.hosting-data.io;  Initial Catalog = db761580736; Connection Timeout = 15; User =db761580736; Password=M@rinda11;";

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // POST api/Account/Register
        [AllowAnonymous]
        [System.Web.Http.Route("api/Users/Register")]
        public  string Register(Users model)
        {

          string      Email = "";
            string Password = "";
            string ConfirmPassword = "";

        //    var data = new Users
        //    {
        //   Email = model.Email,
        //  Password = model.Password,
        //  ConfirmPassword = model.ConfirmPassword,
        //};

            Users abc = new Users();
            abc.Email = model.Email;
            abc.Password = model.Password;
            abc.ConfirmPassword = model.ConfirmPassword;

            var datajson = Newtonsoft.Json.JsonConvert.SerializeObject(abc);

            return datajson;

        }



        [System.Web.Http.Route("api/Users/NotRegister")]
        public string NotRegister()
        {

           
                var httpRequest = HttpContext.Current.Request;

      var data=      httpRequest.QueryString;

            string name = data[0].ToString();
            string bday = data[1].ToString();





            return name;
            }



                // GET api/values/5
                public string Get(int id)
        {
            //  return "value5";

            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();

                string command = "select * from users where id='" + id + "' ";

                SqlCommand cmd = new SqlCommand(command, con);

                SqlDataReader reader = cmd.ExecuteReader();
                //    object _locker = new object();
                //    Monitor.Enter(_locker);
                string name = "";
                while (reader.Read())
                {
                    name = reader["username"].ToString();

                }
                con.Close();


                if (name == "")
                {
                    return "no record found";
                }
                else
                {
                    return name;
                }

            }
            catch (Exception e)
            {
                return "COnnection unsuccessful";

            }


        }


    }
}