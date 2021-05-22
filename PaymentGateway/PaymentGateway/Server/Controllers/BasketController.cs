using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Data;
using PaymentGateway.Data.Extensions;
using PaymentGateway.Data.ViewModels;
using PaymentGateway.Server.Data;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly StoreDbContext _storeDbContext;

        public BasketController(ILogger<BasketController> logger, StoreDbContext storeDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
        }

        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            var prod = _storeDbContext.Products
                .Include(x => x.Merchant)
                .FirstOrDefault(x => x.ProductId == id);

            if (prod == null)
                return Ok(null);

            return Ok(prod.ToProdDetail());
        }

        [HttpGet("AddToBasket")]
        public async Task<IActionResult> AddToBasket(Guid id)
        {
            var prod = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            if (prod == null)
                return NotFound();

            var basket = await GetUserBasketAsync();

            if (basket == null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                basket = new Basket
                {
                    OwnedByUser = userId,
                    Products = new List<Product> { prod }
                };

                _storeDbContext.Baskets.Add(basket);
            }
            else
            {
                basket.Products.Add(prod);

                _storeDbContext.Baskets.Update(basket);
            }

            await _storeDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("ProductsInBasket")]
        public async Task<IActionResult> ProductsInBasket()
        {
            var basket = await GetUserBasketAsync();

            if (basket == null)
                return Ok(new ProductMetaData[0]);
            else
                return Ok(basket.Products.Select(x => x.ToProdMeta()));
        }

        private async Task<Basket> GetUserBasketAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _storeDbContext.Baskets
                .Include(x => x.Products).ThenInclude(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.OwnedByUser == userId);

            return basket;
        }
    }
}
