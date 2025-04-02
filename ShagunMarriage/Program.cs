using ShagunMarriage;
using ShagunMarriage.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShagunMarriage.Services;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.ConfigureServices((context, services) =>
               {
                   IConfiguration configuration = context.Configuration;
                   services.AddDbContext<ShagunMarriageDbContext>(options =>
                          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                   RegisterServices.Register(services);
                   services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                    });

                   services.AddSession(options =>
                   {
                       options.IdleTimeout = TimeSpan.FromMinutes(30);
                       options.Cookie.HttpOnly = true;
                       options.Cookie.IsEssential = true;
                   });
                   // Add AutoMapper
                   services.AddAutoMapper(typeof(MappingProfile));

                   services.AddRazorPages();
               })
               .Configure((context, app) =>
               {
                   var env = context.HostingEnvironment;

                   if (env.IsDevelopment())
                   {
                       app.UseDeveloperExceptionPage();
                   }
                   else
                   {
                       app.UseExceptionHandler("/Home/Error");
                       app.UseHsts();
                   }

                   app.UseHttpsRedirection();
                   app.UseStaticFiles();

                   app.UseRouting();

                   app.UseAuthentication();
                   app.UseAuthorization();
                   app.UseSession();

                   app.UseEndpoints(endpoints =>
                   {
                       endpoints.MapRazorPages();
                       endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=UserLogin}/{action=Login}/{id?}");

                   });
               });
           });
}