using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raze.Api.Domain.Repositories;
using Raze.Api.Domain.Services;
using Raze.Api.Persistence.Repositories;
using Raze.Api.Security.Authorization.Handlers.Implementations;
using Raze.Api.Security.Authorization.Handlers.Interfaces;
using Raze.Api.Security.Authorization.Middleware;
using Raze.Api.Security.Authorization.Settings;
using Raze.Api.Security.Domain.Repositories;
using Raze.Api.Security.Domain.Services;
using Raze.Api.Security.Persistence.Repositories;
using Raze.Api.Security.Services;
using Raze.Api.Services;
using Raze.Api.Shared.Domain.Repositories;
using Raze.Api.Shared.Persistence.Contexts;
using Raze.Api.Shared.Persistence.Repositories;

namespace Raze.Api
{
    public class Startup
    {
        private readonly string _MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. 
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Raze.Api", Version = "v1"});
                c.EnableAnnotations();
            });
            
            //Configure Cors
            /*
            services.AddCors(o =>
            {
                o.AddPolicy(name: _MyCors, b =>
                {
                    b.SetIsOriginAllowed(o => new Uri(o).Host == "localhost")
                        .AllowAnyHeader().AllowAnyMethod();
                });
            });
            */

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            // Configure In-Memory Database 
            //services.AddDbContext<AppDbContext>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Raze-api-in-memory");
            });

            //Dependencies injection Rules
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentServices, CommentService>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagServices, TagServices>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            //AutoMapper Dependency Injection
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_MyCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}