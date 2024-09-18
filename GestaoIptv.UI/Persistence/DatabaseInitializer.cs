using System.Data.SQLite;

namespace GestaoIptv.UI.Persistence;

public class DatabaseInitializer : IDisposable
{
    public void InitializeDatabase()
    {
        try
        {
            if (!File.Exists("GestaoIptvDatabase.db"))
            {

                SQLiteConnection.CreateFile("GestaoIptvDatabase.db");
                using (var connection = new SQLiteConnection("Data Source=GestaoIptvDatabase.db"))
                {
                    connection.Open();

                    string createTableUsuarios = @"
                    CREATE TABLE IF NOT EXISTS Usuarios (
                        id TEXT PRIMARY KEY,       
                        Email TEXT NOT NULL,
                        NomeUsuario TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );
                ";

                    string createTableClientes = @"
                    CREATE TABLE IF NOT EXISTS Clientes (
                        Id TEXT PRIMARY KEY,
                        NomeCliente TEXT NOT NULL,
                        Telefone TEXT NOT NULL,
                        EnderecoId TEXT,                      
                        FOREIGN KEY (EnderecoId) REFERENCES Endereco(Id) 
                    );
                ";

                    string createTableEnderecos = @"
                    CREATE TABLE IF NOT EXISTS Enderecos (
                        Id TEXT PRIMARY KEY,
                        Logradouro TEXT NOT NULL,
                        Bairro TEXT NOT NULL,
                        Municipio TEXT NOT NULL,
                        NumeroResidencial INTEGER NOT NULL 
                    );
                ";

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createTableUsuarios;
                        command.ExecuteNonQuery();

                        command.CommandText = createTableClientes;
                        command.ExecuteNonQuery();

                        command.CommandText = createTableEnderecos;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (Exception ex) 
        {
            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
