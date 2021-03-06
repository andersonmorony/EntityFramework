﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Win.Data;
using Win.Models;
using Win.Services;
using Win.Interfaces.Services;
using Win.Interfaces.Repository;
using Win.Repository;
using AutoMapper;
using Win.ViewModels;
using Win.Models.ManageViewModels;

namespace Win
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IFeedService, FeedService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            // Add Application Repository
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            Mapper.Initialize(config =>
            {
                config.CreateMap<PostViewModel, Post>().ReverseMap();
                config.CreateMap<ApplicationUser, Models.AccountViewModels.RegisterViewModel>().ReverseMap();
                config.CreateMap<ApplicationUser, IndexViewModel>().ReverseMap();
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
