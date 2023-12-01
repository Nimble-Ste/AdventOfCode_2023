namespace DayOneConsoleApp
{
    public class CalibrationValueService(FileReader fileReader) : ICalibrationValueService
    {
        public async Task<List<int>> GetValuesForEachRowAsync()
        {
            var rawValues = await fileReader.ReadAsync();

            List<int> results = new List<int>();

            foreach (var rawValue in rawValues)
            {
                var resultString = ParseRow(rawValue);

                string combined = resultString.Item1.ToString() + resultString.Item2.ToString();

                results.Add(int.Parse(combined));
            }

            return results;
        }

        private (int, int) ParseRow(string row)
        {
 
            string[] numbers = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "zero", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

            int maxPosition = int.MaxValue;
            string currentStartNumber = "";

            
            int minPosition = int.MinValue;
            string currentEndNumber = "";

            foreach (var number in numbers)
            {
                var firstIndex = row.IndexOf(number);
                if (firstIndex != -1)
                {

                    if (firstIndex < maxPosition)
                    {
                        maxPosition = firstIndex;
                        currentStartNumber = number;
                    }
                }

                var lastIndex = row.LastIndexOf(number);

                if (lastIndex != -1)
                {
                    if (lastIndex > minPosition)
                    {
                        minPosition = lastIndex;
                        currentEndNumber = number;
                    }
                }
            }

            return (currentStartNumber.AsNumber(), currentEndNumber.AsNumber());
        }
    }

    public static class Util
    {
        public static int AsNumber(this string number)
        {
            if (int.TryParse(number, out int parsed))
            {
                return parsed;
            }

            return number switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                "zero" => 0,
                _ => 0
            };
        }
    }
}
