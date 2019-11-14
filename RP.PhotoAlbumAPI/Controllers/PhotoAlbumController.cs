using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RP.PhotoAlbum.Provider.Feature.Service.Interface;

namespace RP.PhotoAlbumAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoAlbumController : ControllerBase
    {
        private IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? userId)
        {
            var result = await _photoAlbumService.GetAsync(userId);
            return Ok(result);
        }
    }
}
