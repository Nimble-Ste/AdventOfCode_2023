namespace Day6ConsoleApp
{

    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<RaceTimeCalculatorService>()
                .BuildServiceProvider();

            var raceTimeCalculatorService = serviceProvider.GetService<RaceTimeCalculatorService>();

            //var numberOfWaysToWin = raceTimeCalculatorService!.CalculateCombinations(
            //    new List<(int raceTime, long distance)>
            //    {
            //        new(56, 546),
            //        new(97, 1937),
            //        new(78, 1131),
            //        new(75, 1139)
            //    });

            //var winningWays = numberOfWaysToWin.Select(x => x.Item2);

            //var partAResult = winningWays.Aggregate((a, x) => a * x);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            var partBNumberOfWays = await raceTimeCalculatorService!.CalculateCombinations(new List<(int raceTime, long distance)>()
                {
                    new(56977875, 546192711311139)
                });

            var winningWaysPartB = partBNumberOfWays.Select(x => x.timeTaken);

            var partBResult = winningWaysPartB.Aggregate((a, x) => a * x);

            Console.WriteLine($"Took {watch.ElapsedMilliseconds}");
        }
    }
}
