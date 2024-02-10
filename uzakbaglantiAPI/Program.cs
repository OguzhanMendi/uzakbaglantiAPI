using Microsoft.EntityFrameworkCore;
using uzakbaglantiAPI.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using uzakbaglantiAPI.Repositories.Interfaces;
using uzakbaglantiAPI.Repositories.Abstract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com", // JWT'nin doðru olduðunu doðrulamak için kullanýlan geçerli veren
            ValidAudience = "yourdomain.com", // JWT'nin doðru olduðunu doðrulamak için kullanýlan geçerli izleyici
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ModülYazilim10082002@?56?231198312@@")) // JWT'nin doðru olduðunu doðrulamak için kullanýlan simetrik anahtar
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<uzakContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
//});

builder.Services.AddSingleton<uzakContext>();

builder.Services.AddScoped<IBaglantiRepository,BaglantiRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();



var app = builder.Build();
app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();