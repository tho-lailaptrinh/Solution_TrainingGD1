using Microsoft.EntityFrameworkCore;
using PhongKhamNhaKhoa.Api.Data;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model.ImageFileRequests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Repositorys.Image
{
    public class ImageRepository : IImageRepository
    {
        private readonly MyDbContext _dbContext;

        public ImageRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ImageFile>> GetAllImage()
        {
            return await _dbContext.Set<ImageFile>().ToListAsync();
        }

        public async Task<ImageFile> UpdateImage(ImageUpdateRequest request)
        {
            var imageFile = await _dbContext.Set<ImageFile>().FirstOrDefaultAsync();
            if (imageFile != null)
            {
                imageFile.ImageString = request.ImageString;
                await _dbContext.SaveChangesAsync();
            }
            return imageFile;
        }
    }
}
