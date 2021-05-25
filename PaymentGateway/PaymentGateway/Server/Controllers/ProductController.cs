using System;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Data;
using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _storeDbContext;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, StoreDbContext storeDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var prod = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .ProjectTo<ProductDetail>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            return Ok(prod);
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var prods = await _storeDbContext.Products
                .Include(x => x.Merchant)
                .ProjectTo<ProductMetaData>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

            return Ok(prods);
        }
    }
}
