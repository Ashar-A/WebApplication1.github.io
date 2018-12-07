using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {


        //  static public string conString = "Data Source = db761580736.hosting-data.io;  Initial Catalog = db761580736; Connection Timeout = 15; user=db761580736;Password=M@rinda11;";

        string conString = ConfigurationManager.ConnectionStrings["dbconnection1"].ConnectionString;




        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
          //  return "value5";

            SqlConnection con = new SqlConnection(conString);

            try {
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
            catch(Exception e)
            {
                return  "COnnection unsuccessful";

            }
           
          
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
