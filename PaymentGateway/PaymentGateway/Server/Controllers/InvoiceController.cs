using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Banking.Providers;
using PaymentGateway.Data;
using PaymentGateway.Data.ViewModels;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IBankProvider _bankProvider;
        private readonly ILogger<InvoiceController> _logger;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _storeDbContext;

        public InvoiceController(IBankProvider bankProvider, ILogger<InvoiceController> logger, IMapper mapper, StoreDbContext storeDbContext)
        {
            _bankProvider = bankProvider ?? throw new ArgumentNullException(nameof(bankProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var invoice = await _storeDbContext.Invoices
                .Include(x => x.BankResponse)
                .Include(x => x.Basket).ThenInclude(x => x.Items).ThenInclude(x => x.Product)
                .Where(x => x.Basket.OwnedByUser == userId)
                .ProjectTo<InvoiceDetail>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.InvoiceId == id);

            return Ok(invoice);
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var prods = await _storeDbContext.Invoices
                .Include(x => x.BankResponse)
                .Include(x => x.Basket).ThenInclude(x => x.Items).ThenInclude(x => x.Product)
                .Where(x => x.Basket.OwnedByUser == userId)
                .ProjectTo<InvoiceMeta>(_mapper.ConfigurationProvider)
                .ToArrayAsync();

            return Ok(prods);
        }
    }
}
