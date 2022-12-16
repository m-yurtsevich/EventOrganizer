using EventOrganizer.Core.Commands;
using EventOrganizer.Core.Commands.EventCommands;
using EventOrganizer.Core.DTO;
using EventOrganizer.Core.Queries;
using EventOrganizer.Core.Queries.EventQueries;
using EventOrganizer.Core.Repositories;
using EventOrganizer.Domain.Models;
using EventOrganizer.EF;
using EventOrganizer.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventOrganizer.WebClient
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

            services.AddDbContext<EventOrganazerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IQuery<GetEventListQueryParameters, IList<EventDTO>>, GetEventListQuery>();
            services.AddTransient<IQuery<GetEventByIdQueryParameters, EventDetailDTO>, GetEventByIdQuery>();

            services.AddTransient<IEventRepository, EventRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{id?}");
            });
        }
    }
}
