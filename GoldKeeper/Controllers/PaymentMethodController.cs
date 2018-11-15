using Data;
using Domain;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoldKeeper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly DomainContext _context;

        public PaymentMethodController(DomainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<PaymentMethodGetModel>>> Get(CancellationToken cancellationToken)
        {
            var paymentMethods = await _context.PaymentMethods.Select(x => new PaymentMethodGetModel { Id = x.Id, Name = x.Name }).ToListAsync(cancellationToken);
            return Ok(paymentMethods);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PaymentMethod>> Post(PaymentMethodPostModel model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var method = new PaymentMethod(model.Name);

            var entity = await _context.PaymentMethods.AddAsync(method, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(entity.Entity);
        }
    }
}
