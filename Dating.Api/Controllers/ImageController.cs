using Dating.Api.Models;
using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private readonly IImageService _imageService;

        public ImageController(ILogger<Controller> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ImageModel>> ImageUpload(AddImagesDTO imagesDTO)
        {
            try
            {
                var types = imagesDTO.Image.Select(i => i.ContentType).ToList();//Test

                return Ok(await _imageService.UploadImagesForUserAsync(imagesDTO.Image.Select(image => image.OpenReadStream()).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteImage(long id)
        {
            try
            {
                await _imageService.DeleteImage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var byteArr = await _imageService.GetImage(id);
                return File(byteArr, "image/jpeg");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}
