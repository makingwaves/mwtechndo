# Single-Page-Application

Project: WebSPA.NetCore20.OpenIDConnect

![](https://docs.microsoft.com/en-us/azure/active-directory/develop/media/authentication-scenarios/single_page_app.png)
  
First we need to enable Implicit Flow

![](_README/0_AllowSPA.PNG)
  
Add permission to access API. 

![](_README/1_AddPermisions.PNG)
  
FetchData using CORS

![](_README/2_FetchData2.PNG)

User has not consented yet to access this API in delegated context
  
![](_README/3_NotConsentedYet.PNG)

Enable one-time prompt, you need to disable later programically. 
  
![](_README/4_Prompt.PNG)

Everything works as it should

![](_README/5_Working.PNG)
  
## Notes: 
1.	Implicit flow and SPA client does not allow to have any app permissions. **Only user-delegated permissions** are allowed.
2.	In SPA mode we cannot authenticate client (web browser) - only user. Hence the code is not exchanged for access token. This is because traffic can be sniffed and access token is eventually returned 
in browser url. 
3.	Refresh token is not returned in this flow. Instead, each time the access token is needed, SPA app opens iframe and re-generates access token at IdP endpoint using current browser auth. session.
4.	CORS must be enabled in Web API