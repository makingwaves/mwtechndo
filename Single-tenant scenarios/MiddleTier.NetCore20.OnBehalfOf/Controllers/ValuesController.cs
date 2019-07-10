using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MiddleTier.NetCore20.OnBehalfOf.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ValuesController : ControllerBase
    {
        public const string ObjectIdentifierType = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get(string name)
        {
            //PERMISSION CHECK!
            var scopesClaim = User.FindFirst("http://schemas.microsoft.com/identity/claims/scope");
            if (scopesClaim.Value.IndexOf("read_downstream_api") == -1)
            {
                return Unauthorized();
            }

            string userId = User.FindFirst(ObjectIdentifierType)?.Value;

            //var authority = $"{azureOptions.Value.Instance}{azureOptions.Value.TenantId}";
            var authority = $"https://login.microsoft.com/common"; ;

            var resource = "bce0a0c8-cfd0-4f28-9cde-fa39c6c8b776"; //web api
            var clientId = "140794c2-d299-4d79-bcf5-6ccf4d5fff38";

            var scopes = new string[] { resource + "/.default" };

            var credential = new ClientCredential("Kowu0Hov/WHHAdrvO1o2XTH9XE8NPe8/spJTB+IbjIM=");

            var bearer = Request.Headers["Authorization"].ToString();
            var accessToken = bearer.Substring(7);

            UserAssertion userAssertion = new UserAssertion(accessToken);

            var app = new ConfidentialClientApplication(clientId, "https://localhost:44377/", credential, new TokenCache(), null);
            AuthenticationResult result = await app.AcquireTokenOnBehalfOfAsync(scopes, userAssertion);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            string nameUpdated = name + "_AAA";

            var response = await httpClient.GetAsync(@"https://localhost:44311/api/values?name=" + nameUpdated);
            string json = await response.Content.ReadAsStringAsync();

            //string username = User.Identity.Name;
            return json;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }
    }
}
