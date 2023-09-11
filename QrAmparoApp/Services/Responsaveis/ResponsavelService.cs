using QrAmparoApp.Models;
using QrAmparoApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrAmparoApp.Services.Responsavel
{
    public class ResponsavelService : Request
    {
        private readonly Request _request = null;
        private string _token;
        private const string ApiUrlBase = "http://BarbaraSantos.somee.com/QrAmparo/Responsavel";

        public ResponsavelService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<ResponsavelQr> PostResponsavelAsync(ResponsavelQr p)
        {
            return await _request.PostAsync(ApiUrlBase, p, _token);
        }
        public async Task<ObservableCollection<ResponsavelQr>> GetResponsaveisAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Models.ResponsavelQr> listaResponsaveis = await
                _request.GetAsync<ObservableCollection<Models.ResponsavelQr>>(ApiUrlBase + urlComplementar, _token);

            return listaResponsaveis;
        }
        public async Task<ObservableCollection<ResponsavelQr>> GetResponsavelAsync(int responsavelId)
        {
            ObservableCollection<Models.ResponsavelQr> listaResponsaveis = await
                _request.GetAsync<ObservableCollection<Models.ResponsavelQr>>(ApiUrlBase, _token);

            var responsavelFiltrado = listaResponsaveis.Where(p => p.Id == responsavelId);

            return new ObservableCollection<ResponsavelQr>(responsavelFiltrado);
        }
        public async Task<ResponsavelQr> PutResponsavelAsync(ResponsavelQr p)
        {
            var result = await _request.PutAsync(ApiUrlBase, p, _token);

            return result;
        }
        public async Task<ResponsavelQr> DeleteResponsavelAsync(int responsavelId)
        {
            string urlComplementar = string.Format("/{0}", responsavelId);

            await _request.DeleteAsync(ApiUrlBase + urlComplementar, _token);

            return new ResponsavelQr() { Id = responsavelId };
        }

        public async Task<ObservableCollection<ResponsavelQr>> GetResponsaveisByNomeAsync(string busca)
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Models.ResponsavelQr> listaResponsaveis = await
                _request.GetAsync<ObservableCollection<Models.ResponsavelQr>>(ApiUrlBase + urlComplementar, _token);

            var responsaveisFiltrados = listaResponsaveis.Where(p => p.Nome.ToLower().Contains(busca.ToLower()));

            return new ObservableCollection<ResponsavelQr>(responsaveisFiltrados);
        }


    }
}
