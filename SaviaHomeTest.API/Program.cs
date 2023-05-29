using SaviaHomeTest.Infrastructure.Persistence;
using SaviaHomeTest.Application.Extensions;
using SaviaHomeTest.Infrastructure.Extensions;
using SaviaHomeTest.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContextRead = services.GetRequiredService<AppDbContextRead>();
    var dbContextWrite = services.GetRequiredService<AppDbContextWrite>();

    dbContextRead.Database.EnsureCreated();
    dbContextWrite.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddlewares();

app.MapControllers();

app.Run();
