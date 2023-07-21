using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.BL.Managers;
using RestaurantApp.DAL;
using RestaurantApp.DAL.Data.Context;
using System.Text;

namespace RestaurantApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

          
            //-------------------

            builder.Services.AddDbContext<UserContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Restaurant_DB")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
            //----------------------

            builder.Services.AddScoped<IUsersManager, UsersManager>();

            //--------------------

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            })
                 .AddEntityFrameworkStores<UserContext>();
            ///--------------------------
            ///


            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "default";
                option.DefaultChallengeScheme = "default";

            }).AddJwtBearer("default", option =>
            {
                string keyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
                var keyInBytes = Encoding.ASCII.GetBytes(keyString);
                var key = new SymmetricSecurityKey(keyInBytes);

                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };

            });

            //builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            //.AddEntityFrameworkStores<UserContext>()
            //.AddDefaultTokenProviders();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}