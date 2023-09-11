using QrAmparoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrAmparoApp.Services.Idosos
{
    public class IdosoService : Request
    {

        private readonly Request _request = null;

        private string _token;
        private const string ApiUrlBase = "http://BarbaraSantos.somee.com/QrAmparo/Idoso";

        public IdosoService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Idoso> PostIdosoAsync(Idoso a)
        {
            return await _request.PostAsync(ApiUrlBase, a, _token);
        }
        public async Task<ObservableCollection<Idoso>> GetIdososAsync()
        {

            ObservableCollection<Models.Idoso> listaIdosos = await
                _request.GetAsync<ObservableCollection<Models.Idoso>>(ApiUrlBase, _token);

            return listaIdosos;
        }
        public async Task<ObservableCollection<Idoso>> GetIdosoAsync(int idosoId)
        {
            ObservableCollection<Models.Idoso> listaIdosos = await
                _request.GetAsync<ObservableCollection<Models.Idoso>>(ApiUrlBase, _token);

            var idosoFiltrado = listaIdosos.Where(a => a.Id == idosoId);

            return new ObservableCollection<Idoso>(idosoFiltrado);
        }
        public async Task<Idoso> PutIdosoAsync(Idoso a)
        {
            var result = await _request.PutAsync(ApiUrlBase, a, _token);

            return result;
        }
        public async Task<Idoso> DeleteIdosoAsync(int idosoId)
        {
            string urlComplementar = string.Format("/{0}", idosoId);

            await _request.DeleteAsync(ApiUrlBase + urlComplementar, _token);

            return new Idoso() { Id = idosoId };
        }


    }
}
