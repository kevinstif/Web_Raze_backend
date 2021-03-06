using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Persistence.Contexts;
using Raze.Api.Persistence.Repositories;
using Raze.Api.Services;
using Raze.Api.Users.Domain.Repositories;
using Raze.Api.Users.Domain.Services;
using Raze.Api.Users.Persistence.Repositories;
using Raze.Api.Users.Services;

namespace Raze.Api
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

            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Raze.Api", Version = "v1"});
                c.EnableAnnotations();
            });

            // Configure In-Memory Database 
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Raze-api-in-memory");
            });

            //Dependencies injection Rules
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentServices, CommentService>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserAdvisedRepository,UserAdvisedRepository>();
            services.AddScoped<IUserAdvisedService,UserAdvisedService>();
            services.AddScoped<IUserAdvisorRepository,UserAdvisorRepository>();
            services.AddScoped<IUserAdvisorService,UserAdvisorService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagServices, TagServices>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //AutoMapper Dependency Injection
            services.AddAutoMapper(typeof(Startup));
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raze.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}