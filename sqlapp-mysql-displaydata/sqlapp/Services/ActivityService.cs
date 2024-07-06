using MySql.Data.MySqlClient;
using sqlapp.Models;


namespace sqlapp.Services
{

    public class ActivityService
    {       

        private MySqlConnection GetConnection()
        {
                        
            return new MySqlConnection("Server=mysql-containers.mysql.database.azure.com;UserID = jairo;Password=User1Pass@*#*;Database=appdb");
        }
        public List<Activity> GetActivities()
        {
            List<Activity> _activity_lst = new List<Activity>();
            string _statement = "SELECT Id,Operationname,Status,Eventcategory,Resourcetype,Resource from logdata";
            MySqlConnection _connection = GetConnection();
            
            _connection.Open();
            
            MySqlCommand _sqlcommand = new MySqlCommand(_statement, _connection);
            
            using (MySqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Activity _activity = new Activity()
                    {
                        Id = _reader.GetInt32(0),
                        Operationname = _reader.GetString(1),
                        Status = _reader.GetString(2),
                        Eventcategory = _reader.GetString(3),
                        Resourcetype = _reader.GetString(4),
                        Resource = _reader.GetString(5)
                    };

                    _activity_lst.Add(_activity);
                }
            }
            _connection.Close();
            return _activity_lst;
        }

    }
}

