using PhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.View.Services
{
    public class PhieuKhamService : IPhieuKhamService
    {
        private HttpClient _httpClient;
        public PhieuKhamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreatePhieuKham(PhieuKhamCreateRequest CreatePK)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/phieukham", CreatePK);
            return result.IsSuccessStatusCode;
        }
            
        public async Task<List<PhieuKhamRequest>> GetListPK()
        {
            // gửi yêu cầu đến Api
            var result = await _httpClient.GetFromJsonAsync<List<PhieuKhamRequest>>("/api/phieukham");
            return result;
        }

        public async Task<List<PhieuKhamRequest>> GetListPKCT(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PhieuKhamRequest>>($"api/chitietpk/{id}");
            return result;
        }
    }
}
