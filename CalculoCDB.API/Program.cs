
using AutoMapper;
using CalculoCDB.API.ViewModel;
using CalculoCDB.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddMvc();

builder.Services.AddControllers();
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ResultadoCalculoCDB, ResultadoCalculadorCDBViewModel>().ReverseMap();
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddScoped<ICalculadorCDBService, CalculadorCDBService>(); // Configuração da injeção de dependência


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
