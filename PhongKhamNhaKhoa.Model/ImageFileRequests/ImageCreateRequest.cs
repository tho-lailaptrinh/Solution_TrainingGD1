using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.ImageFileRequests
{
    public class ImageCreateRequest
    {
        public Guid Id { get; set; }
        public string ImageString { get; set; }
    }
}
