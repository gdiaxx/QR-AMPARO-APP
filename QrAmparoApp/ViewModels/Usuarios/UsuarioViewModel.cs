using QrAmparoApp.Models;
using QrAmparoApp.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QrAmparoApp.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        public ICommand EntrarCommand { get; set; }
        private Usuario Usuario;
        private UsuarioService uService = new UsuarioService();

        public UsuarioViewModel()
        {
            //Instancia o objeto Usuario e registra os comandos
            this.Usuario = new Usuario();
            RegistrarCommands();
        }
        public async Task ConsultarUsuario()
        {
            Usuario u = null;
            u = await uService.PostLoginUsuarioAsync(Usuario);
            MessagingCenter.Send<Usuario>(u, "InformacaoCRUD");
        }

        public void RegistrarCommands()
        {
            // A View acionará este evento quando esta classe
            // for vinculada a ela

            EntrarCommand = new Command(async () =>
            {
                await ConsultarUsuario();
            });
        }

        public string Login
        {
            get { return this.Usuario.Username; }
            set
            {
                this.Usuario.Username = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.Usuario.PasswordString; }
            set
            {
                this.Usuario.PasswordString = value;
                OnPropertyChanged();
            }
        }

    }
}
