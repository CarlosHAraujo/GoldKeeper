using Data;
using Domain;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<Expense>> Post(PostExpenseModel model, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.SingleAsync(x => x.Id == model.CompanyId);

            var expense = new Expense(company, model.Date.Value, model.Discount.Value);

            Array.ForEach(model.Payments.ToArray(), p => expense.AddPayment(p.MethodId.Value, p.Value.Value));

            Array.ForEach(model.Items.ToArray(), i => expense.AddItem(i.ProductId.Value, i.Value.Value, i.Quantity.Value));

            Array.ForEach(model.ExtraCosts.ToArray(), ec => expense.AddExtraCost(ec.CostId.Value, ec.Value.Value));

            var entity = await _context.Expenses.AddAsync(expense, cancellationToken);

            return Ok(entity);
        }
    }
}
