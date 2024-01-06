using Blazored.Toast.Services;
using BlazorServer.CRUD.Component;
using BlazorServer.CRUD.Services;
using BlazorServer.CRUD.Services.ForMemBer;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Pages.ViewPhieuKham
{
    public partial class PhieuKham
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }

        //Comfirmation
        protected Confirmation DeleteConfirmation { get; set; }
        public Guid IdDeletePK { get; set; }


        public List<PhieuKhamRequeset> ListPhieuKham;

        protected async override Task OnInitializedAsync()
        {
            ListPhieuKham = await PhieuKhamService.GetListPK();
        }

        void ShowPhieuKham(string id)
        {
            NavigationManager.NavigateTo("/ /{id}");
        }

        public void CreateNewPhieuKham()
        {
            NavigationManager.NavigateTo("/phieukhamcreate");
        }

         public void UpdatePhieuKham(Guid id)
        {
            NavigationManager.NavigateTo($"/updatepk/{id}");
        }

        public async Task OnDeletePhieuKham(Guid deleteId)
        {
            IdDeletePK = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteKH(bool deleteConfirmation)
        {
            if (deleteConfirmation == true)
            {
                await PhieuKhamService.DeletePhieuKhams(IdDeletePK);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                ToastService.ShowSuccess($"Đã xóa thành công rồi nhé em!", "Success");
            }
        }
    }

}
