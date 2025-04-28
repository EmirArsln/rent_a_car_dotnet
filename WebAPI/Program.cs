using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependenycResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encrptions;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions; 
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Use Autofac as the DI container
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new AutofacBusinessModule());
            });


            builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });

            builder.Services.AddCors();

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions?.Issuer ?? "DefaultIssuer", // Null kontrol� ve varsay�lan de�er
                        ValidAudience = tokenOptions?.Audience ?? "DefaultAudience", // Null kontrol� ve varsay�lan de�er
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions?.SecurityKey ?? "DefaultSecurityKey") // Null kontrol� ve varsay�lan de�er
                    };
                });
            
            // Add services to the container
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors(builder=>builder.WithOrigins("https://localhost:44346").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}





// [HttpPost("transaction")]
//public IActionResult TransactionTest(Car car)
//{
//  var result = _carService.TransactionalOperation(car);
//if (result.Success)
//{
//  return Ok(result.Message);
//}

//return BadRequest(result.Message);
//}