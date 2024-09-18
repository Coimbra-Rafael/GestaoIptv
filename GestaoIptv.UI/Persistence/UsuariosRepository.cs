using Dapper;
using GestaoIptv.UI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoIptv.UI.Persistence;

public class UsuariosRepository : IDisposable
{
    private readonly string _connectionString = "Data Source=GestaoIptvDatabase.db";

    public async Task<IEnumerable<Usuarios>> GetAllUsers()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT Id, Email, NomeUsuario, Password From Usuarios";
            return await connection.QueryAsync<Usuarios>(query);
        }
    }

    public async Task<Usuarios?> GetUsersByEmail(string email) 
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT Id, Email, NomeUsuario, Password From Usuarios Where Email = @Email";
            return await connection.QuerySingleOrDefaultAsync<Usuarios>(query, new { Email = email });
        }
    }

    public async Task<Usuarios?> GetUsersByNomeUsuario(string nomeUsuario)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT Id, Email, NomeUsuario, Password From Usuarios Where NomeUsuario = @NomeUsuario";
            return await connection.QuerySingleOrDefaultAsync<Usuarios>(query, new { NomeUsuario = nomeUsuario });
        }
    }

    public async Task<Usuarios?> GetUsersByNomeUsuarioAndPassword(string nomeUsuario, string password)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT Id, Email, NomeUsuario, Password FROM Usuarios WHERE NomeUsuario = @NomeUsuario AND Password = @password";
            return await connection.QuerySingleOrDefaultAsync<Usuarios>(query, new { NomeUsuario = nomeUsuario, Password = password });
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
