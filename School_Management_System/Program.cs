
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using School_Management_System.Data;
using School_Management_System.Repos;
using School_Management_System.Repos.Abstraction;
using School_Management_System.UnitWork;
using System.Diagnostics;
using System.Text;

namespace School_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddScoped<IStudentRepository, StudentRepostiory>();
            //builder.Services.AddScoped<IStudentRepository, StudentListRepository>();
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IStudentRepository, StudentRepostiory>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            //builder.Services.AddAutoMapper(typeof(Program).Assembly);



            #region JWTValidationService
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //opt.DefaultForbidScheme = 
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                        builder.Configuration["JWT:Key"]
                        )),
                };
            });
            #endregion


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            // inline component middleware
            app.Use(async (context, next) =>
            {
                // logic
                Stopwatch s = new Stopwatch();
                s.Start();
                Console.WriteLine($"Method: {context.Request.Method}");

                await next();

                Console.WriteLine($"Time : {s.ElapsedMilliseconds} ms");

            });



            app.UseAuthorization();




            app.MapControllers();


            app.Run();


        }

    }
}
