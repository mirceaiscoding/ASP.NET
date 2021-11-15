// Unused usings removed
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ReservationsAPI.DAL.Entities;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using ReservationsAPI.DAL;
using ReservationsAPI.DAL.Interfaces;
using ReservationsAPI.DAL.Repositories;
using ReservationsAPI.BLL.Interfaces;
using ReservationsAPI.BLL.Managers;
using System;

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

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}