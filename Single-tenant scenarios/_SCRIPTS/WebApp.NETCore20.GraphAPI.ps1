param(
 #[Parameter(Mandatory=$True)]
 #[string]
 #$resourceGroup

 #[Parameter(Mandatory=$True)]
 #[string]
 #$azureADAppName, 
 
 #[Parameter(Mandatory=$True)]
 #[string]
 #$personalCertificateName
)

$ErrorActionPreference = "Stop"

$resourceGroup = "mwtechndo"
$azureADAppName = "WebApp.NETCore20.GraphAPI"
$personalCertificateName = "lukasz.wilisowski@makingwaves.com"

if (!$azureADAppName) {
	Write-Host "Please add -azureApplicationName" -ForegroundColor Red
    exit;
}

if (!$personalCertificateName) {
	Write-Host "Please add -personalCertificateName" -ForegroundColor Red
    exit;
}

###### REMOVE_OPTIONAL #####
#Remove-AzureRmResourceGroup -Name $resourceGroup
#exit

###### Connect to AzureAD #####
Connect-AzureAD

###### ResourceGroup #####
$resourceGroupScriptPath = $PSScriptRoot + "\1_CreateResourceGroup.ps1"
$result = Invoke-Expression "& `"$resourceGroupScriptPath`" -resourceGroup $resourceGroup"
if ($result) {
    exit
}

###### AzureAD Application #####
$azureADApp = Get-AzureRmADApplication -DisplayName $azureADAppName 
$azureADAppServicePrincipal = $azureADApp.ApplicationId

#####  Create Certificate and Add Credential to Service Principal #####
$installLocalHttpsCertificatePath = $PSScriptRoot + "\7_InstallLocalMachineCertificate.ps1"
Invoke-Expression "& `"$installLocalHttpsCertificatePath`" -subjectName $personalCertificateName"

$certs = gci Cert:\LocalMachine\My\ | where { $_.Subject.Equals("CN=$personalCertificateName") }
$cert = If ($certs.Length -gt 0) {$certs[0]} Else {$null}
$keyValue = [System.Convert]::ToBase64String($cert.GetRawCertData())

$appCredential = Get-AzureRmADAppCredential -ApplicationId $azureADAppServicePrincipal
if (!$appCredential) {
    New-AzureRmADAppCredential -ApplicationId $azureADAppServicePrincipal -CertValue $keyValue -StartDate $cert.NotBefore -EndDate $cert.NotAfter
    Write-Host "Certificate credential added to azure AD application" -ForegroundColor Green
}

###### Azure KeyVault #####
$keyVaultScriptPath = $PSScriptRoot + "\3_CreateKeyVault.ps1"
$vaultName = $resourceGroup + "-keyvault"
Invoke-Expression "& `"$keyVaultScriptPath`" -resourceGroup $resourceGroup -vaultName $vaultName -servicePrincipal $azureADAppServicePrincipal"

$keyVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroup

###### Get Application Key #####
$Guid = New-Guid
$appkey = ([System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(($Guid))))+"="
$secretvalue = ConvertTo-SecureString $appkey -AsPlainText -Force

sleep 2

New-AzureRmADAppCredential -ObjectId $azureADApp.ObjectId -Password $secretvalue
Write-Host "Key credential added to azure AD application" -ForegroundColor Green

$secret = Set-AzureKeyVaultSecret -VaultName $vaultName -Name 'webapp-client-secret' -SecretValue $secretvalue
Write-Host "Key credentail saved into key vault" -ForegroundColor Green
###################################

exit