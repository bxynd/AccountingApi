using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllUsers());
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody]UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        try
        {
            return Ok(await _userService.AddUser(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpGet("ByUserId/{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _userService.GetUserById(id));
    }
    
    [HttpPut("{id:Guid}")]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        try
        {
            return Ok(await _userService.UpdateUser(id,user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok(await _userService.DeleteUser(id));
    }
}