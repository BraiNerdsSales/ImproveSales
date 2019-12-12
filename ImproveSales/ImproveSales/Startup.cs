namespace ImproveSales
{
    using ImproveSales.Database;
    using ImproveSales.Database.Helpers;
    using ImproveSales.Database.Models;
    using ImproveSales.Resources.Helpers;
    using ImproveSales.Resources.Helpers.Attributes;
    using ImproveSales.Services.Policies;
    using ImproveSales.Resources;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Identity.UI.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<ImproveSalesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(Translator.ConnectionStringName)));
            services.AddIdentity<User, Role>(options =>
                    {
                        options.SignIn.RequireConfirmedEmail = true;
                        options.SignIn.RequireConfirmedAccount = true;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredUniqueChars = 0;
                        options.Password.RequiredLength = 6;
                        options.Lockout.MaxFailedAccessAttempts = 15;
                        options.User.RequireUniqueEmail = true;
                    })
                   .AddEntityFrameworkStores<ImproveSalesDbContext>()
                   .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
                options.AddPolicy("AuthorizedRequirement", policy => policy.Requirements.Add(new AuthorizationRequirement("Identity/Account/Login"))));

            RegisterInterfaces(services);
        }

        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env,
                              UserManager<User> userManager,
                              RoleManager<Role> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthorization();
            IdentityDataIniatilizer.SeedData(userManager, roleManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            using (var dbContext = app
                        .ApplicationServices
                        .GetRequiredService<IServiceScopeFactory>()
                        .CreateScope()
                        .ServiceProvider
                        .GetService<ImproveSalesDbContext>())
            {
                dbContext.Database.Migrate();
            }
        }

        private void RegisterInterfaces(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, AuthorizedHandler>();

            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
