using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentGateway.Server.Data;

namespace PaymentGateway.Server.Controllers
{
    [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("List")]
        public IActionResult List()
        {
            var prods = _storeDbContext.Products.ToArray();

            return Ok(prods);
        }
    }
}
