using OpenHouseAssistant.Library.DataAccess;
using OpenHouseAssistant.Library.TypeHandlers;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

