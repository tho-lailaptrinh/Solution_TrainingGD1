using BlazorServer.CRUD.Services;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Enum;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Pages.ViewPhieuKham
{
    public partial class PhieuKham
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }

        public List<PhieuKhamRequest> ListPhieuKham;

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
    }

}
