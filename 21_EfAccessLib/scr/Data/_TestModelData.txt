using AutoMapper;
using DataLib;
using DataLib.DTOs;
using EfAccessLib.DataAccess;
using EfAccessLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EfAccessLib.Data;

public class TestModelData : IDatabaseRepository<TestModelDto, CreateTestModelDto>
{
    private readonly DatabaseDbContext _context;
    private readonly IMapper _mapper;

    public TestModelData(DatabaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TestModelDto?> Get(int id)
    {
        return _mapper.Map<TestModelDto>(
            await _context.TestModels.FindAsync(id)
        );
    }

    public async Task<IEnumerable<TestModelDto>> GetAll()
    {
        return _mapper.Map<List<TestModelDto>>(
            await _context.TestModels.ToListAsync()
        );
    }

    public async Task<bool> Post(CreateTestModelDto createTestModelDto)
    {
        _context.TestModels.Add(
            _mapper.Map<TestModel>(createTestModelDto)
        );
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Cant Update Database", ex);
        }
    }

    public async Task<bool> Put(int id, CreateTestModelDto createTestModelDto)
    {
        if (await _context.TestModels.FindAsync(id) is TestModel sourceModel)
        {
            _context.Update(_mapper.Map(createTestModelDto, sourceModel));
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }

    public async Task<bool> Delete(int id)
    {
        if (await _context.TestModels.FindAsync(id) is TestModel sourceModel)
        {
            _context.Remove(sourceModel);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}