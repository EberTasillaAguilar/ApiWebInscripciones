using APIIncripccionesChota.Data;
using APIInscripcionesChota.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Asegúrate de tener este using

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. // ESTE ES EL BLOQUE PARA TODOS LOS builder.Services.Add...

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BD_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton<JwtService>();
builder.Services.AddScoped<AuthService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, 
            ValidateAudience = false, 
            ValidateLifetime = true, 
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]) 
            )
        };
    });

builder.Services.AddAuthorization(); 

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BD_Context>();
    try
    {
        dbContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
       
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
    }
}

// Configure the HTTP request pipeline. // ESTE ES EL BLOQUE PARA TODOS LOS app.Use...

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();