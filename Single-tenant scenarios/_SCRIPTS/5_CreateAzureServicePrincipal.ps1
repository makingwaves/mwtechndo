param(
 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroup
)

###### Azure Service Principal #####
#Azure SP is used to automatically provision resources in Azure by logging with service principal account (as opposed to personal Azure subscription account)

$azureResourceManagementAppName = $resourceGroup + "_resourceManagementApp"
$azureResourceManagementAppCertificateName = "CN=" + $azureResourceManagementAppName

#Install-Module AzureAD
Connect-AzureAD

$azureADApp = New-AzureRmADApplication -DisplayName $azureResourceManagementAppName -IdentifierUris $azureResourceManagementAppName
$azureADAppId = $azureADApp.ApplicationId

$cert = New-SelfSignedCertificate -CertStoreLocation "cert:\LocalMachine\My" -Subject $azureResourceManagementAppCertificateName -KeySpec KeyExchange
$keyValue = [System.Convert]::ToBase64String($cert.GetRawCertData())

$servicePrincipal = New-AzureRMADServicePrincipal -ApplicationId $azureADAppId -CertValue $keyValue -EndDate $cert.NotAfter -StartDate $cert.NotBefore

sleep 30
New-AzureRmRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName $azureADAppId

$azureDirecotry = Get-AzureRmTenant

#Add-AzureRmAccount -CertificateThumbprint $cert.Thumbprint -ApplicationId $azureADAppId -TenantId $azureDirecotry.TenantId -ServicePrincipal `