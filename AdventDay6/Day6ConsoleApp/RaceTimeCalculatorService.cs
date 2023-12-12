using System.Collections.Concurrent;

namespace Day6ConsoleApp
{
    public class RaceTimeCalculatorService
    {
        public async Task<List<(long distance, long timeTaken)>> CalculateCombinations(List<(int raceTime, long distance)> timeDistances)
        {

            List<(long distance, long timeTaken)> winningCombinations = new List<(long distance, long timeTaken)>();

            foreach (var timeDistance in timeDistances)
            {
                var winningTimes = await GetWinningTimes(timeDistance.raceTime, timeDistance.distance);

                winningCombinations.Add((timeDistance.distance, winningTimes));
            }

            return winningCombinations;
        }


        public async Task<long> GetWinningTimes(int raceTime, long raceDistance)
        {
            var winningTimes = 0;

            for (long time = 0; time < raceTime; time++)
            {
                var distance = (raceTime - time) * time;
                if (distance > raceDistance)
                {
                    winningTimes++;
                }
            }

            return winningTimes;
        }
    }
}