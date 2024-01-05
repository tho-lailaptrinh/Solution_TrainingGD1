using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
namespace BlazorServer.CRUD.Pages.ViewPhieuKham
{
    public partial class PhieuKhamUpdate
    {
        [Parameter]
        public string IdPK { get; set; }

        public PhieuKhamUpdateRequest UpdatePhieuKham = new PhieuKhamUpdateRequest();
        private List<KhachHangRequest> lstKhachHang;
        private List<NhanVienRequest> lstNhanVien;
        private List<DichVuRequest> lstDichVu;
        private List<PhongKhamRequest> lstPhongKham;

        protected async override Task OnInitializedAsync()
        {
            lstKhachHang = await KhachHangSer.GetAllKhachHang();
            lstNhanVien = await NhanVienSer.GetAllNhanVien();
            lstDichVu = await DichVuSer.GetAllDichVu();
            lstPhongKham = await PhongKhamSer.GetAllPhongKham();

            var result = await PhieukhamService.GetByIdPhieuKham(IdPK);
            UpdatePhieuKham.Name = result.Name;
            UpdatePhieuKham.CreateDate = DateTime.Now;
        }
        public async Task SubmitForm()
        {
            var result = await PhieukhamService.UpdatePhieuKhams(Guid.Parse(IdPK), UpdatePhieuKham);
            if (result == true)
            {
                NavigationManager.NavigateTo("/phieukham");
            }
        }
    }
}
