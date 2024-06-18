using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;

string blob_url = "https://appstore48652.blob.core.windows.net/scripts/commands.sql";
string local_blob = "C:\\tmp1\\commands.sql";


TokenCredential tokenCredential = new DefaultAzureCredential();

BlobClient blobClient = new BlobClient(new Uri(blob_url), tokenCredential);

await blobClient.DownloadToAsync(local_blob);

Console.WriteLine("The blob is downloaded");

