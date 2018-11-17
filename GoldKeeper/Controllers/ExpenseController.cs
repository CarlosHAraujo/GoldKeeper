using Data;
using Domain;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Expense>> Post(ExpensePostModel model, CancellationToken cancellationToken)
        {
            if(model is null)
            {
                return BadRequest();
            }

            Expense expense;
            if (model.CompanyId.HasValue)
            {
                expense = new Expense(model.CompanyId.Value, model.Date, model.Discount ?? 0);
            }
            else
            {
                var newlyCompany = await _context.AddAsync(new Company(model.CompanyName), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                newlyCompany.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                expense = new Expense(newlyCompany.Entity.Id, model.Date, model.Discount ?? 0);
            }

            await InsertPayments(model.Payments, expense, cancellationToken);

            await InsertItems(model.Items, expense, cancellationToken);

            Array.ForEach(model.ExtraCosts.ToArray(), ec => expense.AddExtraCost(ec.Cost, ec.Value));

            var entity = await _context.Expenses.AddAsync(expense, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(entity.Entity);
        }

        private async Task InsertItems(IEnumerable<ExpensePostModel.ItemModel> items, Expense expense, CancellationToken cancellationToken)
        {
            var tasks = items.Where(i => !i.ProductId.HasValue).Select(i =>
            {
                return AddProduct(i, cancellationToken);
            });
            var insertedItems = await Task.WhenAll(tasks);

            Array.ForEach(items.Where(p => p.ProductId.HasValue).Concat(insertedItems).ToArray(), item => 
            {
                expense.AddItem(item.ProductId.Value, item.Value, item.Quantity);
            });
        }

        private async Task<ExpensePostModel.ItemModel> AddProduct(ExpensePostModel.ItemModel model, CancellationToken cancellationToken)
        {
            var newlyProduct = await _context.AddAsync(new Product(model.ProductName), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            newlyProduct.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return new ExpensePostModel.ItemModel { ProductId = newlyProduct.Entity.Id, Value = model.Value, Quantity = model.Quantity };
        }

        private async Task InsertPayments(IEnumerable<ExpensePostModel.PaymentModel> payments, Expense expense, CancellationToken cancellationToken)
        {
            var tasks = payments.Where(p => !p.MethodId.HasValue).Select(p =>
            {
                return AddPaymentMethod(p, cancellationToken);
            });
            var insertedPayments = await Task.WhenAll(tasks);

            Array.ForEach(payments.Where(p => p.MethodId.HasValue).Concat(insertedPayments).ToArray(), payment =>
            {
                expense.AddPayment(payment.MethodId.Value, payment.Value);
            });
        }

        private async Task<ExpensePostModel.PaymentModel> AddPaymentMethod(ExpensePostModel.PaymentModel model, CancellationToken cancellationToken)
        {
            var newlyMethod = await _context.AddAsync(new PaymentMethod(model.MethodName), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            newlyMethod.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return new ExpensePostModel.PaymentModel { MethodId = newlyMethod.Entity.Id, Value = model.Value };
        }
    }
}
