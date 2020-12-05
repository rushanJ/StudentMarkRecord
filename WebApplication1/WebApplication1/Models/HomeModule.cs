using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HomeModule
    {
        private string _email;
        private string _password;
        public string _id;
        private string _role;


        public string getEmail() { return _email; }
      

        public string getPassword() { return _password; }

        public void setId(string data) { _id = data; }
        public void setRole(string data) { _role = data; }

        public string getRole() { return _role; }
        public string getId() { return _id; }

        public void setEmail(string data) { _email = data; }
        public void setPassword(string data) { _password = data; }

        public List<LecModule> lecModule = new List<LecModule> { };
        // lecModule.Add( new LecModule { moduleName = "sdsefdasd" });

        public void LecModuleList(string id)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString =
                @"Data Source=DESKTOP-SHD5HM7;Initial Catalog=student_data;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open  !");

            SqlDataReader dataReader;
            String sqlQry = "SELECT lec_module.id,module.name FROM lec_module, module WHERE lec_module.module=module.id AND lec_module.lecturer=" + id + "; ";
            SqlCommand sqlCmd = new SqlCommand(sqlQry, cnn);
            dataReader = sqlCmd.ExecuteReader();
            while (dataReader.Read())
            {
               string moduleId = dataReader.GetValue(0).ToString();
                string moduleName = dataReader.GetValue(1).ToString();
                //_role = dataReader.GetValue(7).ToString();
                lecModule.Add(new LecModule { moduleName = moduleName, id= moduleId });
                //Console.WriteLine(_role);
                //cnn.Close();
              
            }
            cnn.Close();
         
        }

        public HomeModule() { }
        public bool auth()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString =
                @"Data Source=DESKTOP-SHD5HM7;Initial Catalog=student_data;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open  !");

            SqlDataReader dataReader;
            String sqlQry = "SELECT * FROM lecturer WHERE email='" + _email + "' AND password='" + _password + "'";
            SqlCommand sqlCmd = new SqlCommand(sqlQry, cnn);
            dataReader = sqlCmd.ExecuteReader();
            while (dataReader.Read())
            {
                _id = dataReader.GetValue(0).ToString();
                _role = dataReader.GetValue(7).ToString();
                //Console.WriteLine(_role);
                cnn.Close();
                return true;
            }
            cnn.Close();
            return false;
        }


    }
}

