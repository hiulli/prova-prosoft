using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;
using NFeExternas.Core.Entidades;
using NFeExternas.Core.Interface;
using NFeExternas.Core.Modelo;

namespace NFeExternas.Core.Servicos
{
    public class ServicoNFeExterna : IServicoNFeExterna
    {
        private readonly IMongoCollection<DadoNFeExterna>? _colecaoDadosNFeExterna;
        private readonly IOptions<ConfiguracaoServicoExterno> _configuracaoServicoExterno;

        public ServicoNFeExterna(IOptions<ConfiguracaoMongoDB> configuracaoMongoDB,
            IOptions<ConfiguracaoServicoExterno> configuracaoServicoExterno)
        {
            var mongoClient = new MongoClient(configuracaoMongoDB.Value.StringDeConexao);
            var mongoDatabase = mongoClient.GetDatabase(configuracaoMongoDB.Value.NomeBancoDeDados);

            _colecaoDadosNFeExterna = mongoDatabase.GetCollection<DadoNFeExterna>("NFeExterna");
            _configuracaoServicoExterno = configuracaoServicoExterno;
        }

        public void CriarVarios(IEnumerable<DadoNFeExterna> dadosNFeExterna) => _colecaoDadosNFeExterna.InsertMany(dadosNFeExterna);

        public async Task<DadoNFeExterna> ObtemAsync(int id) => await _colecaoDadosNFeExterna.Find(x => x.id == id).FirstOrDefaultAsync();

        public List<DadoNFeExterna> ObterNotasMaioresQueId(int idUltimaNotaProcessada) =>
            _colecaoDadosNFeExterna.Find(x => x.id > idUltimaNotaProcessada).ToList();

        public void ObterNotasServicoExterno(int idUltimaNotaProcessada)
        {   
            using (HttpClient cliente = new HttpClient())
            {
                var resposta = cliente.GetAsync(_configuracaoServicoExterno.Value.URLObtemNFe).GetAwaiter().GetResult();

                if (resposta.IsSuccessStatusCode)
                {
                    List<DadoNFeExterna>? lista = 
                        JsonConvert.DeserializeObject<List<DadoNFeExterna>>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult())
                        .Where(x => x.id > idUltimaNotaProcessada)
                        .ToList();

                    if (lista.Any()) 
                        CriarVarios(lista);
                }
            }
        }
    }
}
