﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QrAmparoApp.Services
{
    public class Request
    {
        public async Task<string> PostReturnStringAsync<TResult>(string uri, TResult data)

        {

            HttpClient httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return serialized;
            else
                return string.Empty;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            /*string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));*/

            return data;
        }
        public async Task<TResult> GetAsync<TResult>(string uri, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }
        public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PutAsync(uri, content);
            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }
        public async Task DeleteAsync(string uri, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);

            await httpClient.DeleteAsync(uri);
        }

        public async Task<TResult> PostReturnObjectAsync<TResult>(string uri, TResult data, string token)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() =>
            JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }

    }
}
