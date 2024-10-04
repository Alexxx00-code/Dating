using Dating.Aplication.Interfaces;
using System.Security.Claims;

namespace Dating.Api.Utilities
{
    public class SeterReqParameters : IEnvParameters
    {
        public SeterReqParameters(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;
            string? idStr = user?.Claims?.ToList()?.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

            if (idStr != null)
            {
                TelegramId = long.Parse(idStr);
            }
        }

        public long TelegramId { get; set; }

        public string LanguageCode { get; set; }
    }
}
