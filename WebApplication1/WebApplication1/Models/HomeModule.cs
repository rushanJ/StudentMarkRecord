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
        private string _id;

        public string getEmail() {return _email; }

        public string getPassword() { return _password; }

        public void setId(string data){ _id = data;}

        public string getId() { return _id; }

        public void setEmail(string data) { _email = data; }
        public void setPassword(string data) { _password = data; }

        public HomeModule(){}
        public bool auth()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString =
                @"Data Source=LAPTOP-NTFVTE2A;Initial Catalog=student_data;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open  !");
            
            SqlDataReader dataReader;
            String sqlQry = "SELECT * FROM lecturer WHERE email='"+_email+"' AND password='"+_password+"'";
            SqlCommand sqlCmd = new SqlCommand(sqlQry, cnn);
            dataReader = sqlCmd.ExecuteReader();
             while (dataReader.Read())
             {
                 _id = dataReader.GetValue(1).ToString();
                 cnn.Close();
                 return true;
            }
            cnn.Close();
            return false;
        }


    }
}

