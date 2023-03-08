using EfAccessLib.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});


string connectionString = builder.Configuration.GetConnectionString("EfConnectionString");
builder.Services.RegisterEfAccessLibService(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapTestModelEndpoints("/test");
app.MapTestModelPlusEndpoints("/testplus");

app.UseCors("AllowAll");

app.Run();
