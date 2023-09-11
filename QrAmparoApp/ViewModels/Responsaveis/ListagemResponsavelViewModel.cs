using QrAmparoApp.Models;
using QrAmparoApp.Services.Responsavel;
using QrAmparoApp.Views.Responsaveis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QrAmparoApp.ViewModels.Responsaveis
{
    public class ListagemResponsavelViewModel : BaseViewModel
    {
        private ResponsavelService pService;
        public ObservableCollection<ResponsavelQr> Responsaveis { get; set; }

        public ListagemResponsavelViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();

            pService = new ResponsavelService(token);
            Responsaveis = new ObservableCollection<ResponsavelQr>();
        }

        public async Task ObterResponsaveisAsync()
        {
            Responsaveis = await pService.GetResponsaveisAsync();
            OnPropertyChanged(nameof(Responsaveis));
        }

        public ICommand ObterResponsaveis
        {
            get
            {
                return new Command(async () =>
                {
                    try //Junto com o Cacth evitará que erros fechem o aplicativo
                    {
                        Responsaveis = await pService.GetResponsaveisAsync();
                        OnPropertyChanged(nameof(Responsaveis)); //Informará a View que houve carregamento                       
                    }
                    catch (Exception ex)
                    {
                        //Captará o erro para exibir em tela
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
                    }
                });
            }
        }

        public ICommand NovoResponsavel
        {
            get
            {
                return new Command(async () =>
                {
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new CadastroResponsavelView());
                });
            }
        }

        private ResponsavelQr responsavelSelecionado;
        public ResponsavelQr ResponsavelSelecionado
        {
            get { return responsavelSelecionado; }
            set
            {
                if (value != null)
                {
                    responsavelSelecionado = value;
                 
                }

            }
        }

        public ICommand RemoverResponsavel
        {
            get => new Command<ResponsavelQr>(async (ResponsavelQr p) =>
            {
                if (await Application.Current.MainPage
                .DisplayAlert("Confirmação", $"Confirma a remoção de {p.Nome}?", "Sim", "Não"))
                {
                    await pService.DeleteResponsavelAsync(p.Id);
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Personagem removido com sucesso", "Ok");

                    ObterResponsaveis.Execute(null);
                }
            });
        }

    }
}
