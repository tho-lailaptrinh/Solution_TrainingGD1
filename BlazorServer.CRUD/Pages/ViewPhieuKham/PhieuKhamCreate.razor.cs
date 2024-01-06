
using BlazorServer.CRUD.Component;
using BlazorServer.CRUD.Component.Confir;
using BlazorServer.CRUD.Services;
using BlazorServer.CRUD.Services.ForMemBer;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Pages.ViewPhieuKham
{
    public partial class PhieuKhamCreate
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }
        [Inject] private KhachHangService KhachHangSer { get; set; }
        [Inject] private NhanVienService NhanVienSer { get; set; }
        [Inject] private DichVuService DichVuSer { get; set; }
        [Inject] private PhongKhamService PhongKhamSer { get; set; }

        //Confirmation
        protected ConfirmationSuccess CreateConfirmation { get; set; }

        // khai báo và khởi tạo giá trị form
        private PhieuKhamCreateRequest NewPhieuKham = new PhieuKhamCreateRequest();
        private List<KhachHangRequest> lstKhachHang;
        private List<NhanVienRequest> lstNhanVien;
        private List<DichVuRequest> lstDichVu;
        private List<PhongKhamRequest> lstPhongKham;

        // khai báo 1 list để lấy thông tin tìm kiếm trong forech
        //public List<PhieuKhamRequest> ListPhieuKham;
        protected override async Task OnInitializedAsync()
        {
            //ListPhieuKham = await PhieuKhamService.GetListPK();
            lstKhachHang = await KhachHangSer.GetAllKhachHang();
            lstNhanVien = await NhanVienSer.GetAllNhanVien();
            lstDichVu = await DichVuSer.GetAllDichVu();
            lstPhongKham = await PhongKhamSer.GetAllPhongKham();
        }

        public async Task SubmitForm()
        {
            CreateConfirmation.Show();
        }
        public async Task OnSubmitForm(bool createphieukham)
        {
            if(createphieukham == true)
            {
                await PhieuKhamService.CreatePhieuKham(NewPhieuKham);
                NavigationManager.NavigateTo("/phieukham");
                ToastService.ShowSuccess($"Đã thêm thành công rồi nhé em!", "Success");
            }
            else
            {
                ToastService.ShowError($"Có lỗi rồi thằng ngu. Xem lại đi!!", "Error");
            }
            //var result = await PhieuKhamService.CreatePhieuKham(NewPhieuKham);
            //if (result == true)
            //{
            //    ToastService.ShowSuccess($"{NewPhieuKham.Name} đã được thêm thành công rồi nhé em!.", "Success");
            //    NavigationManager.NavigateTo("/phieukham");
            //}
            //else
            //{
            //    ToastService.ShowError($"Có lỗi rồi thằng ngu. Xem lại đi!!", "Error");
            //}
        }
    }
}
