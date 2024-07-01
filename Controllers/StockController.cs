using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB;
using WebAPI.Dtos.Stock;
using WebAPI.Interfaces;
using WebAPI.Mappers;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stocksDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocksDto);
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpGet("name/{name:required}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _context.Stock.Where(s => s.CompanyName == name).FirstOrDefaultAsync();
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var stock = await _context.Stock
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (stock == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(stock.ToStockDto());
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockCreateDto();
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockDto.ToStockCreateDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.Symbol = updateStockDto.Symbol;
            stock.MarketCap = updateStockDto.MarketCap;
            stock.Purchase = updateStockDto.Purchase;
            stock.LastDiv = updateStockDto.LastDiv;
            stock.CompanyName = updateStockDto.CompanyName;
            stock.Industry = updateStockDto.Industry;

            await _context.SaveChangesAsync();
            return Ok(stock.ToStockDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
