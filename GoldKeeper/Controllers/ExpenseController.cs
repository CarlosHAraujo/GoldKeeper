using Data;
using Domain;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoldKeeper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly DomainContext _context;

        public ExpenseController(DomainContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Expense>> Post(ExpensePostModel model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var expense = new Expense(model.CompanyId, model.Date, model.Discount ?? 0);

            Array.ForEach(model.Payments.ToArray(), p => expense.AddPayment(p.MethodId, p.Value));

            Array.ForEach(model.Items.ToArray(), i => expense.AddItem(i.ProductId, i.Value, i.Quantity));

            Array.ForEach(model.ExtraCosts.ToArray(), ec => expense.AddExtraCost(ec.Cost, ec.Value));

            var entity = await _context.Expenses.AddAsync(expense, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(entity.Entity);
        }
    }
}
