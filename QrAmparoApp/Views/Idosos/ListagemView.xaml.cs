

using QrAmparoApp.ViewModels.Idosos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrAmparoApp.Views.Idosos
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class ListagemView : ContentPage
        {
            private ListagemIdosoViewModel viewModel;
            public ListagemView()
            {
                InitializeComponent();
                viewModel = new ListagemIdosoViewModel();

                BindingContext = viewModel;
            }

            protected override void OnAppearing()
            {
                base.OnAppearing();

                /*Device.BeginInvokeOnMainThread(async () =>
                {
                    await viewModel.ObterPersonagensAsync();
                });*/   // - Esse não tem tratamento de erro.

                viewModel.ObterIdosos.Execute(null);
            }

            protected override void OnDisappearing()
            {
                base.OnDisappearing();
            }
        }
    }