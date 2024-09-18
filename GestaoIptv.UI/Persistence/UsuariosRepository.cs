using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoIptv.UI.Persistence;

public class UsuariosRepository : IDisposable
{
    private readonly string _connectionString = "Data Source=iptv.db";
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
