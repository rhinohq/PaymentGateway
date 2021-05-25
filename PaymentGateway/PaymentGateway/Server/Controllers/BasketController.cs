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
using PaymentGateway.Data.Models;
using PaymentGateway.Data.Extensions;
using PaymentGateway.Data.ViewModels;

using AutoMapper;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _storeDbContext;

        public BasketController(ILogger<BasketController> logger, IMapper mapper, StoreDbContext storeDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var basket = await GetUserBasketAsync();

            if (basket == null)
                return Ok(
                    new BasketDetail()
                    {
                        Items = new List<BasketItemDetail>()
                    }
                );

            return Ok(basket.ToBasketDetail());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BasketDetail newBasket)
        {
            var basket = await GetUserBasketAsync();

            if (basket == null)
                return BadRequest();

            var mappedBasket = _mapper.Map(newBasket, basket);

            for (int i = 0; i < mappedBasket.Items.Count; i++)
            {
                BasketItem item = mappedBasket.Items[i];
                var dbItem = await GetBasketItemAsync(item.BasketItemId);

                if (dbItem != null)
                {
                    dbItem.Product = await GetProductAsync(item.Product.ProductId);
                    dbItem.Quantity = item.Quantity;

                    mappedBasket.Items[i] = dbItem;
                }
            }

            await _storeDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("AddToBasket")]
        public async Task<IActionResult> AddToBasket(Guid id)
        {
            var prod = await GetProductAsync(id);

            if (prod == null)
                return NotFound();

            var basket = await GetUserBasketAsync();

            if (basket == null) // New basket
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var newItem = new BasketItem(prod);

                _storeDbContext.BasketItems.Add(newItem);

                basket = new Basket
                {
                    OwnedByUser = userId,
                    Items = new List<BasketItem> { newItem }
                };

                _storeDbContext.Baskets.Add(basket);
            }
            else // Existing basket
            {
                var item = basket.Items.FirstOrDefault(x => x.Product.ProductId == prod.ProductId);

                if (item == null)
                {
                    var newItem = new BasketItem(prod);

                    _storeDbContext.BasketItems.Add(newItem);
                    basket.Items.Add(newItem);
                }
                else
                {
                    item.Quantity++;
                }

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
                return Ok(basket.Items.Select(x => x.Product.ToProdMeta()));
        }

        private async Task<Basket> GetUserBasketAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _storeDbContext.Baskets
                .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.OwnedByUser == userId && !x.Fufilled);

            return basket;
        }

        private Basket CreateUserBasket()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return new Basket
            {
                OwnedByUser = userId,
                Items = new List<BasketItem>()
            };
        }

        private async Task<BasketItem> GetBasketItemAsync(Guid id)
        {
            var item = await _storeDbContext.BasketItems
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.BasketItemId == id);

            return item;
        }

        private async Task<Product> GetProductAsync(Guid id)
        {
            var prod = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            return prod;
        }
    }
}
