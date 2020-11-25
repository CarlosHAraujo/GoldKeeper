using Data;
using Domain;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
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
