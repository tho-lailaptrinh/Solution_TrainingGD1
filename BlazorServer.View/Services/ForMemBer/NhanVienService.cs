﻿using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.View.Services.ForMemBer
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
    }
}
