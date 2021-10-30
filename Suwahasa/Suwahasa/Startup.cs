using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Suwahasa.Common;
using Suwahasa.Common.Middlewares;
using Suwahasa.Data.Repositories;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services;
using Suwahasa.Services.Interfaces;
using System;

namespace Suwahasa
{
  public class Startup
  {
	readonly string allowSpecificOrigins = "allowSpecificOrigins";

	public Startup(IConfiguration configuration)
	{
	  Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
	  services.AddControllersWithViews().AddNewtonsoftJson(options =>
		options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	  );

	  services.AddSwaggerGen(c =>
	  {
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "Suwahasa.API", Version = "v1" });
	  });

	  services.AddHttpContextAccessor();
	  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

	  //Injecting services
	  services.AddScoped<IHospitalsServices, HospitalsServices>();
	  services.AddScoped<IEmployeesServices, EmployeesServices>();
	  services.AddScoped<IVehiclesServices, VehiclesServices>();
	  services.AddScoped<IPackagesServices, PackagesServices>();
	  services.AddScoped<IAuthServices, AuthServices>();
	  services.AddScoped<IBookingsServices, BookingsServices>();
	  services.AddScoped<IBedTicketsServices, BedTicketsServices>();
	  services.AddScoped<ICovidTestResultsServices, CovidTestResultsServices>();

	  //Injecting repositories
	  services.AddScoped<IHospitalsRepository, HospitalsRepository>();
	  services.AddScoped<IEmployeesRepository, EmployeesRepository>();
	  services.AddScoped<IVehiclesRepository, VehiclesRepository>();
	  services.AddScoped<IPackagesRepository, PackagesRepository>();
	  services.AddScoped<IUserRepository, UserRepository>();
	  services.AddScoped<IBookingsRepository, BookingsRepository>();
	  services.AddScoped<IBedTicketsRepository, BedTicketsRepository>();
	  services.AddScoped<ICovidTestResultsRepository, CovidTestResultRepository>();

	  // In production, the Angular files will be served from this directory
	  services.ConfigureCors(allowSpecificOrigins);
	  services.AddDistributedMemoryCache();
	  services.AddSession(options =>
	  {
		options.IdleTimeout = TimeSpan.FromSeconds(3600);
		options.Cookie.HttpOnly = true;
		options.Cookie.IsEssential = true;
	  });
	  services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
	  {
		option.LoginPath = "/";
		option.Cookie.Name = "SuwahasaAuthCookie";
		option.SlidingExpiration = true;
		option.ExpireTimeSpan = TimeSpan.FromMinutes(120);
	  });
	  services.AddSpaStaticFiles(configuration =>
	  {
		configuration.RootPath = "ClientApp/dist/Suwahasa";
	  });
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
	  if (env.IsDevelopment())
	  {
		app.UseDeveloperExceptionPage();
	  }
	  else
	  {
		app.UseExceptionHandler("/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	  }

	  app.UseSwagger();
	  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Suwahasa.API v1"));

	  app.UseMiddleware<ExceptionMiddleware>();

	  app.UseHttpsRedirection();
	  app.UseStaticFiles();
	  if (!env.IsDevelopment())
	  {
		app.UseSpaStaticFiles();
	  }

	  app.UseRouting();

	  app.UseAuthentication();
	  app.UseAuthorization();
	  app.UseCookiePolicy();
	  app.UseSession();
	  app.UseCors(allowSpecificOrigins);

	  app.UseEndpoints(endpoints =>
	  {
		endpoints.MapControllerRoute(
				  name: "default",
				  pattern: "{controller}/{action=Index}/{id?}");
	  });

	  app.UseSpa(spa =>
	  {
			  // To learn more about options for serving an Angular SPA from ASP.NET Core,
			  // see https://go.microsoft.com/fwlink/?linkid=864501

			  spa.Options.SourcePath = "ClientApp";

		if (env.IsDevelopment())
		{
		  spa.UseAngularCliServer(npmScript: "start");
		}
	  });
	}
  }
}
