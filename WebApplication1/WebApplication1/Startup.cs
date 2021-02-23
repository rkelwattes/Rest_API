using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1
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
            //Specify the database context to the DI container and register it as a service
            services.AddDbContext<TodoContext>(opt =>
            opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();

            services.AddDbContext<UserContext>(opt =>
            opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();

            //services.AddDbContext<WebApplication1Context>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("WebApplication1Context")));
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            //Adds route matching to the middleware pipeline. The middleware looks at the set of endpoints
            // defined in the app and selects the best match based on the request
            app.UseRouting();

            app.UseAuthorization();

            //Add endpoint execution to the middleware pipeline. 
            app.UseEndpoints(endpoints =>
            {
                // Adds endpoints for controller actions to the IEndpointRouteBuilder without specifying any routes.
                endpoints.MapControllers();
            });
        }
    }
}
