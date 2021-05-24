using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Data;
using PaymentGateway.Data.Extensions;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly StoreDbContext _storeDbContext;

        public ProductController(ILogger<ProductController> logger, StoreDbContext storeDbContext)
        {
            _logger = logger;
            _storeDbContext = storeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var prod = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            if (prod == null)
                return Ok(null);

            return Ok(prod.ToProdDetail());
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var prods = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .Select(x => x.ToProdMeta())
                .ToArrayAsync();

            return Ok(prods);
        }
    }
}
