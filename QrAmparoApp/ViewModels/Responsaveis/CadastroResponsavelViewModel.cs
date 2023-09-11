using QrAmparoApp.Models;
using QrAmparoApp.Services.Responsavel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QrAmparoApp.ViewModels.Responsaveis
{
    public class CadastroResponsavelViewModel : BaseViewModel
    {
        private ResponsavelService pService;

        public CadastroResponsavelViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            pService = new ResponsavelService(token);
        }

        public int id;
        public string nome;
        public string cpf;
        public string telefone;
        public string endereco;
        public DateTime dataNascimento;
        public string rg;
        public string sexo;
        public string email;
        public string grauParentesco;

        //CTRL + R,E - Cria todas as propriedades
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
                OnPropertyChanged();

            }
        }
        public string Telefone
        {
            get => telefone;
            set
            {
                telefone = value;
                OnPropertyChanged();
            }
        }
        public string Endereco
        {
            get => endereco;
            set
            {
                endereco = value;
                OnPropertyChanged();
            }
        }
        public DateTime DataNascimento
        {
            get => dataNascimento;
            set
            {
                dataNascimento = value;
                OnPropertyChanged();
            }
        }
        public string Rg
        {
            get => rg;
            set
            {
                rg = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Sexo
        {
            get => sexo;
            set
            {
                sexo = value;
                OnPropertyChanged();
            }
        }
        public string GrauParentesco
        {
            get => grauParentesco;
            set
            {
                grauParentesco = value;
                OnPropertyChanged();
            }
        }


        public ICommand SalvarResponsavel
        {
            get => new Command(async () =>
            {
                try
                {
                    ResponsavelQr model = new ResponsavelQr()
                    {

                        Id = this.id,
                        Nome = this.nome,
                        Cpf = this.cpf,
                        Telefone = this.telefone,
                        Endereco = this.endereco,
                        DataNascimento = this.dataNascimento,
                        Rg = this.rg,
                        Sexo = this.sexo,
                        Email = this.email,
                        GrauParentesco = this.grauParentesco

                    };

                    if (model.Id == 0)
                        await pService.PostResponsavelAsync(model);
                    else
                        await pService.PutResponsavelAsync(model);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvo com sucesso", "Ok");
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
                }
                catch (System.Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "Ok");
                }
            });

        }

        public ICommand VerResponsavel
        {
            get => new Command<ResponsavelQr>(async (ResponsavelQr model) =>
            {
                try
                {


                    this.id = model.Id;
                    this.nome = model.Nome;
                    this.cpf = model.Cpf;
                    this.telefone = model.Telefone;
                    this.endereco = model.Endereco;
                    this.dataNascimento = model.DataNascimento;
                    this.rg = model.Rg;
                    this.sexo = model.Sexo;
                    this.email = model.Email;
                    this.grauParentesco = model.GrauParentesco;


                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "Ok");
                }
            });

        }

    }
}

