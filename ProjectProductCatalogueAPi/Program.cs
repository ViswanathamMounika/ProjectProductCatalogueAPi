using BussinessLogic;
using FluentiAPi;
using Microsoft.EntityFrameworkCore;
using FluentiAPi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HackathonContext>(Options => Options.UseSqlServer("\"Server=LAPTOP-C6NC4U0J;Database=hackathon;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IRepo,EfRepo>();
builder.Services.AddScoped<ILogic, Logic > ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
