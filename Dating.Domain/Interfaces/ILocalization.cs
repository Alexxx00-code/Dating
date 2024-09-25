using Dating.Domain.Models;

namespace Dating.Domain.Interfaces
{
    public interface ILocalization
    {
        LocalizationLanguage Language { get; set; }
    }
}
