using ONGNET;
using Microsoft.AspNetCore.Mvc;
using ONGNET.domain.interfaces;
using ONGNET.doamin.services;
using ONGNET.domain.dto;
using ONGNET.infra.entities;
using ongnet.routes;
using Microsoft.EntityFrameworkCore;
using ongnet.infra.data;
using ONGNET.infra.interfaces;
using ongnet.infra.repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyMethod()
              .AllowAnyHeader()
    );
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

app.UseCors("AllowLocalhost");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UserRoutes();

app.Run();

