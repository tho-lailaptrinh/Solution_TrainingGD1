﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Model
{
    public class PhieuKhamCreateRequest
    {
        public string Name { get; set; }
        public Guid IdDichVu {  get; set; }
        public Guid IdKhachHang {  get; set; }
        public Guid IdPhongKham { get; set; }
        public Guid IdNhanVien { get; set; }
    }
}
