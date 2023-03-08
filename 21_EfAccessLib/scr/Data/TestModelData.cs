using AutoMapper;
using DataLib;
using DataLib.DTOs;
using EfAccessLib.DataAccess;
using EfAccessLib.Models;

namespace EfAccessLib.Data;

public class TestModelData : BaseData<TestModelDto, CreateTestModelDto, TestModel>
    , IDatabaseRepository<TestModelDto, CreateTestModelDto>
{
    public TestModelData(DatabaseDbContext context, IMapper mapper)
        : base(context, mapper)
    {

    }
}