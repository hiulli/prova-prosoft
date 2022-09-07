using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFeExternas.Core.Modelo;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Aplicacao
{
    public class ConfigurarAplicacao
    {
        public static void ConfigurarAzureFunction(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfiguracaoMongoDB>(configuration.GetSection("ConfiguracaoMongoDB"));
            services.Configure<ConfiguracaoServicoExterno>(configuration.GetSection("ConfiguracaoServicoExterno"));
            services.Configure<ConfiguracaoSqlServer>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
