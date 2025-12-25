using HospitalAPI.Data;
using HospitalAPI.Interfaces;
using HospitalAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. TODOS los servicios se agregan ANTES de Build()
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<HpContext>(options =>
    options.UseInMemoryDatabase("HospitalDB"));

builder.Services.AddScoped<ISpecializationService, SpecializationService>();

// ← Swagger se agrega AQUÍ, antes de Build
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Los middlewares van DESPUÉS de Build()
app.UseSwagger();
app.UseSwaggerUI();  // Ahora aparecerá en https://localhost:xxxx/swagger

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();