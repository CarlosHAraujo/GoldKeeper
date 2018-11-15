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
    public class ProductController : ControllerBase
    {
        private readonly DomainContext _context;

        public ProductController(DomainContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<(int id, string name)>>> Get(CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync(cancellationToken);
            return Ok(products.Select(x => (x.Id, x.Name)));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> Post(ProductPostModel model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var product = new Product(model.Name);

            var entity = await _context.Products.AddAsync(product, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Ok(entity.Entity);
        }
    }
}
