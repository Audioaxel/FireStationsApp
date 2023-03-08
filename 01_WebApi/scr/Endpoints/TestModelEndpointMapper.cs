using DataLib.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Endpoints;

internal static class TestModelEndpointMapper

{
    internal static void MapTestModelEndpoints(this IEndpointRouteBuilder routes, string patternPrefix)
    {
        var group = routes.MapGroup(patternPrefix);

        group.MapGet("/{id}", GenericEndpointHandler.Get<TestModelDto, CreateTestModelDto>);
        group.MapGet("/", GenericEndpointHandler.GetAll<TestModelDto, CreateTestModelDto>);
        group.MapPost("/create", GenericEndpointHandler.Post<TestModelDto, CreateTestModelDto>);
        group.MapPut("/change/{id}", GenericEndpointHandler.Put<TestModelDto, CreateTestModelDto>);
        group.MapDelete("/delete/{id}", GenericEndpointHandler.Delete<TestModelDto,CreateTestModelDto>);
    }
}


