using QrAmparoApp.Models;
using QrAmparoApp.ViewModels.Responsaveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrAmparoApp.Views.Responsaveis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class CadastroResponsavelView : ContentPage
    {
        private CadastroResponsavelViewModel cadViewModel;
        public CadastroResponsavelView()
        {
            InitializeComponent();

            this.cadViewModel = new CadastroResponsavelViewModel();
            
            cadViewModel.DataNascimento = DateTime.Now.Date;
            
            this.BindingContext = cadViewModel;
            this.Title = "Novo Responsavel";
        }

        public CadastroResponsavelView(ResponsavelQr p) : this()
        {
            this.Title = "Alterar Responsavel";
            cadViewModel.VerResponsavel.Execute(p);

        }
    }
}

