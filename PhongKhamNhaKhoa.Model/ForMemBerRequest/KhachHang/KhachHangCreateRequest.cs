﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang
{
    public class KhachHangCreateRequest
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string AddressKH { get; set; }
    }
}
