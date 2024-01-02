using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
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
    }
}
