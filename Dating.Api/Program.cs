using Dating.Api.AuthenticationSchemes;
using Dating.Api.Utilities;
using Dating.Aplication.Interfaces;
using Dating.Aplication.Services;
using Dating.Domain.Interfaces;
using Dating.Domain.Models;
using Dating.Infrastructure.DataBase;
using Dating.Infrastructure.EFRepositories;
using Dating.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddDbContext<DataBaseContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase")));


builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<RequireNonNullablePropertiesSchemaFilter>();
    c.SupportNonNullableReferenceTypes(); // Sets Nullable flags appropriately.              
    c.UseAllOfToExtendReferenceSchemas(); // Allows $ref enums to be nullable
    c.UseAllOfForInheritance();  // Allows $ref objects to be nullable
    c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
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


builder.Services.AddScoped<DataBaseContext>();

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<UserImage>, UserImageRepository>();
builder.Services.AddScoped<IImageRepository>(provider =>
        new FileImageRepository(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads")));
builder.Services.AddScoped<IRepository<Gender>, GenderRepository>();
builder.Services.AddScoped<IRepository<City>, CityRepository>();
builder.Services.AddScoped<IRepository<EyesColor>, EyesColorRepository>();
builder.Services.AddScoped<IRepository<HairColor>, HairColorRepository>();
builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();
builder.Services.AddScoped<IRepository<SexOrientation>, SexOrientationRepository>();
builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
builder.Services.AddScoped<IRepository<ZodiacSign>, ZodiacSignRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICityApi, CityOpenStreetMapApi>();
builder.Services.AddScoped<IEnvParameters, SeterReqParameters>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IParameterService<Gender>, ParameterService<Gender>>();
builder.Services.AddScoped<IParameterService<City>, ParameterService<City>>();
builder.Services.AddScoped<IParameterService<EyesColor>, ParameterService<EyesColor>>();
builder.Services.AddScoped<IParameterService<HairColor>, ParameterService<HairColor>>();
builder.Services.AddScoped<IParameterService<Language>, ParameterService<Language>>();
builder.Services.AddScoped<IParameterService<SexOrientation>, ParameterService<SexOrientation>>();
builder.Services.AddScoped<IParameterService<Tag>, ParameterService<Tag>>();
builder.Services.AddScoped<IParameterService<ZodiacSign>, ParameterService<ZodiacSign>>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

public class RequireNonNullablePropertiesSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Add to model.Required all properties where Nullable is false.
    /// </summary>
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        var additionalRequiredProps = model.Properties
            .Where(x => !x.Value.Nullable && !model.Required.Contains(x.Key))
            .Select(x => x.Key);
        foreach (var propKey in additionalRequiredProps)
        {
            model.Required.Add(propKey);
        }
    }
}
