using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviewBackEnd.Model;

namespace moviewBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        
        private readonly moviewContext _context;

        public ReviewsController(moviewContext context)
        {
            _context = context;
        }

        // GET: api/Reviews

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }
        
        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviews>> GetReviews(int id)
        {
            var reviews = await _context.Reviews.Include(m => m.Movie).FirstOrDefaultAsync(r => r.ReviewId == id);


            if (reviews == null)
            {
                return NotFound();
            }

            return reviews;
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviews(int id, Reviews reviews)
        {
            if (id != reviews.ReviewId)
            {
                return BadRequest();
            }

            if(!ReviewsExists(id))
            {
                return BadRequest();
            }

            Reviews review = await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);

            review.Review = reviews.Review;
            review.Rating = reviews.Rating;

            _context.Reviews.Update(review);

            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(Reviews reviews)
        {
            _context.Reviews.Add(reviews);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviews", new { id = reviews.ReviewId }, reviews);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reviews>> DeleteReviews(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();

            return reviews;
        }
        

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
