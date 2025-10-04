using Demo.BLL;
using Demo.BLL.Services;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Reposatories;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services : Add Services to the DI container .
            builder.Services.AddControllersWithViews();
            // builder.Services.AddScoped<ApplicationDbContext>(); //Register Service  
            //Give ClR Permission to Inject Dervice If Needed  

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //var conString = builder.Configuration["ConnectionSreings : DefaultConnection"];
                //var conString = builder.Configuration.GetSection("ConnectionStrings")["ConnectionSreings : DefaultConnection"];
                var conString = builder.Configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(conString);


            });
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); // interface with his Service  بديلو ال   
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();   


            #endregion


            // builder.Services.AddScoped<DepartmentService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

           

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();


        }
    }
}
