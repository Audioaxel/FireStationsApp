using System.IO;
using System.Threading.Tasks;
using DataLib;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApi.Endpoints;

internal static class GenericEndpointHandler
{
    internal static async Task<IResult> Get<T, U>(IDatabaseRepository<T, U> data, int id)
        where T : class
        where U : class
    {
        var result = await data.Get(id);
        return result is null ? Results.NotFound() : Results.Ok(result);
    }

    internal static async Task<IResult> GetAll<T, U>(IDatabaseRepository<T, U> data)
        where T : class
        where U : class
    {
        var results = await data.GetAll();
        return results is null ? Results.NotFound() : Results.Ok(results);
    }

    internal static async Task<IResult> Post<T, U>(IDatabaseRepository<T, U> data, HttpRequest request)
        where T : class
        where U : class
    {
        string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
        var createModel = JsonConvert.DeserializeObject<U>(requestBody);

        return await data.Post(createModel) is false ? Results.UnprocessableEntity() : Results.StatusCode(201);
    }

    internal static async Task<IResult> Put<T, U>(IDatabaseRepository<T, U> data, int id, HttpRequest request)
        where T : class
        where U : class
    {
        string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
        var putModel = JsonConvert.DeserializeObject<U>(requestBody);

        return await data.Put(id, putModel) is false ? Results.UnprocessableEntity() : Results.NoContent();
    }

    internal static async Task<IResult> Delete<T, U>(IDatabaseRepository<T, U> data, int id)
        where T : class
        where U : class
    {
        return await data.Delete(id) is false ? Results.NotFound() : Results.Ok();
    }
}