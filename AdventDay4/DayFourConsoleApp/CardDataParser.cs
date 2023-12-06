namespace DayFourConsoleApp
{
    using AdventOfCode.Shared;

    public class CardDataParser(FileReader fileReader)
    {
        public async Task<List<Combination>> ParseRawCardDataAsync()
        {
            var rawData = await fileReader.ReadAsync("CardData.txt");

            List<Combination> cards = new List<Combination>();

            int cardId = 1;
            foreach (var raw in rawData)
            {
                string[] parts = raw.Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    Combination card = new Combination
                    {
                        CardNumber = ParseNumberList(parts[1].Split('|')[0]),
                        WinningNumbers = ParseNumberList(parts[1].Split('|')[1]),
                        CardId = cardId
                    };

                    cardId++;

                    cards.Add(card);
                }
            }

            return cards;
        }

        private List<int> ParseNumberList(string numbers)
        {
            return numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
