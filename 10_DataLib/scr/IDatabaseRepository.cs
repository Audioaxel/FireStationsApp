
namespace DataLib;

/// T: ModelDto
/// U: CreateModelDto

public interface IDatabaseRepository<T, U>
{
    Task<T?> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Post(U createModelDto);
    Task<bool> Put(int id, U createModelDto);
    Task<bool> Delete(int id);
}