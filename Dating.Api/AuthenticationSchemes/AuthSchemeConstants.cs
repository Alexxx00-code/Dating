namespace Dating.Api.AuthenticationSchemes
{
    public class AuthSchemeConstants
    {
        public const string TelegramAuthScheme = "tma";
        public const string TelegramToken = $"{TelegramAuthScheme} (?<token>.*)";
    }
}
