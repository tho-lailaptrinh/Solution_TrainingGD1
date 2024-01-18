using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using BlazorServer.CRUD.Component.Confir;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.NhanVienCreateRequest;
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

        //Confirmation
        protected ConfirmationSuccess UpdateConfirmation { get; set; }

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
            UpdateConfirmation.Show();
        }
        public async Task OnSubmitForm(bool createphieukham)
        {
            if (createphieukham == true)
            {
                await PhieukhamService.UpdatePhieuKhams(Guid.Parse(IdPK), UpdatePhieuKham);
                NavigationManager.NavigateTo("/phieukham");
                ToastService.ShowSuccess($"Đã sửa thành công rồi nhé em!", "Success");
            }
            else
            {
                ToastService.ShowError($"Có lỗi rồi thằng ngu. Xem lại đi!!", "Error");
            }


        }
    }
}
