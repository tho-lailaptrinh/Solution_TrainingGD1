using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.ForMemBerRequest
{
    public class DichVuRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public string Description { get; set; }
    }
}
