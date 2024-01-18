using PhongKhamNhaKhoa.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.ForMemBerRequest.NhanVienCreateRequest
{
    public class NhanVienRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberPhone { get; set; }
        public string AddressNV { get; set; }
        public Position Position { get; set; }
    }
}
