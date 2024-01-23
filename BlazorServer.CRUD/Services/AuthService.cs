using Blazored.LocalStorage;
using BlazorServer.CRUD.Authentications;
using Microsoft.AspNetCore.Components.Authorization;
using PhongKhamNhaKhoa.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private AuthenticationStateProvider _authenticationStateProvider;
       // private readonly ApiAuthenticationStateProvider _apiAuthenticationStateProvider;
        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/login", loginRequest);
            var content = await result.Content.ReadAsStringAsync(); // result xong phải đọc qua dạng json
            // lấy ra được cái string, từ string trên phải dece nó ra
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.Token); // lưu trữ thông tin xác thực người login
            ((AbcAuthenticationState)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.Token);
            return loginResponse;
        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authenToken"); // logout chỉ cần remove cái authenToken + Mark Logout
            ((AbcAuthenticationState)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null; // Set Authorization Header null thì sẽ xóa hết đi
        }
    }
}
