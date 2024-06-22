using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

string tenantId = "52c21aa6-3175-45c3-9c57-b01f6fb8a971";
string clientId = "19e4bd18-2a0c-4411-9bf8-1f38bc2eec97";
string clientSecret = "ufI8Q~FCZBUaE9WIqQ_ErZgHCKlEYW5p-CjJzaSA";

// Given the application only the Get permission on the secret

string keyvaultUrl = "https://vault15896.vault.azure.net/";
string secretName = "db-password";

ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
SecretClient secretClient = new SecretClient(new Uri(keyvaultUrl), clientSecretCredential);

var secret = secretClient.GetSecret(secretName);

string dbpassword = secret.Value.Value;
Console.WriteLine(dbpassword);
