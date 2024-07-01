using WebAPI.Dtos.Stock;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }

        public static Stock ToStockCreateDto(this CreateStockRequestDto stockRequestDto)
        {
            return new Stock
            {
                Symbol = stockRequestDto.Symbol,
                CompanyName = stockRequestDto.CompanyName,
                Purchase = stockRequestDto.Purchase,
                LastDiv = stockRequestDto.LastDiv,
                Industry = stockRequestDto.Industry,
                MarketCap = stockRequestDto.MarketCap,
            };
        }
    }
}
