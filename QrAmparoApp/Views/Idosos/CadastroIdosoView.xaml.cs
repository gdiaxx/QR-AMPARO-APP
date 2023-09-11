using QrAmparoApp.Models;
using QrAmparoApp.ViewModels.Idosos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrAmparoApp.Views.Idosos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroIdosoView : ContentPage
    {
        private CadastroIdosoViewModel cadViewModel;
        public CadastroIdosoView()
        {
            InitializeComponent();

            this.cadViewModel = new CadastroIdosoViewModel();
            cadViewModel.DataNascimento = System.DateTime.Now.Date;
            this.BindingContext = cadViewModel;
            this.Title = "Novo Idoso";

            cadViewModel.ObterResponsaveis.Execute(null);

        }

        public CadastroIdosoView(Idoso a) : this()
        {
            this.Title = "Alterar Idoso";
            cadViewModel.VerIdoso.Execute(a);
        }
    }
}
