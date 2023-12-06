namespace DayFourConsoleApp
{
    public class Combination
    { 
        public int CardId { get; set; }

        public List<int> CardNumber { get; set; }
        public List<int> WinningNumbers { get; set; }

        public int MatchingNumbers => WinningNumbers.Count(x => CardNumber.Contains(x));

        public int CardWorth
        {
            get
            {
                if (MatchingNumbers == 0)
                {
                    return 0;
                }

                int value = 0;

                for (int i = 0; i < this.MatchingNumbers; i++)
                {
                    if (i == 0)
                    {
                        value = 1;
                    }
                    else
                    {

                        value = value * 2;
                    }
                }

                return value;
            }
        }
    }
    
}
