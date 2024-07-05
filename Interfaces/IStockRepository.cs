﻿using WebAPI.Dtos.Stock;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStock);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}
