using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ReportGeneration_Kataev.Classes.Common;
using ReportGeneration_Kataev.Models;

namespace ReportGeneration_Kataev.Classes
{
    public class StudentContext : Student
    {
        public StudentContext(int Id, string Firstname, string Lastname, int IdGroup, bool Expelled, DateTime DateExpelled) :
        base(Id, Firstname, Lastname, IdGroup, Expelled, DateExpelled)
        { }

        public static List<StudentContext> AllStudent()
        {
            List<StudentContext> allStudent = new List<StudentContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader DOSstudents = Connection.Query("SELECT * FROM 'student' ORDER BY 'lastName'", connection);

            while (DOSstudents.Read())
            {
                allStudent.Add(new StudentContext(
                    DOSstudents.GetInt32(0),
                    DOSstudents.GetString(1),
                    DOSstudents.GetString(2),
                    DOSstudents.GetInt32(3),
                    DOSstudents.GetBoolean(4),
                    DOSstudents.IsDBNull(5) ? DateTime.Now : DOSstudents.GetDateTime(5)
                ));
            }

            Connection.CloseConnection(connection);
            return allStudent;
        }
    }
}
