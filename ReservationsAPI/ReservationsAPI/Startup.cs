// Unused usings removed
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using Microsoft.OpenApi.Models;
using ReservationsAPI.DAL;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Repositories;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.BLL.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using ReservationsAPI.BLL.Helpers;
using System.Collections.Generic;

namespace ReservationsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ReservationsContext>(opt =>
                                               opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservationsApi", Version = "v1" });
                c.MapType<TimeSpan?>(() => new OpenApiSchema { Type = "string", Example = new Microsoft.OpenApi.Any.OpenApiString("00:00:00") });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IAppointmentsManager, AppointmentsManager>();
            services.AddTransient<IDoctorsManager, DoctorsManager>();
            services.AddTransient<IPacientsManager, PacientsManager>();
            services.AddTransient<IProceduresManager, ProceduresManager>();
            services.AddTransient<IWorkDayScheduleManager, WorkDayScheduleManager>();

            services.AddTransient<IAppointmentsRepository, AppointmentsRepository>();
            services.AddTransient<IDoctorsRepository, DoctorsRepository>();
            services.AddTransient<IPacientsRepository, PacientsRepository>();
            services.AddTransient<IProceduresRepository, ProceduresRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // AUTH
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<IAuthManager, AuthManager>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("Doctor", policy => policy.RequireRole("Doctor").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("Pacient", policy => policy.RequireRole("Pacient").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ReservationsContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<InitialSeed>();

            services
                .AddAuthentication(options =>
                {

                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            // Just in case: services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientsApi v1"));
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            initialSeed.CreateRoles();
        }
    }
}