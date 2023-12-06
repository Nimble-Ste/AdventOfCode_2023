namespace DayTwoConsoleApp
{
    using AdventOfCode.Shared;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<FileReader>()
                .BuildServiceProvider();
        }
    }
}
