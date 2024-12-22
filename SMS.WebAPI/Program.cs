using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SMS.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddPersistanceDependencies(builder.Configuration);
builder.Services.AddHttpContextAccessor();

const string tokenOptionsConfigurationName = "TokenOptions";
TokenOptions tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationName).Get<TokenOptions>()
                            ?? throw new InvalidOperationException(
                                $"{tokenOptionsConfigurationName} section bulunamadı");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
            };
        }
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
