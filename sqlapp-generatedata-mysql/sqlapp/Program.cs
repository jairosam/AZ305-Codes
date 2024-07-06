using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

string strFilePath = "C:\\Users\\jairo\\OneDrive\\Documentos\\jairo\\Az305\\Codes\\AZ305-Codes\\sqlapp-generatedata-mysql\\sqlapp\\logs\\Log.csv";
StreamReader? logReader =null;
int Id = 1;
MySqlConnection appdbConnection =
    new MySqlConnection("Server=mysql-containers.mysql.database.azure.com;UserID = jairo;Password=User1Pass@*#*;Database=appdb");

MySqlParameter paramId = new MySqlParameter();
paramId.ParameterName = "@Id";

MySqlParameter paramOperationname = new MySqlParameter();
paramOperationname.ParameterName = "@Operationname";


MySqlParameter paramStatus = new MySqlParameter();
paramStatus.ParameterName = "@Status";


MySqlParameter paramEventcategory = new MySqlParameter();
paramEventcategory.ParameterName = "@Eventcategory";

MySqlParameter paramResourcetype = new MySqlParameter();
paramResourcetype.ParameterName = "@Resourcetype";

MySqlParameter paramResource = new MySqlParameter();
paramResource.ParameterName = "@Resource";

try
{
    appdbConnection.Open();    
    
    if (File.Exists(strFilePath))
    {
        logReader = new StreamReader(strFilePath);
        
        MySqlCommand logdataCmd = new MySqlCommand();
        logdataCmd.CommandType = CommandType.Text;
        logdataCmd.Connection = appdbConnection;

        logdataCmd.Parameters.Add(paramId);
        logdataCmd.Parameters.Add(paramOperationname);
        logdataCmd.Parameters.Add(paramStatus);
        logdataCmd.Parameters.Add(paramEventcategory);
        logdataCmd.Parameters.Add(paramResourcetype);
        logdataCmd.Parameters.Add(paramResource);

        while (!logReader.EndOfStream)
        {
            var logDataValues = logReader.ReadLine().Split(',');
                           
                paramId.Value = Id++;
                paramOperationname.Value = logDataValues[0];
                paramStatus.Value = logDataValues[1];
                paramEventcategory.Value= logDataValues[2];
                paramResourcetype.Value= logDataValues[3];
                paramResource.Value= logDataValues[4];

                logdataCmd.CommandText = "INSERT INTO logdata (Id,Operationname,Status,Eventcategory,Resourcetype,Resource) VALUES" +
                    " (@Id,@Operationname,@Status,@Eventcategory,@Resourcetype,@Resource)";

                logdataCmd.ExecuteNonQuery();
                Console.WriteLine("Written Record {0}", (Id - 1));
           
            
        }
    }
}
catch (MySqlException e)
{
    Console.WriteLine(e.ToString());
    appdbConnection.Close();
}
