using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model
{
    public   class LoginResponse // chả về những thứ tao cần ok
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }

    }
}
