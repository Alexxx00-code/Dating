using Dating.Aplication.Interfaces;
using Dating.Aplication.Models;
using Dating.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{
    public abstract class ParameterController<T> : ControllerBase
    {
        private readonly IParameterService<T> parameterService;

        public ParameterController(IParameterService<T> parameterService)
        {
            this.parameterService = parameterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParameterModel>>> GetList()
        {
            return await parameterService.GetList();
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ParameterController<Gender>
    {
        public GenderController(IParameterService<Gender> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ParameterController<City>
    {
        public CityController(IParameterService<City> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class EyesColorController : ParameterController<EyesColor>
    {
        public EyesColorController(IParameterService<EyesColor> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class HairColorController : ParameterController<HairColor>
    {
        public HairColorController(IParameterService<HairColor> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ParameterController<Language>
    {
        public LanguageController(IParameterService<Language> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class SexOrientationController : ParameterController<SexOrientation>
    {
        public SexOrientationController(IParameterService<SexOrientation> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ParameterController<Tag>
    {
        public TagController(IParameterService<Tag> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ZodiacSignController : ParameterController<ZodiacSign>
    {
        public ZodiacSignController(IParameterService<ZodiacSign> parameterService) : base(parameterService) { }
    }
}
