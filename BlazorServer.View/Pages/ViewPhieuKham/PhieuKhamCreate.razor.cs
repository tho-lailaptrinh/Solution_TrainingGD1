﻿
using BlazorServer.View.Services;
using BlazorServer.View.Services.ForMemBer;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model;
using PhongKhamNhaKhoa.Model.ForMemBerRequest;
using PhongKhamNhaKhoa.Model.ForMemBerRequest.KhachHang;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.View.Pages.ViewPhieuKham
{
    public partial class PhieuKhamCreate
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }
        [Inject] private KhachHangService KhachHangSer { get; set; }
        [Inject] private NhanVienService NhanVienSer { get; set; }
        [Inject] private DichVuService DichVuSer { get; set; }
        [Inject] private PhongKhamService PhongKhamSer { get; set; }
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
            var result = await PhieuKhamService.CreatePhieuKham(NewPhieuKham);
            if (result == true)
            {
                ToastService.ShowSuccess("has been created successfully");
                NavigationManager.NavigateTo("/phieukham");
            }
            else
            {
                ToastService.ShowError($"An error occurred in progress. Please contact to administrator");
            }
        }
    }
}