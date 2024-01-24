using PhongKhamNhaKhoa.Model.Users;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace BlazorServer.CRUD.Services
{
    public class UserService
    {
        private List<UserAccount> userAccounts;

        //private readonly HttpClient _httpClient;
        public UserService()
        {
            //_httpClient = httpClient;
            userAccounts = new List<UserAccount>
            {
                new UserAccount{UserName = "admin", Password = "admin123", Role ="Adminstrator" },
                new UserAccount{UserName = "user", Password = "user123", Role ="User" }
            };
        }
        public UserAccount GetByIdUser(string useName)
        {
            return userAccounts.FirstOrDefault(x => x.UserName == useName);
        }

    }
}
