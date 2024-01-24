using System;
using System.Collections.Generic;

namespace PhongKhamNhaKhoa.Api.Entitis
{
    public class ImageFile
    {
        public Guid Id { get; set; }
        public string ImageString { get; set; }
        public virtual ICollection<KhachHang>? KhachHangs { get; set; }
    }
}
