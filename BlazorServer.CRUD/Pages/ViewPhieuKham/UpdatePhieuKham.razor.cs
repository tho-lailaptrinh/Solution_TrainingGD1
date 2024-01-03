using BlazorServer.CRUD.Services.ForMemBer;
using BlazorServer.CRUD.Services;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Pages.ViewPhieuKham
{
    public partial class UpdatePhieuKham
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }
        [Inject] private KhachHangService KhachHangSer { get; set; }
        [Inject] private NhanVienService NhanVienSer { get; set; }
        [Inject] private DichVuService DichVuSer { get; set; }
        [Inject] private PhongKhamService PhongKhamSer { get; set; }
        // khai báo và khởi tạo giá trị form
        private List<PhieuKhamRequeset> ListPhieuKham;

        private PhieuKhamUpdateRequest UpdatePK = new PhieuKhamUpdateRequest();

        private List<KhachHangRequest> lstKhachHang;

        private List<NhanVienRequest> lstNhanVien;

        private List<DichVuRequest> lstDichVu;

        private List<PhongKhamRequest> lstPhongKham;

        // khai báo 1 list để lấy thông tin tìm kiếm trong forech
        //public List<PhieuKhamRequest> ListPhieuKham;
        protected override async Task OnInitializedAsync()
        {
            ListPhieuKham = await PhieuKhamService.GetListPK();
            lstKhachHang = await KhachHangSer.GetAllKhachHang();
            lstNhanVien = await NhanVienSer.GetAllNhanVien();
            lstDichVu = await DichVuSer.GetAllDichVu();
            lstPhongKham = await PhongKhamSer.GetAllPhongKham();
            phieukham = await PhieuKhamService.GetListPKCT(IdPK);
        }

        private Task SubmitForm()
        {
            return null;
        }
        [Parameter]
        public string IdPK { get; set; }
        public PhieuKhamRequeset phieukham { get; set; }
    }
}
