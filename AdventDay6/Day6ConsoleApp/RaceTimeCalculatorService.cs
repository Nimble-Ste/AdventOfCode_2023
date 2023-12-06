namespace Day6ConsoleApp
{
    using System.Collections.Concurrent;

    public class RaceTimeCalculatorService
    {
        public async Task<List<Tuple<long, long>>> CalculateCombinationsAsync(Dictionary<int, long> timeDistance)
        {

            List<Tuple<long, long>> winningCombinations = new List<Tuple<long, long>>();

            foreach (var kvp in timeDistance)
            {
                var winningTimes = GetWinningTimes(kvp.Key, kvp.Value);

                winningCombinations.Add(new Tuple<long, long>(kvp.Value, winningTimes));
            }

            return winningCombinations;
        }


        public long GetWinningTimes(int raceTime, long raceDistance)
        {
            var winningTimes = 0;

            for (int time = 0; time < raceTime; time++)
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