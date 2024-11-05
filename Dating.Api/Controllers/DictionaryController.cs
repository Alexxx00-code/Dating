using Dating.Api.Models;
using Dating.Aplication.Interfaces;
using Dating.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dating.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly IParameterService<Gender> genderService;
        private readonly IParameterService<City> cityService;
        private readonly IParameterService<EyesColor> eyesColorService;
        private readonly IParameterService<HairColor> hairColorService;
        private readonly IParameterService<Language> languageService;
        private readonly IParameterService<SexOrientation> sexOrientationService;
        private readonly IParameterService<Tag> tagService;
        private readonly IParameterService<ZodiacSign> zodiacSignService;

        public DictionaryController(
            IParameterService<Gender> genderService,
            IParameterService<City> cityService,
            IParameterService<EyesColor> eyesColorService,
            IParameterService<HairColor> hairColorService,
            IParameterService<Language> languageService,
            IParameterService<SexOrientation> sexOrientationService,
            IParameterService<Tag> tagService,
            IParameterService<ZodiacSign> zodiacSignService)
        {
            this.genderService = genderService;
            this.cityService = cityService;
            this.eyesColorService = eyesColorService;
            this.hairColorService = hairColorService;
            this.languageService = languageService;
            this.sexOrientationService = sexOrientationService;
            this.tagService = tagService;
            this.zodiacSignService = zodiacSignService;
        }

        [HttpGet]
        public async Task<ActionResult<DictionaryModel>> GetList()
        {
            DictionaryModel model = new DictionaryModel {
                Cities = await cityService.GetList(),
                EyesColors = await eyesColorService.GetList(),
                Genders = await hairColorService.GetList(),
                Tags = await tagService.GetList(),
                HairColors = await hairColorService.GetList(),
                Languages = await languageService.GetList(),
                SexOrientations = await sexOrientationService.GetList(),
                ZodiacSigns = await zodiacSignService.GetList(),
            };

            return Ok(model);
        }
    }
    /*
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : DictionaryController<Gender>
    {
        public GenderController(IParameterService<Gender> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : DictionaryController<City>
    {
        public CityController(IParameterService<City> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class EyesColorController : DictionaryController<EyesColor>
    {
        public EyesColorController(IParameterService<EyesColor> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class HairColorController : DictionaryController<HairColor>
    {
        public HairColorController(IParameterService<HairColor> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : DictionaryController<Language>
    {
        public LanguageController(IParameterService<Language> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class SexOrientationController : DictionaryController<SexOrientation>
    {
        public SexOrientationController(IParameterService<SexOrientation> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TagController : DictionaryController<Tag>
    {
        public TagController(IParameterService<Tag> parameterService) : base(parameterService) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ZodiacSignController : DictionaryController<ZodiacSign>
    {
        public ZodiacSignController(IParameterService<ZodiacSign> parameterService) : base(parameterService) { }
    }*/
}
