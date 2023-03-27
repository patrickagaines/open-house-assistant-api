using Microsoft.AspNetCore.Authentication.JwtBearer;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.TypeHandlers;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    opts.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = builder.Configuration["Auth0:Audience"],
        ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}"
    };
});

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

