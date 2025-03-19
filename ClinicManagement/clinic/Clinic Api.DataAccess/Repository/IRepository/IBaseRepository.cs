namespace clinic.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);
       Task AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task<bool> DeleteAsync(int id);
    }
}
