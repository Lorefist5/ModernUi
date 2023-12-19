using ModernUi.Data.Model.Base;
using ModernUi.Data.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.Data.Repositories.Web
{
    public class GenericRepositoryWeb<T> : IGeneric<T> where T : BaseEntity
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        public string ApiEndpoint;
        public GenericRepositoryWeb(HttpClient httpClient, string apiEndpoint)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiEndpoint = apiEndpoint ?? throw new ArgumentNullException(nameof(apiEndpoint));
            ApiEndpoint = typeof(T).Name;
        }

        public async Task Add(T entity)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiEndpoint}api/{typeof(T).Name}", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(T entity)
        {
            var response = await _httpClient.DeleteAsync($"{_apiEndpoint}api/{typeof(T).Name}/{entity.Id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var response = await _httpClient.GetStringAsync($"{_apiEndpoint}api/{typeof(T).Name}");
            return JsonConvert.DeserializeObject<IEnumerable<T>>(response);
        }

        public async Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }


    }
}
