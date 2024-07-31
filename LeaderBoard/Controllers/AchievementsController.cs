using LeaderBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace LeaderBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly LeaderContext _dbContext1;

        public AchievementsController(LeaderContext dbcontext1)
        {
            _dbContext1 = dbcontext1;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achievements>>> GetBrands()
        {
            if (_dbContext1.Achievements == null)
            {
                return NotFound();
            }
            return await _dbContext1.Achievements.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Achievements>> GetBrands(int id)
        {
            if (_dbContext1.Achievements == null)
            {
                return NotFound();
            }
            var brand = await _dbContext1.Achievements.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }


            return brand;

        }

        [HttpPost]

        public async Task<ActionResult<Achievements>> PostBrands(Achievements brand)
        {
            _dbContext1.Achievements.Add(brand);
            await _dbContext1.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new { id = brand.Id }, brand);
        }

        [HttpPut]

        public async Task<IActionResult> PutBrand(int id, Achievements brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }
            _dbContext1.Entry(brand).State = EntityState.Modified;

            try
            {
                await _dbContext1.SaveChangesAsync();

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
            return (_dbContext1.Achievements?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (_dbContext1.Achievements == null)
            {
                return NotFound();
            }
            var brand = await _dbContext1.Achievements.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _dbContext1.Achievements.Remove(brand);

            await _dbContext1.SaveChangesAsync();

            return Ok();

        }

        [HttpPut("{Employeeid}")]

        public async Task<IActionResult> PutBrand1(int Employeeid, Achievements brand)
        {
            if (Employeeid != brand.EmployeeId)
            {
                return BadRequest();
            }
            _dbContext1.Entry(brand).State = EntityState.Modified;

            try
            {
                await _dbContext1.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandAvailable1(Employeeid))
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
        private bool BrandAvailable1(int Employeeid)
        {
            return (_dbContext1.Achievements?.Any(x => x.EmployeeId == Employeeid)).GetValueOrDefault();
        }


    }
}
