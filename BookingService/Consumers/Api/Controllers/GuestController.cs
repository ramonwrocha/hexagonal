using Application.Guest.Models.Requests;
using Application.Guest.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestController(IGuestService guestService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGuestAsync([FromBody] CreateGuestRequest request)
    {
        var response = await guestService.CreateGuestAsync(request);
        if (response.Success)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}
