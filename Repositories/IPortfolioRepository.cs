using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
    }
}
