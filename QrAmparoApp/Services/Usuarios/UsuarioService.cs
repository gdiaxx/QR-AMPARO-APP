using QrAmparoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QrAmparoApp.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://BarbaraSantos.somee.com/QrAmparo/Usuarios"; //UsuarioAdmin - 123456

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostLoginUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/autenticar";
            u.Token = await _request.PostReturnStringAsync(apiUrlBase + urlComplementar, u);

            return u;
        }
    }
}
