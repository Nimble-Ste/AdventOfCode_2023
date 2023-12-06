namespace DayFourConsoleApp
{
    using AdventOfCode.Shared;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<FileReader>()
                .AddSingleton<CardDataParser>()
                .BuildServiceProvider();


            var calibrationValueService = serviceProvider.GetService<CardDataParser>();

            var values = await calibrationValueService!.ParseRawCardDataAsync();

            var part1Result = values.Sum(x => x.CardWorth);


        }
    }
}
