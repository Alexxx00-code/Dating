using DatingApi.AuthenticationSchemes;
using DatingApi.Migglewares;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add the authorization header to the Swagger UI
    c.AddSecurityDefinition(AuthSchemeConstants.TelegramAuthScheme, new OpenApiSecurityScheme
    {
        Description = $"JWT Authorization header using the Telegram scheme. Example: \"{AuthSchemeConstants.TelegramAuthScheme} token\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = AuthSchemeConstants.TelegramAuthScheme,
        BearerFormat = "JWT"
    });

    // Require the authorization header for all requests
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = AuthSchemeConstants.TelegramAuthScheme
                }
            },
            new string[] {}
        }
    });
}

);
builder.Services.AddAuthentication(
    options => options.DefaultScheme = AuthSchemeConstants.TelegramAuthScheme)
    .AddScheme<TelegramAuthenticationSchemeOptions, TelegramAuthenticationHandler>(
        AuthSchemeConstants.TelegramAuthScheme, options => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
}

app.UseHttpsRedirection();

app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot/browser")),
});
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot/browser")),
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
