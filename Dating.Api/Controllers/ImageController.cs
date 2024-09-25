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
        public async Task<ActionResult<UserModel>> ImageUpload(AddImagesDTO imagesDTO)
        {
            try
            {
                var types = imagesDTO.Image.ContentType;//Test

                return Ok(_imageService.UploadImageForUserAsync(imagesDTO.Image.OpenReadStream()));
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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var stream = await _imageService.GetImage(id);

                return Ok(File(stream, "image/jpeg"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}
