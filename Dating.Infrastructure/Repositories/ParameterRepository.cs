using Dating.Domain.Models;
using Dating.Infrastructure.DataBase;

namespace Dating.Infrastructure.Repositories
{
    public class CityRepository : BaseParameterRepository<City>
    {
        public CityRepository(DataBaseContext context): base(context, (i) => i.Cities) { }
    }

    public class EyesColorRepository : BaseParameterRepository<EyesColor>
    {
        public EyesColorRepository(DataBaseContext context) : base(context, (i) => i.EyesColors) { }
    }

    public class GenderRepository : BaseParameterRepository<Gender>
    {
        public GenderRepository(DataBaseContext context) : base(context, (i) => i.Genders) { }
    }

    public class HairColorRepository : BaseParameterRepository<HairColor>
    {
        public HairColorRepository(DataBaseContext context) : base(context, (i) => i.HairColors) { }
    }

    public class SexOrientationRepository : BaseParameterRepository<SexOrientation>
    {
        public SexOrientationRepository(DataBaseContext context) : base(context, (i) => i.SexOrientations) { }
    }

    public class TagRepository : BaseParameterRepository<Tag>
    {
        public TagRepository(DataBaseContext context) : base(context, (i) => i.Tags) { }
    }

    public class ZodiacSignRepository : BaseParameterRepository<ZodiacSign>
    {
        public ZodiacSignRepository(DataBaseContext context) : base(context, (i) => i.ZodiacSigns) { }
    }
}
