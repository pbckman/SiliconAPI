using Infrastructure.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(ApiContext context) : ControllerBase
{

    private readonly ApiContext _context = context;


    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var services = await _context.Services.OrderBy(o => o.ServiceName).ToListAsync();
        return Ok(ServiceFactory.Create(services));
    }
}
