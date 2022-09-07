using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NFe.Infraestrutura.Aplicacao;
using NFe.Infraestrutura.IoC;

[assembly: FunctionsStartup(typeof(Function.LoadInvoces.Startup))]

namespace Function.LoadInvoces
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);
            ConfigurarAplicacao.ConfigurarAzureFunction(builder.Services, configuration);
            IoCRegistraServico.Registrar(builder.Services);
        }

        private IConfiguration BuildConfiguration(string applicationRootPath)
        {
            var config =
                new ConfigurationBuilder()
                    .SetBasePath(applicationRootPath)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            return config;
        }
    }
}
