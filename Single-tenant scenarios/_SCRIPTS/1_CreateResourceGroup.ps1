param(
 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroup
)

$rg = Get-AzureRmResourceGroup -Name $resourceGroup -ErrorVariable notPresent -ErrorAction SilentlyContinue
if ($rg) {
    exit 
}

New-AzureRmResourceGroup -Name $resourceGroup -Location "North Europe"

Write-Host "[1] Registered resource group: $resourceGroup" -ForegroundColor DarkCyan