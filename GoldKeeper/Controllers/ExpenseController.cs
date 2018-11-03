using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<ActionResult<Expense>> Post(int companyId, DateTime date, decimal discount, IDictionary<int, decimal> extraCosts, IDictionary<int, decimal> payments, IDictionary<int, KeyValuePair<int, decimal>> items, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.SingleAsync(x => x.Id == companyId);

            var expense = new Expense(company, date, discount);

            expense.AddPayments(payments.Select(p => (p.Key, p.Value)));

            expense.AddItems(items.Select(i => (i.Key, i.Value.Value, i.Value.Key)));

            expense.AddExtraCosts(extraCosts.Select(ec => (ec.Key, ec.Value)));

            var entity = await _context.Expenses.AddAsync(expense, cancellationToken);

            return Ok(entity);
        }
    }
}
