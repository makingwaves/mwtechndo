using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;

namespace DesktopApp.WinForms.OpenIDConnect
{
    public partial class Form1 : Form
    {
        private PublicClientApplication app;

        public Form1()
        {
            InitializeComponent();

            string authority = $"https://login.microsoftonline.com/common";
            this.app = new PublicClientApplication("6e443eea-a6a6-4245-987c-560ea6b4dc35", authority, new TokenCache());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var scopes = new string[] { "140794c2-d299-4d79-bcf5-6ccf4d5fff38/.default" };

            var accounts = await app.GetAccountsAsync();
            AuthenticationResult authResult = null;

            try
            {
                authResult = await app.AcquireTokenSilentAsync(scopes, accounts.FirstOrDefault());
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. 
                // This indicates you need to call AcquireTokenAsync to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await app.AcquireTokenAsync(scopes);
                    //authResult = await app.AcquireTokenAsync(scopes, "makingwaves.com", UIBehavior.Consent, null); //will not work because using 2.0 multi-tenant endpoint
                    // authResult = await app.AcquireTokenAsync(scopes, "", UIBehavior.Consent, null);
                }
                catch (MsalException msalex)
                {

                }
            }
            catch (Exception ex)
            {
                return;
            }

            if (authResult != null)
            {
                var httpClient = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage response;
                try
                {
                    var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, "https://localhost:44377/api/values?name=" + authResult.Account.Username);
                    //Add the token in Authorization header
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    response = await httpClient.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    this.richTextBox1.Text = content;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var accounts = await app.GetAccountsAsync();
            await this.app.RemoveAsync(accounts.FirstOrDefault());

            this.richTextBox1.Text = "";
        }
    }
}
