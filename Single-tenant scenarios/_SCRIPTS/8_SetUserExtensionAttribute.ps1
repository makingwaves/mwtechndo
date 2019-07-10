Connect-AzureAD

$externalUser = Get-AzureADUser -SearchString "lukasz.wilisowski@makingwaves.com"
Set-AzureADUserExtension -ObjectId $User.ObjectId -ExtensionName extension_e5e29b8a85d941eab8d12162bd004528_extensionAttribute8 -ExtensionValue "New Value"