using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhongKhamNhaKhoa.Api.Repositorys.Image;
using PhongKhamNhaKhoa.Model.ImageFileRequests;
using System.Threading.Tasks;
using System;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageFileController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromBody] ImageUpdateRequest request)
        {
            try
            {
                var imageFile = await _imageRepository.UpdateImage(request);
                if (imageFile != null)
                {
                    return Ok(imageFile);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
