﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BankingProyect
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DbContextBSystem>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				using (var scope = app.ApplicationServices.CreateScope())
				{
					DbContextBSystem context = scope.ServiceProvider.GetRequiredService<DbContextBSystem>();
					context.Database.Migrate();
				}
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Users}/{action=Index}/{id?}");
			});
		}
	}
}
