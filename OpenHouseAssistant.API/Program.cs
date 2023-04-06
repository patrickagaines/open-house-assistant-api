using Microsoft.AspNetCore.Authentication.JwtBearer;
using Dapper;
using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.TypeHandlers;

var AllowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(name: AllowSpecificOrigins,
        policy => {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

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
builder.Services.AddTransient<IGuestData, GuestData>();
builder.Services.AddTransient<IOpenHouseData, OpenHouseData>();
builder.Services.AddTransient<IPropertyData, PropertyData>();

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

