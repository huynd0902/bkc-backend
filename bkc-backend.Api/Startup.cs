using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using bkc_backend.Api.Helpers;
using bkc_backend.Controller.Helpers;
using bkc_backend.Data;
using bkc_backend.RazorEmail;
using bkc_backend.Services;
using bkc_backend.Services.AutoMapping;
using bkc_backend.Services.EmployeeServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace bkc_backend.Api
{

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; set; }
        public Startup()
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      //builder.WithOrigins("https://localhost:3000", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                                      builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                                  });
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddOptions();
            var mailSettings = Configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSettings);
            //var mapperConfig = new MapperConfiguration(mc => {
            //    mc.AddProfile(new AutoMapping());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(AutoMappingController));
            services.AddAutoMapper(typeof(AutoMappingServices));
            //services.AddAutoMapper(typeof(AutoMapping));
            services.AddDbContext<BookingCarDbContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            //services.AddDbContext<BkcDbContext>(options => options.UseSqlServer("Server=.; Database=HRAD;User Id=sa;password=123456"));
            //services.AddDbContext<BkcDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICreateToken, CreateToken>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IUserRoleServices, UserRoleServices>();
            services.AddScoped<ITicketSerivces, TicketServices>();
            services.AddScoped<IRelatedPeopleServices, RelatedPeopleServices>();
            services.AddScoped<ILocationServices, LocationServices>();
            services.AddScoped<IParticipantServices, ParticipantServices>();
            services.AddScoped<IDriverServices, DriverServices>();
            services.AddScoped<ICarServices, CarServices>();
            services.AddScoped<IBusinessUnitSerivces, BusinessUnitServices>();
            services.AddScoped<ITripServices, TripServices>();
            services.AddScoped<ITicketTripServices, TicketTripServices>();
            services.AddScoped<ISendMailServices, SendMailServices>();
            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            //services.AddScoped<IRazorViewEngine, RazorViewEngine>();
            //services.AddScoped<IServiceProvider, ServiceProvider>();
            var key = Encoding.UTF8.GetBytes(Configuration["Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
