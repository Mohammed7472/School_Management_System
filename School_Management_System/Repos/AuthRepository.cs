using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using School_Management_System.Data;
using School_Management_System.DTOs;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_Management_System.Repos;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext context;
    private readonly IConfiguration config;

    public AuthRepository(AppDbContext context, IConfiguration config)
    {
        this.context = context;
        this.config = config;
    }
    public async Task<string?> Login(LoginRequestDTO dto)
    {
        var existingUser = await context.ApplicationUsers
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser == null)
            return null;

        if (existingUser.Password == dto.Password)
            return GenerateToken(existingUser.Email);

        return null;
    }

    public async Task<bool> Register(ApplicationUser user)
    {
        var existEmail = await context.ApplicationUsers.AnyAsync(a => a.Email == user.Email);

        if (existEmail)
            return false;

        context.ApplicationUsers.Add(user);
        await context.SaveChangesAsync();

        return true;
    }

    private string GenerateToken(string email)
    {
        #region user_claims

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Name, email),
            new Claim("mobile", "01234567890"),

        };

        #endregion

        #region Key
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JWT:Key"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        #endregion

        var tokenObj = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(config["JWT:ExpirationInHours"]))
            );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenObj);
        return token;
    }
}
