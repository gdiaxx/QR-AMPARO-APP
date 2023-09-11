
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
    public partial class ListagemView : ContentPage
    {
        private ListagemResponsavelViewModel viewModel;
        public ListagemView()
        {
            InitializeComponent();
            viewModel = new ListagemResponsavelViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*Device.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.ObterPersonagensAsync();
            });*/   // - Esse não tem tratamento de erro.

            viewModel.ObterResponsaveis.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}