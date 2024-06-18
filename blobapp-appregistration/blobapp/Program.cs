using Azure.Identity;
using Azure.Storage.Blobs;

string blob_url = "https://appstore48652.blob.core.windows.net/scripts/commands.sql";
string local_blob = "C:\\Users\\jairo\\Downloads\\commands.sql";


string tenantid = "52c21aa6-3175-45c3-9c57-b01f6fb8a971";
string clientid = "19e4bd18-2a0c-4411-9bf8-1f38bc2eec97";
string clientsecret = "N5B8Q~jFmwUYU5gh.RUphmRMmqZje.Xw6BMANcGa";

ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

Uri blob_uri = new Uri(blob_url);

BlobClient _blob_client = new BlobClient(blob_uri, _client_credential);

_blob_client.DownloadTo(local_blob);

Console.WriteLine("Blob downloaded");
Console.ReadKey();