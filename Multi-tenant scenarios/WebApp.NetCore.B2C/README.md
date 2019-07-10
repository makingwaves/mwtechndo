# B2C application

Project: WebApp.NetCore.B2C, ASP.NET Core 2.1

With this app you will log in using personal social account.  

First create new B2C tenant: 

![](_README/4_B2C_1.PNG)

Then create B2C application: 

![](_README/4_B2C_2.PNG)

Add standard user flows: 

![](_README/4_B2C_3.PNG)

You can test the flow if you like or change the layout of your login page.  

![](_README/4_B2C_4.PNG)

To log in with Google or MSA accounts we need to create proper applications of new Identity Providers. 
You can do this using Microsoft tutorials. 

![](_README/6_MicrosoftAccount.PNG)

![](_README/6_MicrosoftAccount_2.PNG)

![](_README/bbb.PNG)

![](_README/12_GoogleApp.PNG)

Finally you need to enable newly added IdPs into your user login flow. 

![](_README/8_EnableIdentityProviders.PNG)

When user logs in with MSA account, he/she will see:

![](_README/10_LiveID_Consent.PNG)

Now your app is ready to be tested: 

![](_README/13_B2C_App.PNG)

![](_README/13_B2C_App_2.PNG)

First create new account: 

![](_README/14_SignUp.PNG)

Application users: 

![](_README/16_B2C_Users.PNG)
