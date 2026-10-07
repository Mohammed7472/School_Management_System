using Microsoft.AspNetCore.Identity.Data;
using School_Management_System.DTOs;
using School_Management_System.Models;
using System.Security.Cryptography.Pkcs;

namespace School_Management_System.Repos.Abstraction;

public interface IAuthRepository
{
    public Task<string> Login(LoginRequestDTO dto);
    public Task<bool> Register(ApplicationUser user);

}
