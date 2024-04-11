using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var query = _context.Subscribers.AsQueryable();

            return Ok(query);
        }


        [HttpPost] 
        public async Task<IActionResult> PostSubscriber([FromBody] SubscriberEntity subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Subscribers.Add(subscriber);
                    await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSubscriber), new { id = subscriber.Id }, subscriber);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<SubscriberEntity>> GetSubscriber(string id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

    }


}
