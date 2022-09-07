using Microsoft.Extensions.DependencyInjection;
using NFeExternas.Core.Interface;
using NFeExternas.Core.Servicos;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Servicos;
using NFe.Infraestrutura.Repositorio;

namespace NFe.Infraestrutura.IoC
{
    public class IoCRegistraServico
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton<IServicoNFeExterna, ServicoNFeExterna>();
            
            services.AddTransient(typeof(IServico<>), typeof(Servico<>));
            services.AddTransient<IServicoLogNFeProcessada, ServicoLogNFeProcessada>();
            services.AddTransient<IServicoNFeProcessada, ServicoNFeProcessada>();
            services.AddTransient<IServicoInformacaoNFe, ServicoInformacaoNFe>();
            services.AddTransient<IServicoIde, ServicoIde>();
            services.AddTransient<IServicoEmissor, ServicoEmissor>();
            services.AddTransient<IServicoEndereco, ServicoEndereco>();
            services.AddTransient<IServicoDestinatario, ServicoDestinatario>();
            services.AddTransient<IServicoProdutoNFe, ServicoProdutoNFe>();
            services.AddTransient<IServicoLogAlteracaoNfeProcessada, ServicoLogAlteracaoNfeProcessada>();

            services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddTransient<IRepositorioLogNFeProcessada, RepositorioLogNFeProcessada>();
            services.AddTransient<IRepositorioNFeProcessada, RepositorioNFeProcessada>();
            services.AddTransient<IRepositorioInformacaoNFe, RepositorioInformacaoNFe>();
            services.AddTransient<IRepositorioIde, RepositorioIde>();
            services.AddTransient<IRepositorioEmissor, RepositorioEmissor>();
            services.AddTransient<IRepositorioEndereco, RepositorioEndereco>();
            services.AddTransient<IRepositorioDestinatario, RepositorioDestinatario>();
            services.AddTransient<IRepositorioProdutoNFe, RepositorioProdutoNFe>();
            services.AddTransient<IRepositorioLogAlteracaoNfeProcessada, RepositorioLogAlteracaoNFeProcessada>();
        }
    }
}
