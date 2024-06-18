using Azure.Identity;
using Azure.Storage.Blobs;

string blob_url = "https://appstore48652.blob.core.windows.net/scripts/commands.sql";
string local_blob = "C:\\Users\\jairo\\Downloads\\commands.sql";


string tenantid = "";
string clientid = "";
string clientsecret = "";

ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

Uri blob_uri = new Uri(blob_url);

BlobClient _blob_client = new BlobClient(blob_uri, _client_credential);

_blob_client.DownloadTo(local_blob);

Console.WriteLine("Blob downloaded");
Console.ReadKey();