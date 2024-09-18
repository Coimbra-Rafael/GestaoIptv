namespace GestaoIptv.UI.Entities;

public class Clientes : IDisposable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeCliente { get; set; }
    public string Telefone { get; set; }
    public Guid? EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }

    public Clientes(string nomeCliente, string telefone)
    {
        NomeCliente = nomeCliente;
        Telefone = telefone;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
