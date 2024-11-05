using Dating.Aplication.Models;
using Dating.Domain.Models;

namespace Dating.Api.Models
{
    public class DictionaryModel
    {
        public List<ParameterModel> Genders { get; set; }
        public List<ParameterModel> Cities { get; set; }
        public List<ParameterModel> EyesColors { get; set; }
        public List<ParameterModel> HairColors { get; set; }
        public List<ParameterModel> Languages { get; set; }
        public List<ParameterModel> SexOrientations { get; set; }
        public List<ParameterModel> Tags { get; set; }
        public List<ParameterModel> ZodiacSigns { get; set; }
    }
}
