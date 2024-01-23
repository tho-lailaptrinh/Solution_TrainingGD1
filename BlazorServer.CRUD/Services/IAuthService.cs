using PhongKhamNhaKhoa.Model;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Services
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task Logout();
    }
}
