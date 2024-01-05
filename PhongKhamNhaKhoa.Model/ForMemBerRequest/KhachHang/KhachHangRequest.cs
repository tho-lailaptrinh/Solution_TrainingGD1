using PhongKhamNhaKhoa.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang
{
    public class KhachHangRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string AddressKH { get; set; }
        public StatusKH StatusKH { get; set; }
    }
}
