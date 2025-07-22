using ADOTools;
using HospitalManager.API.Token;
using HospitalManager.BLL;
using HospitalManager.BLL.Interfaces;
using HospitalManager.BLL.Mappers;
using HospitalManager.BLL.Services;
using HospitalManager.DAL.Interfaces;
using HospitalManager.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("secrets.json", optional: false, reloadOnChange: true);

Dictionary<string,string> secrets = builder.Configuration.Get<Dictionary<string,string>>();
Encryption.init(secrets);
PatientFileMapper.init(secrets);

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // D�finir les information g�n�rales de notre API dans swagger
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "HospitalManager",
        Version = "v1"
    });

    // D�clarer une schema de s�curit� de type Bearer pour Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Token bearer utilise le schema (Bearer {token})",
        Name = "Authorization", // Nom de l'en-t�te HTTP
        In = Microsoft.OpenApi.Models.ParameterLocation.Header, // Indique que l'info est envoy� dans le header HTTP
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, // D�clare une cl� API de type Bearer
        Scheme = "Bearer" // Nom du sch�ma utilis�
    });

    // Ajoute une exigence de s�curit� globale pour toutes les routes prott�g�s par [Authorize]
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2", // N�c�ssaire pour swagger (interface)
                Name = "Bearer",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            },
            new List<string>() // Liste vide => Pas de scopes sp�cifique n�c�ssaires...
        }
    });
});
builder.Services.AddScoped<IAuthService, AuthServices >();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IPatientServices,PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();



builder.Services.AddSingleton(sp => new Connection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSingleton<TokenManager>();





builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["jwt:issuer"],
            ValidAudience = builder.Configuration["jwt:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
            //Permet de signifier au frontend qu'on attend un r�le
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManager"));
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
