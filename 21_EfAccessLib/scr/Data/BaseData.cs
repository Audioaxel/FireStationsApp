using AutoMapper;
using DataLib;
using EfAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfAccessLib.Data;

public abstract class BaseData<T, U, V> : IDatabaseRepository<T, U>
    where T : class
    where U : class
    where V : class
{
    private readonly DatabaseDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<V> _model;

    protected BaseData(DatabaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _model = context.Set<V>();
    }


    public virtual async Task<T?> Get(int id)
    {
        return _mapper.Map<T>(
            await _model.FindAsync(id)
        );
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return _mapper.Map<List<T>>(
            await _model.ToListAsync()
        );
    }

    public virtual async Task<bool> Post(U createModelDto)
    {
        _model.Add(
            _mapper.Map<V>(createModelDto)
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

    public virtual async Task<bool> Put(int id, U createModelDto)
    {
        if (await _model.FindAsync(id) is V sourceModel)
        {
            _context.Update(_mapper.Map(createModelDto, sourceModel));
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
    public virtual async Task<bool> Delete(int id)
    {
        if (await _model.FindAsync(id) is V sourceModel)
        {
            _context.Remove(sourceModel);
            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}