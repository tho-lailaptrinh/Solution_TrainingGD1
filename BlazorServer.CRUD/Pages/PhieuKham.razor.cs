using BlazorServer.CRUD.Services;
using Microsoft.AspNetCore.Components;
using PhongKhamNhaKhoa.Enum;
using PhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.CRUD.Pages
{
    public partial class PhieuKham
    {
        [Inject] private IPhieuKhamService PhieuKhamService { get; set; }

        public List<PhieuKhamRequeset> ListPhieuKham;

        protected async override Task OnInitializedAsync()
        {
            ListPhieuKham = await PhieuKhamService.GetListPK();
        }
    }
   
}
