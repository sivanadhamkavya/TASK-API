using Microsoft.EntityFrameworkCore;
using TMS.Data;
using TMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TaskServices>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DbContextDemo>(options =>
{
    options.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=1756;Database=TaskManagementSystem;Pooling=true;");
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before other middleware
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
