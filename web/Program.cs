using Core;
using Infra;
using Microsoft.EntityFrameworkCore;
using Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
      opt =>
      {
          opt.Cookie.HttpOnly = true;
          opt.IdleTimeout = TimeSpan.FromMinutes(20);
          opt.Cookie.IsEssential = true;
      }
     );
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CompanyContext>(
    opt =>opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );

builder.Services.AddScoped<ITrainingCompany, TrainingCompanyRepo>();
builder.Services.AddScoped<ISubjectStreamRepo, SubjectStreamRepo>();
builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapDefaultControllerRoute();
app.Run();
