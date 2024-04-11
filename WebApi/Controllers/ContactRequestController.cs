﻿using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactRequestController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = _context.ContactRequests.AsQueryable();

        return Ok(query);
    }

    [HttpPost]
    public async Task<IActionResult> PostContactRequest([FromBody] ContactRequestEntity contactRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _context.ContactRequests.Add(contactRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContactRequest), new { id = contactRequest.Id }, contactRequest);
        }
        catch 
        {
            return Problem();
        }
    }

    [HttpGet("id")]
    public async Task<ActionResult<ContactRequestEntity>> GetContactRequest(string id)
    {
        var contactrequest = await _context.ContactRequests.FindAsync(id);

        if (contactrequest == null)
        {
            return NotFound();
        }
        return Ok(contactrequest);
    }

}
