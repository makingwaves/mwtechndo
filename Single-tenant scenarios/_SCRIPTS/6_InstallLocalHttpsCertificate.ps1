param(
 [Parameter(Mandatory=$True)]
 [string]
 $dnsName
)

$subject = "CN=" + $dnsName
$userGroup="NETWORK SERVICE"

Write-Host "Searching for certificate $subject..." -ForegroundColor DarkCyan

$certs = gci Cert:\LocalMachine\My\ | where { $_.Subject.Contains($subject) }
Write-Host "Found $($certs.Length) certificate(s):" -ForegroundColor DarkCyan

$cert = If ($certs.Length -gt 0) {$certs[0]} Else {$null}

if ($cert -eq $null)
{
	Write-Host "Creating new self-signed certificate" -ForegroundColor DarkCyan
	New-SelfSignedCertificate -Subject $subject -DnsName $dnsName -CertStoreLocation cert:\LocalMachine\My
	Write-Host "Certificate $subject created" -ForegroundColor Green

	$cert = (gci Cert:\LocalMachine\My\ | where { $_.Subject.Contains($subject) })[0]
}

if ($cert -eq $null)
{
    $message="Certificate with subject:"+$subject+" does not exist at Cert:\LocalMachine\My\"
    Write-Host $message -ForegroundColor Red
    exit 1;
}
elseif ($cert.HasPrivateKey -eq $false){
    $message="Certificate with subject:"+$subject+" does not have a private key"
    Write-Host $message -ForegroundColor Red
    exit 1;
}
else
{
    $keyName=$cert.PrivateKey.CspKeyContainerInfo.UniqueKeyContainerName

    $keyPath = "C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys\"
    $fullPath=$keyPath+$keyName
    $acl=(Get-Item $fullPath).GetAccessControl('Access')

    $hasPermissionsAlready = ($acl.Access | where {$_.IdentityReference.Value.Contains($userGroup.ToUpperInvariant()) -and $_.FileSystemRights -eq [System.Security.AccessControl.FileSystemRights]::FullControl}).Count -eq 1

    if ($hasPermissionsAlready){
        Write-Host "Account $userGroupCertificate already has permissions to certificate '$subject'." -ForegroundColor Green
    } else {
        Write-Host "Need add permissions to '$subject' certificate..." -ForegroundColor DarkYellow

        $permission=$userGroup,"Full","Allow"
        $accessRule=new-object System.Security.AccessControl.FileSystemAccessRule $permission
        $acl.AddAccessRule($accessRule)
        Set-Acl $fullPath $acl

        Write-Output "Permissions were added"
    }
}