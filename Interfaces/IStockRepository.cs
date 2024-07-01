using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}
