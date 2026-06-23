using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace EaterClone.Utils;

/// <summary>
/// Результат разбора — record с positional-параметрами (primary constructor).
/// </summary>
public sealed record ProductNutrition(
    string Name,
    double Proteins,
    double Fats,
    double Carbs
);

public sealed class CsvProductParser
{

    public async Task<List<ProductNutrition>> ParseAsync()
    {
        //var filePath = Path.Combine(AppContext.BaseDirectory, "calorie_table_max.csv");
        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(), // поднимаемся из bin/Debug/net10.0/ в корень проекта
            "calorie_table_max.csv"
        );
        // 1. Читаем файл и выполняем замену n" -> \n" (аналог Transform-стрима из Node.js)
        var rawContent = await File.ReadAllTextAsync(filePath);
        var fixedContent = rawContent.Replace("n\"", "\n\"");

        // 2. Настраиваем CsvHelper
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,     // не падать, если колонки нет
            HeaderValidated = null,       // не падать при несовпадении заголовков
            BadDataFound = null,          // игнорировать "битые" поля
        };

        using var reader = new StringReader(fixedContent);
        using var csv = new CsvReader(reader, config);

        var results = new List<ProductNutrition>();

        // 3. Асинхронно читаем заголовок и строки
        await csv.ReadAsync();
        csv.ReadHeader();

        while (await csv.ReadAsync())
        {
            results.Add(new ProductNutrition(
                Name:     csv.GetField("Продукт")?.Trim() ?? string.Empty,
                Proteins: ParseDouble(csv.GetField("Белки (г)")),
                Fats:     ParseDouble(csv.GetField("Жиры (г)")),
                Carbs:    ParseDouble(csv.GetField("Углеводы (г)"))
            ));
        }

        Console.WriteLine($"Парсинг завершён. Всего строк данных: {results.Count}");
        return results;
    }

    /// <summary>
    /// Аналог parseFloat() из JS: некорректные/пустые значения превращаем в 0.
    /// </summary>
    private static double ParseDouble(string? value)
        => double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result)
            ? result
            : 0d;
}