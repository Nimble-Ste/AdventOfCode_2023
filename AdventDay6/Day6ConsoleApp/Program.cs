namespace Day6ConsoleApp
{

    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<RaceTimeCalculatorService>()
                .BuildServiceProvider();

            var raceTimeCalculatorService = serviceProvider.GetService<RaceTimeCalculatorService>();

            var numberOfWaysToWin = await raceTimeCalculatorService!.CalculateCombinationsAsync(new Dictionary<int, long>()
            {
                {56 , 546 },
                {97, 1927 },
                {78, 1131 },
                {75, 1139 }
            });

            var winningWays = numberOfWaysToWin.Select(x => x.Item2);

            var partAResult = winningWays.Aggregate((a, x) => a * x);

            var partBNumberOfWays = await raceTimeCalculatorService!.CalculateCombinationsAsync(new Dictionary<int, long>()
            {
                {56977875 , 546192711311139 }
            });

            var winningWaysPartB = partBNumberOfWays.Select(x => x.Item2);

            var partBResult = winningWaysPartB.Aggregate((a, x) => a * x);
        }
    }
}
