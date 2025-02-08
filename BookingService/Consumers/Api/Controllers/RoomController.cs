﻿using Application.Room.Models.Requests;
using Application.Room.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoomController(IRoomService roomService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomRequest request)
    {
        var result = await roomService.CreateRoomAsync(request);
        return Ok(result);
    }
}
