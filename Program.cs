using Microsoft.EntityFrameworkCore;
using LaboratorioRestApi.Models;
using Microsoft.OpenApi.Models;
using LaboratorioRestApi;
using LaboratorioRestApi.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LaboratorioRestAPI") ?? "Data Source=LaboratorioRestAPI.db";
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<LaboratorioRestApiDbContext>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();