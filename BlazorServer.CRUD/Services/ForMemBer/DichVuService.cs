using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services.ForMemBer
{
    public class DichVuService
    {
        private readonly HttpClient _httpClient;
        public DichVuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<List<DichVuRequest>> GetAllDichVu()
        {
            var result = _httpClient.GetFromJsonAsync<List<DichVuRequest>>("/api/dichvu");
            return result;
        }
    }
}
