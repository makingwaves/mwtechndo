#$azureADAppName = "ArgumentationGraphs-NetCore-AzureDemo"

#$context = Get-AzureRmContext -ErrorAction SilentlyContinue #this lets you search AAD for func

#if(!$context){
     #$login = Connect-AzureRmAccount  | Out-Null
     ##Connect-AzureAD
     #$context = $login
#} else { Write-Host "Login session already established for " $context.Subscription.SubscriptionName }

#get the SP associated with the MSI
#$azureADApp = Get-AzureRmADApplication -DisplayName $azureADAppName
#$MSIPrincipal = Get-AzureRMADServicePrincipal -ApplicationId $azureADApp.ApplicationId

#get the SP associatesd with the MS Graph
#$graph = Get-AzureRMADServicePrincipal -All $true | ? { $_.DisplayName -match "Microsoft Graph" }

#find the target app roles in the graph
#$targetRoles = $graph.AppRoles | Where-Object Value -in "User.Read.All"

#iterate throgh the known roles and add the MSI SP to them
#$targetRoles | ForEach-Object {New-AzureADServiceAppRoleAssignment -Id $_.Id -PrincipalId $MSIPrincipal.Id -ObjectId $MSIPrincipal.Id -ResourceId $graph.ObjectId}



Connect-AzureAD

#00000003-0000-0000-c000-000000000000 -> graph application Id
$graph = Get-AzureADServicePrincipal -Filter "AppId eq '00000003-0000-0000-c000-000000000000'"
$role = $graph.AppRoles | ?{$_.Value -imatch "User.Read.All" }

#df9d9e34-047b-4a61-a633-2c77f012a262 -> your app Id
$msi = Get-AzureADServicePrincipal -Filter "AppId eq 'df9d9e34-047b-4a61-a633-2c77f012a262'"

New-AzureADServiceAppRoleAssignment -Id { $role.Id } -ObjectId $msi.ObjectId -PrincipalId $msi.ObjectId -ResourceId "https://graph.microsoft.com"

#BAD REQUEST ERROR MEANS THAT APP IS ALREADY ASSIGNED!

#use this query to confirm!!!
#https://developer.microsoft.com/en-us/graph/graph-explorer
#https://graph.microsoft.com/beta/servicePrincipals/9fedea66-ab67-4cf8-8669-f08346900eee/appRoleAssignedTo