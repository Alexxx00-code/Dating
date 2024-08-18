using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;
using DatingApi.Models;
using System.Security.Cryptography;
using System.Web;

namespace DatingApi.AuthenticationSchemes
{
    public class TelegramAuthenticationSchemeOptions
    : AuthenticationSchemeOptions
    { }

    public class TelegramAuthenticationHandler : AuthenticationHandler<TelegramAuthenticationSchemeOptions>
    {
        private readonly string botToken = "7544862344:AAGpAIzdLAe0oAZ2fyczCrRZd-eHcx0_kuY";

        public TelegramAuthenticationHandler(
            IOptionsMonitor<TelegramAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            TelegramUser model;

            // validation comes in here
            if (!Request.Headers.ContainsKey(HeaderNames.Authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail("Header Not Found."));
            }

            var header = Request.Headers[HeaderNames.Authorization].ToString();
            var tokenMatch = Regex.Match(header, AuthSchemeConstants.TelegramToken);

            if (tokenMatch.Success)
            {
                // the token is captured in this group
                // as declared in the Regex
                var token = tokenMatch.Groups["token"].Value;

                if (!Validate(token)) {
                    Logger.Log(LogLevel.Error, "Invalid token");
                    return Task.FromResult(AuthenticateResult.Fail("InvalidToken"));
                }

                try
                {
                    var parser = HttpUtility.ParseQueryString(token);
                    var user = HttpUtility.UrlDecode(parser["user"]);

                    // deserialize the JSON string obtained from the byte array
                    model = JsonSerializer.Deserialize<TelegramUser>(user);
                }
                catch (System.Exception ex)
                {
                    Logger.Log(LogLevel.Error, "Exception Occured while Deserializing: " + ex);
                    return Task.FromResult(AuthenticateResult.Fail("TokenParseException"));
                }

                // success branch
                // generate authTicket
                // authenticate the request
                if (model != null)
                {
                    // create claims array from the model
                    var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                    new Claim(ClaimTypes.Name, model.FirstName) };

                    // generate claimsIdentity on the name of the class
                    var claimsIdentity = new ClaimsIdentity(claims,
                                nameof(TelegramAuthenticationHandler));

                    // generate AuthenticationTicket from the Identity
                    // and current authentication scheme
                    var ticket = new AuthenticationTicket(
                        new ClaimsPrincipal(claimsIdentity), this.Scheme.Name);

                    // pass on the ticket to the middleware
                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            }

            // failure branch
            // return failure
            // with an optional message
            return Task.FromResult(AuthenticateResult.Fail("Model is Empty"));
        }

        private bool Validate(string token)
        {
            var parsedQueryString = HttpUtility.ParseQueryString(token);
            var data = "auth_date=" + parsedQueryString["auth_date"] + "\n" + "query_id=" + parsedQueryString["query_id"] + "\n" + "user=" + parsedQueryString["user"];
            var hash = parsedQueryString["hash"];

            //генерируем  ключь из токен бота в документации это строка secret_key = HMAC_SHA256(<bot_token>, "WebAppData")
            byte[] secret_key = HMAC_SHA256(Encoding.UTF8.GetBytes(botToken), Encoding.UTF8.GetBytes("WebAppData"));
            //Далее генерируем строку из данных которые пришли и из секретного ключа, в документации это строка hex(HMAC_SHA256(data_check_string, secret_key))
            string calculatedHash = BitConverter.ToString(HMAC_SHA256(Encoding.UTF8.GetBytes(data), secret_key)).Replace("-", "");
            //далее сравниваем что получилось с тем что пришло.
            if (calculatedHash.Equals(hash, StringComparison.OrdinalIgnoreCase))
            {
                // Данные получены от Telegram
                return true;
            }
            else
            {
                // Хэш не совпадает, данные не действительны
                return false;
            }
        }

        private byte[] HMAC_SHA256(byte[] data, byte[] key)
        {
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}
