using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Commander.Service;
using Commander.Interface;
using Microsoft.EntityFrameworkCore;
using Commander.Database;
using Commander.Repository;
using Commander.Error;

namespace Commander
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
      services.AddControllers();

      services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      // Repository
      services.AddTransient<ICommandRepository, CommandRepository>();

      // Service
      services.AddTransient<ICommandService, CommandService>();

      services.AddTransient<ExceptionHandlerMiddleware>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseMiddleware<ExceptionHandlerMiddleware>();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

    }
  }
}
