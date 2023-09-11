using QrAmparoApp.Models;
using QrAmparoApp.Services.Idosos;
using QrAmparoApp.Views.Idosos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QrAmparoApp.ViewModels.Idosos
{
    public class ListagemIdosoViewModel : BaseViewModel
    {
        private IdosoService aService;

        public ObservableCollection<Idoso> Idosos { get; set; }

        public ListagemIdosoViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();

            aService = new IdosoService(token);
            Idosos = new ObservableCollection<Idoso>();
        }

        public async Task ObterIdososAsync()
        {
            Idosos = await aService.GetIdososAsync();
            OnPropertyChanged(nameof(Idosos));
        }


        public ICommand ObterIdosos
        {
            get
            {
                return new Command(async () =>
                {
                    try //Junto com o Cacth evitará que erros fechem o aplicativo
                    {
                        Idosos = await aService.GetIdososAsync();
                        OnPropertyChanged(nameof(Idosos)); //Informará a View que houve carregamento
                    }
                    catch (Exception ex)
                    {
                        //Captará o erro para exibir em tela
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
                    }
                });
            }
        }

        public ICommand NovoIdoso
        {
            get
            {
                return new Command(async () =>
                {
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CadastroIdosoView());
                });
            }
        }


        private Idoso idosoSelecionado;
        public Idoso IdosoSelecionado
        {
            get { return IdosoSelecionado; }
            set
            {
                if (value != null)
                {
                    idosoSelecionado = value;

                    ((MasterDetailPage)App.Current.MainPage).Detail
                    .Navigation.PushAsync(new CadastroIdosoView(IdosoSelecionado));
                }

            }
        }

        public ICommand RemoverIdoso
        {
            get => new Command<Idoso>(async (Idoso a) =>
            {
                if (await Application.Current.MainPage
                .DisplayAlert("Confirmação", $"Confirma a remoção de {a.Nome}?", "Sim", "Não"))
                {
                    await aService.DeleteIdosoAsync(a.Id);
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Idoso removido com sucesso", "Ok");

                    ObterIdosos.Execute(null);
                }
            });
        }
    }
}
