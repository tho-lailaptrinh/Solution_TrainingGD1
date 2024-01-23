using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model.ImageFileRequests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys.Image
{
    public interface IImageRepository
    {
        public Task<IEnumerable<ImageFile>> GetAllImage();
        public Task<ImageFile> UpdateImage(ImageUpdateRequest request);
    }
}
