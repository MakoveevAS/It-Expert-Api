using FluentValidation;
using FluentValidation.AspNetCore;
using It_Expert.DataBase;
using It_Expert.DependencyResolution;
using It_Expert.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLogging(builder => {
    builder.ClearProviders();
    builder.AddConsole().SetMinimumLevel(LogLevel.Debug);
});

builder.Services.AddCors(p => p.AddPolicy("allowAny", builder => builder.WithOrigins("localhost").AllowAnyOrigin().AllowAnyHeader()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.ReportApiVersions = true;
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<PostRequestValidator>();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase(builder.Configuration.GetConnectionString("InMemoryDb")));

builder.Services.AddServicesDi();
   

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowAny");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
