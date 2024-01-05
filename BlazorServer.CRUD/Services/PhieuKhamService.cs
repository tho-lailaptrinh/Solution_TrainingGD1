using PhongKhamNhaKhoa.Model;
using System;
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
        public async Task<bool> CreatePhieuKham(PhieuKhamCreateRequest CreatePK)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/phieukham", CreatePK);
            return result.IsSuccessStatusCode;
        }

        public async Task<PhieuKhamRequeset> GetByIdPhieuKham(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<PhieuKhamRequeset>($"api/PhieuKham/GetById/{id}");
            return result;
        }

        public async Task<bool> UpdatePhieuKhams(Guid id, PhieuKhamUpdateRequest UpdatePK)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/phieukham/{id}", UpdatePK);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePhieuKhams(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/phieukham/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
