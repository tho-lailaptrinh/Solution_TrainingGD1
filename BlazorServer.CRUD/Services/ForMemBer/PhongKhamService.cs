using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services.ForMemBer
{
    public class PhongKhamService
    {
        private readonly HttpClient _httpClient;
        public PhongKhamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<List<PhongKhamRequest>> GetAllPhongKham()
        {
            var result = _httpClient.GetFromJsonAsync<List<PhongKhamRequest>>("/api/phongkham");
            return result;
        }

    }
}
