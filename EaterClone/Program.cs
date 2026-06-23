using EaterClone;
using EaterClone.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAuthenticationAndAuthorization();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }


app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
    
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext!.Database.Migrate();
}

app.Run();