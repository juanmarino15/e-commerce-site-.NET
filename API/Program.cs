using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//this is the entry point of the application!!!!!!!!

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
//middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment()) //middleware
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();//middleware

app.MapControllers();//middleware


using var scope = app.Services.CreateScope(); 
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}catch(Exception ex){
    logger.LogError(ex,"An error occured during migration");
}


app.Run();
