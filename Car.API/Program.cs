using Car.API.DB;
using Car.API.Middleware;
using Car.API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VechicleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICarService, CarService>(); // Register the service correctly
builder.Services.AddScoped<ICarModelService, CarModelService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Exception handling middleware in non-development environment
    app.UseExceptionHandler("/error");
}

// Use your custom exception middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
