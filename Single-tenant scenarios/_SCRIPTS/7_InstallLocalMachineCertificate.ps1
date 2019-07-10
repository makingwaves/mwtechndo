param(
 [Parameter(Mandatory=$True)]
 [string]
 $subjectName
)

$subject = "CN=" + $subjectName

Write-Host "Searching for certificate $subject..." -ForegroundColor DarkCyan

$certs = gci Cert:\LocalMachine\My\ | where { $_.Subject.Contains($subject) }
Write-Host "Found $($certs.Length) certificate(s):" -ForegroundColor DarkCyan

$cert = If ($certs.Length -gt 0) {$certs[0]} Else {$null}

if ($cert -eq $null)
{
	Write-Host "Creating new self-signed machine certificate (not exportable)" -ForegroundColor DarkCyan
	New-SelfSignedCertificate -Subject $subject -CertStoreLocation cert:\LocalMachine\My -KeySpec Signature -KeyExportPolicy Exportable 
	Write-Host "Certificate $subject created" -ForegroundColor Green
}