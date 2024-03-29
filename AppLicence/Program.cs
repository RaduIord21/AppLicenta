using AppLicence.DataModels.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AppLicence.Infrastructure;
using AppLicence.DataAccessLayer.Interfaces;
using AppLicence.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddReact();
builder.Services.AddCors(options =>
{    options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
// Make sure a JS engine is registered, or you will get an error!
builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddDbContext<AchieveHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppLicence"), b => b.MigrationsAssembly("AppLicence")));
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseReact(config =>
{
    // If you want to use server-side rendering of React components,
    // add all the necessary JavaScript files here. This includes
    // your components as well as all of their dependencies.
    // See http://reactjs.net/ for more information. Example:
    config.AddScript("~/js/Components/Tutorial.jsx");
    //    .AddScript("~/js/Second.jsx");

    // If you use an external build too (for example, Babel, Webpack,
    // Browserify or Gulp), you can improve performance by disabling
    // ReactJS.NET's version of Babel and loading the pre-transpiled
    // scripts. Example:
    //config
    //    .SetLoadBabel(false)
    //    .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
});
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
