using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using WebApp.NetCore.B2C.Extensions;

namespace WebApp.NetCore.B2C
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            Action<WebHostBuilderContext, IConfigurationBuilder> delegateAuthentication = (ctx, builder) =>
            {
                IHostingEnvironment env = ctx.HostingEnvironment;

                builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

                var config = builder.Build();

                AzureAdB2COptions azureAdOptions = new AzureAdB2COptions();
                config.GetSection("AzureAdB2C").Bind(azureAdOptions);

                var tokenProvider = new AzureServiceTokenProvider();
                var kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));
                builder.AddAzureKeyVault(azureAdOptions.KeyVaultEndpoint, kvClient, new DefaultKeyVaultSecretManager());
            };

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(delegateAuthentication)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
