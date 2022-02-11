using Antropov.TaskManager.Api.Services;
using Antropov.TaskManager.Data.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.Configure<TaskManagerDbSettings>(
	builder.Configuration.GetSection("TaskManagerDb"));
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo()
	{
		Version = "v1",
		Title = "Task Manager API",
		Description = "An ASP.NET Core Web API for managing Tasks",
	});
	options.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(options => 
	options.WithOrigins("http://localhost:3000", "https://localhost:3001").AllowAnyMethod().AllowAnyHeader());

app.Run();

public partial class Program { }