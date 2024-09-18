namespace GestaoIptv.UI.Entities;

public class Endereco : IDisposable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public Int16 NumeroResidencial { get; set; }

    public Endereco(string logradouro, string bairro, string municipio, Int16 numeroResidencial)
    {
        Logradouro = logradouro;
        Bairro = bairro;
        Municipio = municipio;
        NumeroResidencial = numeroResidencial;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
