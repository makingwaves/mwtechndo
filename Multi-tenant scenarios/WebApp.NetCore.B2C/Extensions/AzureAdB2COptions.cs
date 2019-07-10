using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.NetCore.B2C.Extensions
{
    public class AzureAdB2COptions
    {
        public const string PolicyAuthenticationProperty = "Policy";

        public string Instance { get; set; }

        public string ClientId { get; set; }

        public string Tenant { get; set; }


        public string SignUpSignInPolicyId { get; set; }
        
        public string ResetPasswordPolicyId { get; set; }

        public string EditProfilePolicyId { get; set; }


        public string ApiUrl { get; set; }

        public string ApiScopes { get; set; }


        public string BaseUrl { get; set; }

        public string RedirectUri { get; set; }

        public string KeyVaultEndpoint { get; set; }


        public string DefaultPolicy => SignUpSignInPolicyId;

        public string Authority => $"{Instance}/{Tenant}/{DefaultPolicy}/v2.0";
    }
}
