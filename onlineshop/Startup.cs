using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using onlineshop.Data;
using onlineshop.Models;
using onlineshop.Services;
using onlineshop.Services.Implimentation;
using onlineshop.Services.Mapper;
using onlineshop.Services.Mapper.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace onlineshop
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
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //identity configure

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI().AddDefaultTokenProviders();

            //configure path
            

            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    options => {
                        options.LoginPath = "/Users/Login";
                        options.LogoutPath = "/Users/Logout";
                        options.AccessDeniedPath = "/Users/Login";
                        options.ReturnUrlParameter = "/Home/Index";
                    }
                );

            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = p =>
                    {
                        p.Response.Redirect("/Users/Login");
                        return Task.CompletedTask;
                    },
                    OnRedirectToLogout = p =>
                    {
                        p.Response.Redirect("/Users/Logout");
                        return Task.CompletedTask;
                    },
                    OnRedirectToReturnUrl = p =>
                    {
                        p.Response.Redirect("/Home/Index");
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdmiRole", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
                options.AddPolicy("BuyerRole", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "buyer");
                });
                options.AddPolicy("SellerRole", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "SELLER");
                });
                options.AddPolicy("OwnerRole", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "owner");
                });
                options.AddPolicy("AdminAndSeller", policy =>
                {
                    policy.RequireRole("admin", "seller");
                });
                options.AddPolicy("AdminAndOwner", policy =>
                {
                    policy.RequireRole("admin", "owner");
                });
                options.AddPolicy("SellerAndOwner", policy =>
                {
                    policy.RequireRole("seller", "owner");
                });

            });

            //add session

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            

            //register DI contaioners
            //mapper
            services.AddScoped<IBasketMapper, BasketMapperImpl>();
            services.AddScoped<ICategoryMapper, CategoryMapperImpl>();
            services.AddScoped<ICommentMapper, CommentMapperImpl>();
            services.AddScoped<IDeliveryMethodMapper, DeliveryMethodMapperImpl>();
            services.AddScoped<IEvaluationQueueMapper, EvaluationQueueMapperImpl>();
            services.AddScoped<IEventMapper, EventMapperImpl>();
            services.AddScoped<IOrderMapper, OrderMapperImpl>();
            services.AddScoped<IPaymentMethodMapper, PaymentMethodMapperImpl>();
            services.AddScoped<IProductMapper, ProductMapperImpl>();
            services.AddScoped<IRoleMapper, RoleMapperImpl>();
            services.AddScoped<ISupperFirmMapper, SupplerFirmMapperImpl>();
            services.AddScoped<IUserMapper, UserMapperImpl>();
            

            services.Configure<PasswordHasherOptions>(options =>
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );
            //services
            services.AddScoped<IBasketService, BasketServiceImpl>();
            services.AddScoped<ICategoryService, CategoryServiceImpl>();
            services.AddScoped<ICommentService, CommentServiceImpl>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodServiceImpl>();
            services.AddScoped<IEvaluationQueueService, EvaluationQueueServiceImpl>();
            services.AddScoped<IEventService, EventServiceImpl>();
            services.AddScoped<IOrderService, OrderServiceImpl>();
            services.AddScoped<IPaymentMethodService, PaymentMethodServiceImpl>();
            services.AddScoped<IProductService, ProductServiceImpl>();
            services.AddScoped<IRoleService, RoleServiceImpl>();
            services.AddScoped<ISupplerFirmService, SupplerFirmServiceImpl>();
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<ICountryService, CountryServiceImpl>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //configure error listener
            app.UseStatusCodePagesWithRedirects("/Error?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            //use session
            app.UseSession();

            // app.UseStatusCodePages("text/plain", "Error. Status code : {0}");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


        }
    }
}
