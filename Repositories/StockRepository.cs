using Microsoft.EntityFrameworkCore;
using WebAPI.DB;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stock.ToListAsync();
        }
    }
}
