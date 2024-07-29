using LeaderBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LeaderBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesContext _dbContext;

        public EmployeesController(EmployeesContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetBrands()
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            return await _dbContext.Employees.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Employees>> GetBrands(int id)
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Employees.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }


            return brand;

        }

        [HttpPost]

        public async Task<ActionResult<Employees>> PostBrands(Employees brand)
        {
            _dbContext.Employees.Add(brand);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new { id = brand.Id }, brand);
        }

        [HttpPut]

        public async Task<IActionResult> PutBrand(int id, Employees brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool BrandAvailable(int id)
        {
            return (_dbContext.Employees?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Employees.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(brand);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

    }
}
