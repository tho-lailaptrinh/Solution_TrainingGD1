using BlazorServer.CRUD.Pages;
using PhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public class PhieuKhamService : IPhieuKhamService
    {
        private HttpClient _httpClient;
        public PhieuKhamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PhieuKhamRequeset>> GetListPK()
        {
            // gửi yêu cầu đến Api
            var result = await _httpClient.GetFromJsonAsync<List<PhieuKhamRequeset>>("/api/phieukham");
            return result;
        }
    }
}
