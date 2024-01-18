using PhongKhamNhaKhoa.Model.ForMemBerRequest.NhanVienCreateRequest;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services.ForMemBer
{
    public class NhanVienService
    {
        private readonly HttpClient _httpClient;
        public NhanVienService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<NhanVienRequest>> GetAllNhanVien()
        {
            var result = _httpClient.GetFromJsonAsync<List<NhanVienRequest>>("/api/nhanvien");
            return result;
        }
        public async Task<bool> CreateNhanVienSer(NhanVienCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/nhanvien", request);
            return result.IsSuccessStatusCode;
        }
    }
}
