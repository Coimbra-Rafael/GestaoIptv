namespace GestaoIptv.UI.Entities;

public class Usuarios : IDisposable
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string NomeUsuario { get; set; }
    public string Password { get; set; }

    public Usuarios(string email, string nomeUsuario, string password)
    {
        Email = email;
        NomeUsuario = nomeUsuario;
        Password = password;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
