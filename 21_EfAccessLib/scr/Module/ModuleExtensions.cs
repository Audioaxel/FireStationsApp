using DataLib;
using DataLib.DTOs;
using EfAccessLib.Configurations;
using EfAccessLib.Data;
using EfAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace EfAccessLib.Module;

public static class ModuleExtensions
{
    public static void RegisterEfAccessLibService(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IDatabaseRepository<TestModelDto, CreateTestModelDto>, TestModelData>();
        services.AddScoped<IDatabaseRepository<TestModelPlusDto, CreateTestModelPlusDto>, TestModelPlusData>();
        services.AddAutoMapper(typeof(MapperConfig));
    }
}