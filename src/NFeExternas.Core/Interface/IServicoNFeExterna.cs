using NFeExternas.Core.Entidades;

namespace NFeExternas.Core.Interface
{
    public interface IServicoNFeExterna
    {   
        Task<DadoNFeExterna> ObtemAsync(int id);
        void CriarVarios(IEnumerable<DadoNFeExterna> dadosNFeExterna);
        void ObterNotasServicoExterno(int idUltimaNotaProcessada);
        List<DadoNFeExterna> ObterNotasMaioresQueId(int idUltimaNotaProcessada);
    }
}