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
    public class DisciplineContext(int Id, string Name, int IdGroup) : base(Id, Name, IdGroup) { }

    public static List<DisciplineContext> AllDisciplines()
    {
        List<DisciplineContext> allDisciplines = new List<DisciplineContext>();
        MySqlConnection connection = Connection.OpenConnection();
        MySqlDataReader BDDIsciplines = Connection.Query("SELECT * FROM 'discipline' ORDER BY 'Name',", connection);

        while (BDDIsciplines.Read())
        {
            allDisciplines.Add(new DisciplineContext(
                BDDIsciplines.GetInt32(0),
                BDDIsciplines.GetString(1),
                BDDIsciplines.GetInt32(2)));
        }

        Connection.CloseConnection(connection);
        return allDisciplines;
    }
}
