using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcomProject_1144.DataAccess.Data;
using EcomProject_1144.DataAccess.Repositry.IRepositry;
using EcomProject_1144.DataAccess.Repositry;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Identity.UI.Services;
using EcomProject_1144.Utility;
using EComProject_1144.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("ConStr") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(cs));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
//builder.Services.AddScoped<ICategoryRepositry, ICategoryRepositry>();
//builder.Services.AddScoped<ICoverTypeRepositry, ICoverTypeRepositry>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Here we set the path 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Logout";
    options.LoginPath = $"/Identity/Account/Login";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


//builder.Services.AddAuthentication().AddFacebook(
//    options =>
//    {
//        options.AppId = "1573396303325144";
//        options.AppSecret = "30cc630c8c751379e7dbbff31fd3fe7c";
//    });

//builder.Services.AddAuthentication().AddGoogle(
//    options =>
//    {
//        options.ClientId = "531554054063-7ebf5foemknet5h35ohjslv9gq4lbcsj.apps.googleusercontent.com";
//        options.ClientSecret = "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";
//    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

builder.Services.Configure<StripeSettings>
    (builder.Configuration.GetSection("StripeSettings"));

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

app.UseSession();
app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
