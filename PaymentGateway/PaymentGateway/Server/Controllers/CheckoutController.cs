using System;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PaymentGateway.Banking.Providers;
using PaymentGateway.Data;
using PaymentGateway.Data.Models;
using PaymentGateway.Data.ViewModels;
using PaymentGateway.Server.Extensions;

namespace PaymentGateway.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IBankProvider _bankProvider;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IMapper _mapper;
        private readonly StoreDbContext _storeDbContext;

        public CheckoutController(IBankProvider bankProvider, ILogger<CheckoutController> logger, IMapper mapper, StoreDbContext storeDbContext)
        {
            _bankProvider = bankProvider ?? throw new ArgumentNullException(nameof(bankProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
        }

        [HttpPost("CheckoutOrder")]
        public async Task<IActionResult> CheckoutOrder([FromBody] CheckoutForm form)
        {
            var basket = await _storeDbContext.Baskets
                .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Merchant)
                .FirstOrDefaultAsync(x => x.BasketId == form.BasketId);

            if (basket == null || basket.Fufilled)
                return Problem();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (basket.OwnedByUser != userId)
                return Unauthorized();

            var request = form.ToPaymentRequest(basket.TotalCost);
            var response = _bankProvider.ProcessPayment(request);

            bool isSuccess = response.StatusCode >= 50;
            var bankResponse = _mapper.Map(response, new BankResponse());

            var invoice = _mapper.Map(form, new Invoice());
            invoice.BankResponse = bankResponse;
            invoice.Basket = basket;
            invoice.InvoiceTime = DateTime.UtcNow;

            _storeDbContext.BankResponses.Add(bankResponse);
            _storeDbContext.Invoices.Add(invoice);

            basket.Fufilled = true;
            _storeDbContext.Baskets.Update(basket);
            await _storeDbContext.SaveChangesAsync();

            return Ok(isSuccess);
        }
    }
}
