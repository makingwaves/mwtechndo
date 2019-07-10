using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.NetCore.FinalB2BB2C.Extensions
{
    public class AzureAdB2COptions
    {
        public const string PolicyAuthenticationProperty = "Policy";

        public string Instance { get; set; }

        public string ClientId { get; set; }

        public string Tenant { get; set; }


        public string BusinessSignUpSignPolicy { get; set; }

        public string DefaultSignUpSignPolicy { get; set; }

        public string ResetPasswordPolicyId { get; set; }

        public string EditProfilePolicyId { get; set; }


        public string ApiUrl { get; set; }

        public string ApiScopes { get; set; }


        public string BaseUrl { get; set; }

        public string RedirectUri { get; set; }

        public string KeyVaultEndpoint { get; set; }
    }
}
