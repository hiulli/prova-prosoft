namespace NFeInternas.Core.Modelo
{
    public class Resultado
    {
        public Resultado(object? dado, bool sucesso, string? mensage = null)
        {
            Dado = dado;
            Sucesso = sucesso;
            Mensagem = mensage;
        
        }

        public bool? Sucesso { get; private set; }
        public string? Mensagem { get; private set; }
        public object? Dado { get; private set; }
    }
}
