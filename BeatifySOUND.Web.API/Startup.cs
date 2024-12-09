using System.Reflection;
using Beautify.Application;
using Beautify.Application.Common.MappingProfile;
using Beautify.Application.Interfaces;
using Beautify.PersistenceDb;
using BeautifySOUND.Web.API.Middlewares;

namespace BeautifySOUND.Web.API;

public class Startup(IConfiguration configuration)
{
    public void ConfigureService(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IBeautifyDbContext).Assembly));
        });

        services.AddAplication();
        services.AddPersistance(configuration);
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCustomExceptionHandler();
        app.UseMiddleware<CustomUxceptionHandlerMiddleware>();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors("AllowAll");

        app.UseEndpoints(endPoints =>
        {
            endPoints.MapControllers();
        });
    }
}
