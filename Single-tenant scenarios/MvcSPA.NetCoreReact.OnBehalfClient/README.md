# MVC mixed with SPA application 

Project: MvcSPA.NetCoreReact.OnBehalfClient

![](https://docs.microsoft.com/pl-pl/azure/active-directory/develop/media/v1-oauth2-on-behalf-of-flow/active-directory-protocols-oauth-on-behalf-of-flow.png)
  
Let's add some permissions first

![](_README/1_AppPermissions.PNG)
  
The MVC Controller calls Middle Tier API which in turn calls the target Web API.  
Middle Tier API appends 'AAA' and target Web API appends 'BBB'

![](_README/2_ResultMvc.PNG)
  
When MVC app is mixed with SPA, SPA **should not be using Implicif flow**  
Instead, SPA should get access token from MVC app through additional endpoint. 

![](_README/4_Account_GetAccessToken.PNG)

SPA and React part:
  
![](_README/5_ReactHelloWorld.PNG)  

After CORS is enabled in Middle Tier API we get successfull result:
  
![](_README/3_ResultSPA.PNG)
