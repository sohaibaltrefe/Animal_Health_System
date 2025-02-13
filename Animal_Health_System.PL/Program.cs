using Animal_Health_System.BLL.Interface;
using Animal_Health_System.BLL.Repository;
using Animal_Health_System.DAL.Data;
using Animal_Health_System.PL.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Animal_Health_System.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            builder.Services.AddScoped<IAnimalHealthHistoryRepository, AnimalHealthHistoryRepository>();
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<IAppointmentHistoryRepository, AppointmentHistoryRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IBirthRepository, BirthRepository>();



            builder.Services.AddScoped<IFarmHealthSummaryRepository, FarmHealthSummaryRepository>();
            builder.Services.AddScoped<IFarmRepository, FarmRepository>();
            builder.Services.AddScoped<IFarmStaffRepository, FarmStaffRepository>();
            builder.Services.AddScoped<IFarmVeterinarianRepository, FarmVeterinarianRepository>();
            builder.Services.AddScoped<IHealthStatusLogRepository, HealthStatusLogRepository>();

            builder.Services.AddScoped<IMatingRepository, MatingRepository>();
            builder.Services.AddScoped<IMedicalExaminationRepository, MedicalExaminationRepository>();
            builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
            builder.Services.AddScoped<IPregnancyRepository, PregnancyRepository>();
            builder.Services.AddScoped<IVaccineHistoryRepository, VaccineHistoryRepository>();
            builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
            builder.Services.AddScoped<IVeterinarianRepository, VeterinarianRepository>();


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                 name: "areas",
            pattern: "{area:exists}/{controller=Farm}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
