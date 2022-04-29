﻿using DopplerWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Prefer the use of environment variables using the 'dotnet-env` name transformer
builder.Services.Configure<Doppler>(builder.Configuration);

// While not recommended, can also use 'doppler secrets download' with the 'dotnet' name transformer
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("doppler.secrets.json", optional: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
