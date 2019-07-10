param(
 [Parameter(Mandatory=$True)]
 [string]
 $resourceGroup,

 [Parameter(Mandatory=$True)]
 [string]
 $appName
)

$ai = Get-AzureRmApplicationInsights -ResourceGroupName $resourceGroup -Name $appName -ErrorVariable notPresent -ErrorAction SilentlyContinue
if ($ai) {
    exit
}

$ai = New-AzureRmApplicationInsights -ResourceGroupName $resourceGroup -Name $appName -Location "North Europe"

Write-Host "[2] Created App Insights (instrumentation key): $ai.InstrumentationKey" -ForegroundColor Green