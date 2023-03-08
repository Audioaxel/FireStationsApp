using DataLib.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Endpoints;

internal static class TestModelPlusEndpointMapper

{
    internal static void MapTestModelPlusEndpoints(this IEndpointRouteBuilder routes, string patternPrefix)
    {
        var group = routes.MapGroup(patternPrefix);

        group.MapGet("/{id}", GenericEndpointHandler.Get<TestModelPlusDto, CreateTestModelPlusDto>);
        group.MapGet("/", GenericEndpointHandler.GetAll<TestModelPlusDto, CreateTestModelPlusDto>);
        group.MapPost("/create", GenericEndpointHandler.Post<TestModelPlusDto, CreateTestModelPlusDto>);
        group.MapPut("/change/{id}", GenericEndpointHandler.Put<TestModelPlusDto, CreateTestModelPlusDto>);
        group.MapDelete("/delete/{id}", GenericEndpointHandler.Delete<TestModelPlusDto,CreateTestModelPlusDto>);
    }
}