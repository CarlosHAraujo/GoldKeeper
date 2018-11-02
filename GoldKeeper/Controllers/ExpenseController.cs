using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        //public async Task<ActionResult<Expense>> Post(int companyId, DateTime date, decimal discount, , CancellationToken cancellationToken)
        //{
        //    var company = await _context.Companies.SingleAsync(x => x.Id == companyId);
        //    var extraCosts = new ExtraCost() { Cost = cost, Value = value };
        //    var expense = new Expense()
        //    {
        //        Company = company,
        //        Date = date,
        //        Discount = discount,
        //        ExtraCosts = extraCosts,
        //        GrandTotal = grandTotal,
        //        PaymentMethod = payment,
        //        Products = products
        //    };
        //    var entity = await _context.Expenses.AddAsync(expense, cancellationToken);
        //}
    }
}
