global using System;
global using System.Collections.Generic;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Models;

namespace ToDoList;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ToDoListContext>(
            dbContextOptions => dbContextOptions.UseMySql(
                builder.Configuration["ConnectionStrings:DefaultConnection"],
                ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])
            )
        );
        WebApplication app = builder.Build();

        // app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
        app.Run();
    }
}