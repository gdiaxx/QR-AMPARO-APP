using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrAmparoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageView : ContentPage
    {
        public Models.MenuItem[] OpcoesMenu { get; set; }
        public ListView ListView { get; set; }

        public MasterPageView()
        {
            InitializeComponent();

            DefinirMenu();

            ListView = itensMenuListView;
            BindingContext = this;

        }

        public void DefinirMenu()
        {
            OpcoesMenu = new[]
            {
                new Models.MenuItem
                {
                    Id = 0,
                    Title = "Responsáveis",
                    TargetType = typeof(Views.Responsaveis.ListagemView),
                    IconSource = "MenuUsuarios.png"
                },
                new Models.MenuItem
                {
                    Id = 1,
                    Title = "Idosos",
                    TargetType = typeof(Views.Idosos.ListagemView),
                    IconSource = "idoso.jpg"
                },
            };
        }

        public string Login
        {
            get
            {
                string login = string.Empty;

                if (Application.Current.Properties.ContainsKey("UsuarioUsername"))
                    login = Application.Current.Properties["UsuarioUsername"].ToString();

                return string.Format("Login: {0}", login);
            }
        }



    }
}