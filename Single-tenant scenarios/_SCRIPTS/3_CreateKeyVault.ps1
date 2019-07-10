param(
 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroup, 

 [Parameter(Mandatory=$True)]
 [string]
 $vaultName, 

 [Parameter(Mandatory=$True)]
 [string]
 $servicePrincipal, 

 [Parameter(Mandatory=$False)]
 [string]
 $certificateSubjectToUpload, 

 [Parameter(Mandatory=$False)]
 [string]
 $kvCertificateName
)

[Reflection.Assembly]::LoadWithPartialName("System.Web")

function UploadSSLCertificate([string]$resourceGroup, [string]$servicePrincipal, [string]$certificateSubjectToUpload, [string]$kvCertificateName) {
    $certs = gci Cert:\LocalMachine\My\ | where { $_.Subject.Equals($certificateSubjectToUpload) }
    $cert = If ($certs.Length -gt 0) {$certs[0]} Else {$null}

    $randomString = [system.web.security.membership]::GeneratePassword(10, 5)
    $mypwd = ConvertTo-SecureString -String $randomString -Force -AsPlainText
    $certPath = "cert:\LocalMachine\My\" + $cert.SerialNumber
    $cert | Export-PfxCertificate -FilePath temp.pfx -Password $mypwd

    Import-AzureKeyVaultCertificate -VaultName $vaultName -Name $kvCertificateName -FilePath temp.pfx -Password $mypwd
    Remove-Item temp.pfx
    return
}

$keyVault = Get-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroup
if ($keyVault) {
    exit
}

$keyVault = New-AzureRmKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroup -Location 'North Europe'
Write-Host "Created Key Vault with name: $vaultName" -ForegroundColor Green

Set-AzureRmKeyVaultAccessPolicy -VaultName $vaultName -ServicePrincipalName $servicePrincipal -PermissionsToKeys get,list -PermissionsToSecrets get,list -PermissionsToCertificates get,list
Write-Host "Added access to keyvault for service principal: $servicePrincipal" -ForegroundColor Green

if ($certificateSubjectToUpload -and $kvCertificateName) {
    UploadSSLCertificate -resourceGroup $resourceGroup -servicePrincipal $servicePrincipal -certificateSubjectToUpload $certificateSubjectToUpload -kvCertificateName $kvCertificateName
}


