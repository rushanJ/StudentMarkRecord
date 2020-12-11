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
        public List<LecStatModule> lecStatModule = new List<LecStatModule> { };
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
            String sqlQry = "SELECT lec_module.id,module.name,intake.name FROM lec_module, module ,intake WHERE lec_module.module=module.id AND lec_module.intake=intake.id AND lec_module.lecturer=" + id + "; ";
            SqlCommand sqlCmd = new SqlCommand(sqlQry, cnn);
            dataReader = sqlCmd.ExecuteReader();
            while (dataReader.Read())
            {
               string moduleId = dataReader.GetValue(0).ToString();
                string moduleName = dataReader.GetValue(1).ToString();
                  string intake = dataReader.GetValue(2).ToString();
                //_role = dataReader.GetValue(7).ToString();
                lecModule.Add(new LecModule { moduleName = moduleName, id= moduleId, intake = intake });
                //Console.WriteLine(_role);
                //cnn.Close();
              
            }
            cnn.Close();
         
        }

        public void LecStatModuleList(string id)
        {
            int countAPlus=0;
            int countA = 0;
            int countAMin = 0;
            int countBPlus = 0;
            int countB = 0;
            int countBMin = 0;
            int countCPlus = 0;
            int countC = 0;
            int countCMin = 0;

            string connetionString;
            SqlConnection cnn;
            connetionString =
                @"Data Source=DESKTOP-SHD5HM7;Initial Catalog=student_data;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open  !");
            id = "3";
            SqlDataReader dataReader;
            String sqlQry = "select * from stu_module where module=" + id + "; ";
            SqlCommand sqlCmd = new SqlCommand(sqlQry, cnn);
            dataReader = sqlCmd.ExecuteReader();
            while (dataReader.Read())
            {


                int examMark = Int32.Parse(dataReader.GetValue(0).ToString());
                int AssignMark = Int32.Parse(dataReader.GetValue(2).ToString());
                int totMark = examMark + AssignMark;

                if (totMark < 45)
                {
                    countCMin++;
                }
                else if (totMark < 50)
                {
                    countC++;

                }
                else if (totMark < 55)
                {
                    countCPlus++;
                }
                else if (totMark < 60)
                {
                    countBMin++;
                }
                else if (totMark < 65)
                {
                    countB++;
                }
                else if (totMark < 70)
                {
                    countBPlus++;
                }
                else if (totMark < 75)
                {
                    countAMin++;
                }
                else if (totMark < 80)
                {
                    countA++;
                }
                else
                {
                    countAPlus++;
                }

                string moduleId = dataReader.GetValue(0).ToString();
                string moduleName = dataReader.GetValue(1).ToString();
                string intake = dataReader.GetValue(2).ToString();
                //_role = dataReader.GetValue(7).ToString();
              // lecStatModule.Add(new LecStatModule { countAPlus = countAPlus, countA = countA, countAMin = countAMin, countBPlus = countBPlus, countB = countB, countBMin = countBMin, countCPlus = countCPlus, countC= countC, countCMin = countCMin });
                //Console.WriteLine(_role);
                //cnn.Close();

            }
            cnn.Close();
            lecStatModule.Add(new LecStatModule { id = id, countAPlus = countAPlus, countA = countA, countAMin = countAMin, countBPlus = countBPlus, countB = countB, countBMin = countBMin, countCPlus = countCPlus, countC = countC, countCMin = countCMin });


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

