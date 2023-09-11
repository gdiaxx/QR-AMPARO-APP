using QrAmparoApp.Models;
using QrAmparoApp.Services.Idosos;
using QrAmparoApp.Services.Responsavel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QrAmparoApp.ViewModels.Idosos
{
    class CadastroIdosoViewModel : BaseViewModel
    {
        private IdosoService aService;
        private ResponsavelService pService;
        public CadastroIdosoViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            aService = new IdosoService(token);
            pService = new ResponsavelService(token);
        }
        public ObservableCollection<ResponsavelQr> Responsaveis { get; set; }

        public ICommand ObterResponsaveis
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        Responsaveis = await pService.GetResponsaveisAsync();
                        OnPropertyChanged(nameof(Responsaveis)); //Informará a View que houve carregamento                       
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
                    }
                });
            }
        }

        private int id;
        private string nome;
        private string cpf;
        private string rg;
        private string endereco;
        private DateTime dataNascimento;
        private string doenca;
        private string sexo;
        private string tipoSanguineo;
        private string numeroSUS;
        private ResponsavelQr responsavelSelecionado;



        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        public string Cpf
        {
            get => cpf;
            set
            {
                cpf = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string Rg
        {
            get => rg;
            set
            {
                rg = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string Endereco
        {
            get => endereco;
            set
            {
                endereco = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }

        public DateTime DataNascimento
        {
            get => dataNascimento;
            set
            {
                dataNascimento = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string Doenca
        {
            get => doenca;
            set
            {
                doenca = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string Sexo
        {
            get => sexo;
            set
            {
                sexo = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string TipoSanguineo
        {
            get => tipoSanguineo;
            set
            {
                tipoSanguineo = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public string NumeroSUS
        {
            get => numeroSUS;
            set
            {
                numeroSUS = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }



        public ResponsavelQr ResponsavelSelecionado
        {
            get => responsavelSelecionado;
            set
            {
                responsavelSelecionado = value;
                OnPropertyChanged(); //Informa mudanca de estado para a View.
            }
        }


        public ICommand SalvarIdoso
        {
            get => new Command(async () =>
            {
                try
                {
                    Idoso model = new Idoso()
                    {
                        Id = this.id,
                        Nome = this.nome,
                        Cpf = this.cpf,
                        Rg = this.rg,
                        Endereco = this.endereco,
                        DataNascimento = this.dataNascimento,
                        Doenca = this.doenca,
                        Sexo = this.sexo,
                        TipoSanguineo = this.tipoSanguineo,
                        NumeroSUS = this.numeroSUS,
                        ResponsavelId = this.responsavelSelecionado.Id

                    };

                    if (model.Id == 0)
                        await aService.PostIdosoAsync(model);
                    else
                        await aService.PutIdosoAsync(model);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvo com sucesso", "Ok");
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
                }
                catch (System.Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "Ok");
                }
            });
        }

        public ICommand VerIdoso
        {
            get => new Command<Idoso>(async (Idoso model) =>
            {
                try
                {

                    this.id = model.Id;
                    this.nome = model.Nome;
                    this.cpf = model.Cpf;
                    this.rg = model.Rg;
                    this.endereco = model.Endereco;
                    this.dataNascimento = model.DataNascimento;
                    this.doenca = model.Doenca;
                    this.sexo = model.Sexo;
                    this.tipoSanguineo = model.TipoSanguineo;
                    this.numeroSUS = model.NumeroSUS;
                    this.responsavelSelecionado.Id = model.ResponsavelId; 

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "Ok");
                }
            });

        }


    }
}

