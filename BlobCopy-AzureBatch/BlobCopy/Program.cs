using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Data;
using System.Data.SqlClient;

string conenctionString = "DefaultEndpointsProtocol=https;AccountName=accountstorage48652;AccountKey=L/MTsGdd4Tt1xQzvfNtnTUZog5hdRG/L6ve8zmgkMZsbwbibJU+NZ/6TGZg4BgDxaOWHJj+gDf4R+AStPNNi0g==;EndpointSuffix=core.windows.net";
string containerName = "scripts";
int Id = 1;

BlobContainerClient blobContainerClient = new BlobContainerClient(conenctionString, containerName);
SqlConnection _connection = new SqlConnection("Server=tcp:server15976.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=jairo;Password=User1Pass@*#*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

SqlParameter paramblobname = new SqlParameter();
paramblobname.ParameterName = "@blobname";

SqlParameter paramblobsize = new SqlParameter();
paramblobsize.ParameterName = "@blobsize";


SqlParameter paramaccesstier = new SqlParameter();
paramaccesstier.ParameterName = "@accesstier";

SqlCommand dataCmd = new SqlCommand();
dataCmd.CommandType = CommandType.Text;
dataCmd.Connection = _connection;
dataCmd.Parameters.Add(paramblobname);
dataCmd.Parameters.Add(paramblobsize);
dataCmd.Parameters.Add(paramaccesstier);


var blobs =blobContainerClient.GetBlobs();
_connection.Open();

foreach(BlobItem blob in blobs)
{
    dataCmd.CommandText = "INSERT INTO [BlobData] (blobname,blobsize,accesstier) VALUES" +
    " (@blobname,@blobsize,@accesstier)";

    paramblobname.Value=blob.Name;
    paramblobsize.Value = blob.Properties.ContentLength;
    paramaccesstier.Value=blob.Properties.AccessTier.ToString();

    dataCmd.ExecuteNonQuery();
    Console.WriteLine("Written Record {0}", (Id++));
}

_connection.Close();