param(
 [Parameter(Mandatory=$True)]
 [string]
 $azureADAppName

 [Parameter(Mandatory=$True)]
 [string]
 $applicationUrl

 [Parameter(Mandatory=$True)]
 [string]
 $appCertificateSubjectName
)

$azureADApp = Get-AzureRmADApplication -DisplayName $azureADAppName
if ($azureADApp) {
    exit;
}

#IN CASE YOU WANT TO USE https://dev.localappurl.com
#$localAppDNSName = "local." + $azureADAppName + ".makingwaves.com"
#$applicationUrl = "https://$localAppDNSName"
#
#$installLocalHttpsCertificatePath = $PSScriptRoot + "\InstallLocalHttpsCertificate.ps1"
#Invoke-Expression "$installLocalHttpsCertificatePath -dnsName $localAppDNSName"
#
#$file = "$env:windir\System32\drivers\etc\hosts"

#if (Get-Content $file | Select-String $localAppDNSName) {} else {
#    Write-Host "Adding entry $localAppDNSName in etc/hosts" -ForegroundColor DarkCyan
#    "127.0.0.1 " + $localAppDNSName | Add-Content -PassThru $file
#}
#

if ($appCertificateSubjectName) {
	$certs = gci Cert:\LocalMachine\My\ | where { $_.Subject.Equals("CN=$appCertificateSubjectName") }
	$cert = If ($certs.Length -gt 0) {$certs[0]} Else {$null}
	$keyValue = [System.Convert]::ToBase64String($cert.GetRawCertData())

	$azureADApp = New-AzureRmADApplication -DisplayName $azureADAppName -IdentifierUris $applicationUrl -HomePage $applicationUrl -ReplyUrls $applicationUrl -CertValue $keyValue -EndDate $cert.NotAfter -StartDate $cert.NotBefore
} else {
	$azureADApp = New-AzureRmADApplication -DisplayName $azureADAppName -IdentifierUris $applicationUrl -HomePage $applicationUrl -ReplyUrls $applicationUrl -CertValue $keyValue -EndDate $cert.NotAfter -StartDate $cert.NotBefore
}

$azureADAppId = $azureADApp.ApplicationId

sleep 30

$servicePrincipal = New-AzureRMADServicePrincipal -ApplicationId $azureADAppId
Write-Host "[0] Application registered in AAD (service principal id): $servicePrincipal" -ForegroundColor Green