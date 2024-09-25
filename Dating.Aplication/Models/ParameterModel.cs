using Dating.Domain.Models;

namespace Dating.Aplication.Models
{
    public class ParameterModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static readonly Func<BaseParameter, ParameterModel> ToModel = (par) =>
        {
            return new ParameterModel { Id = par.Id, Name = par.Name };
        };
    }
}
