using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
using first_app.Data;
using System.Net.WebSockets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("users-api", domain => domain.WithOrigins("")
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
        });


        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
                new MySqlServerVersion(new Version(8, 0, 21))));

        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());


        //builder.Services.AddAuthorization(

        //    opt =>
        //    {
        //        opt.DefaultPolicy = new AuthorizationPolicyBuilder()
        //            .RequireAuthenticatedUser()
        //            .Build();
        //    }
        //);

        //builder.Services.AddScoped<IProductRepository, ProductRepository>();

        //builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

        //builder.Services.AddScoped<IProductCommandService, ProductCommandService>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
     
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
            
        }


        app.UseCors("users-api");
        app.Run();
    }
}