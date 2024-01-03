using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services.ForMemBer
{
    public class KhachHangService
    {
        private readonly HttpClient _httpClient;
        public KhachHangService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<List<KhachHangRequest>> GetAllKhachHang()
        {
            var result = _httpClient.GetFromJsonAsync<List<KhachHangRequest>>("/api/khachhang");
            return result;
        }
        public async Task<bool> CreateKhachHang(KhachHangCreate request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/khachhang", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateKhachHang(KhachHangCreate request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/khachhang", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteKhachHang(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"/api/khachhang/{id}");
            return result.IsSuccessStatusCode;
        }
    }
}
