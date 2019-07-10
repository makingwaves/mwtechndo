# B2B - B2C complete application

Project: WebApp.NetCore.FinalB2BB2C, ASP.NET Core 2.1

This application implements Dropbox-like authentication logic using Azure B2C service as auth. provider

![](_README/1_MainScreen.PNG)

If you choose personal login (application can discover it by the type of mail you enter), you will see following login page:

![](_README/2_PersonalLogin.PNG)

![](_README/3_Microsoft.PNG)

![](_README/3_Microsoft_2.PNG)

![](_README/5_AppAccount.PNG)

You can login using local application account, Google account or MSA account: 

![](_README/4_LoggedIn.PNG)

If you choose to create new app account you will see registration form: 

![](_README/14_SignUP.PNG)

![](_README/15.PNG)

You have also forgot password screen and profile edit screen:

![](_README/6_ForgotPassword.PNG)

![](_README/7_ProfileEdit.PNG)

The problem is when you log out, because Azure B2C does not support full single-sign-out. You need to implement it manually: 

![](_README/8_SingleSignOut.PNG)

If you enter organizational account, application will redirect you to separate Azure B2C login page: 

![](_README/9_OrgAccount.PNG)

When there is only **one** IdP (Making Waves - Azure SAML 2.0 provider in this case) Azure B2C conveniently redirect you to IdP. Great :)

![](_README/10_MW.PNG)

The following flows have been set up for this app: 

![](_README/11_UserFlows.PNG)
![](_README/12_UserFlowDefault.PNG)

Additionally, custom sign in policies (Azure Saml 2.0) have been added. 
You can do it similarly with any organizational SSO set up by your B2B users. 

![](_README/13_CustomSignInPolicy.PNG)

Full list of users: 

![](_README/16_Users.PNG)

If you add phone based MFA you will see step like this:

![](_README/17_RequiredPhone.PNG)

![](_README/18_RequiredPHone.PNG)

For implementation details please check the source code. 

Thank you. 