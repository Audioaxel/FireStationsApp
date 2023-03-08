using AutoMapper;
using DataLib;
using DataLib.DTOs;
using EfAccessLib.DataAccess;
using EfAccessLib.Models;

namespace EfAccessLib.Data;

public class TestModelPlusData : BaseData<TestModelPlusDto, CreateTestModelPlusDto, TestModelPlus>
    , IDatabaseRepository<TestModelPlusDto, CreateTestModelPlusDto>
{
    public TestModelPlusData(DatabaseDbContext context, IMapper mapper)
        : base(context, mapper)
    {

    }
}
