using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_Management_System.Data;
using School_Management_System.DTOs;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;
using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository repo;

    public AuthController(IAuthRepository repo)
    {
        this.repo = repo;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
    {
        var result = await repo.Login(dto);

        if (result == null)
            return Unauthorized("email or password not valid");

        return Ok(result);
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequestDTO dto)
    {
        if (dto == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        var regrequest = new ApplicationUser
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.Password,
            Role = "Student"
        };

        if (await repo.Register(regrequest) == true)
        {
            return Created();
        }

        return BadRequest("email already exists");

    }




}
