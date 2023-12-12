namespace Day7ConsoleApp
{
    public class Hand
    {
        public string[] Cards = new string[5];

        public int[] CardAsInts = new int[5];

        private int MapCard(string card)
        {
            if(int.TryParse(card, out int cardAsInt))
            {
                return cardAsInt;
            }

            return 0;
        }
    }
}
