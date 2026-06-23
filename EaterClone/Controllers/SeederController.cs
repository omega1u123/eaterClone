using EaterClone.Domain;
using EaterClone.Domain.Entities;
using EaterClone.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EaterClone.Controllers;

[ApiController]
[Route("[controller]")]
public class SeederController(CsvProductParser parser, AppDbContext dbContext) : ControllerBase
{
    [HttpGet("SeedDb")]
    public async Task SeedDb()
    {
        var parsedProducts = await parser.ParseAsync();

        var productsToDb = parsedProducts.Select(x => 
            new ProductEntity
            {
                Name =  x.Name,
                Carbs = (float)x.Carbs,
                Fats = (float)x.Fats,
                Proteins = (float)x.Proteins,
            }
            ).ToList();

        await dbContext.AddRangeAsync(productsToDb);
        await dbContext.SaveChangesAsync();
    }
}