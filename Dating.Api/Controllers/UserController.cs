using Dating.Api.Models;
using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public UserController(ILogger<Controller> logger, IUserService userService, IImageService imageService)
        {
            _logger = logger;
            _userService = userService;
            _imageService = imageService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(CreateUserDTO userDTO)
        {
            try
            {
                var imagePath = await _imageService.UploadImageAsync(userDTO.ImageBase.OpenReadStream());

                CreateUserModel userModel = new CreateUserModel
                {
                    Birthdate = userDTO.Birthdate,
                    Firstname = userDTO.Firstname,
                    GenderId = userDTO.GenderId,
                    Latitude = userDTO.Latitude,
                    Longitude = userDTO.Longitude,
                    SexOrientationId = userDTO.SexOrientationId,
                    BaseImagePath = imagePath
                };

                return Ok(await _userService.Create(userModel));
            }
            catch (MyException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem();
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UserModel>> Update(UpdateUserDTO userDTO)
        {
            try
            {
                return Ok(await _userService.Update(userDTO));
            }
            catch (MyException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserModel>> Get()
        {
            try
            {
                return Ok(await _userService.GetUser());
            }
            catch (MyException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem();
            }
        }
    }
}
