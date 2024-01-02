using PhongKhamNhaKhoa.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model
{
    public class PhieuKhamRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameKH { get; set; }
        public string NameNV { get; set; }
        public string NameDV { get; set; }
        public string NamePK { get; set; }
        public DateTime CreateDate { get; set; }
        public Status? Status { get; set; }
    }
}
