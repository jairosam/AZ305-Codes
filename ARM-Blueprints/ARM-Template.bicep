resource virtualNetwork 'Microsoft.Network/virtualNetworks@2020-11-01' = {
  name: 'vnet-blueprints'
  location: 'eastus2'
  properties: {
    addressSpace: {
      addressPrefixes: [
        '100.0.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'subnetblueprints'
        properties: {
          addressPrefix: '100.0.1.0/24'
        }
      }
    ]
  }
}
