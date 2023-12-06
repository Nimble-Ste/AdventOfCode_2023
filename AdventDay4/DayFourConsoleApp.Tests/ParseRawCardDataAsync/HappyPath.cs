using NSubstitute;
using NUnit.Framework;

namespace DayFourConsoleApp.Tests.ParseRawCardDataAsync
{
    using FluentAssertions;

    [TestFixture]
    public class HappyPath : CardDataParserServiceFixture
    {
        protected override void TestSetup()
        {
            fileReader.ReadAsync("CardData.txt").Returns(new List<string>());
        }

        [Test]
        public async Task For_Card_One()
        {
            fileReader.ReadAsync("CardData.txt").Returns(new List<string> { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" });

            var result = await Fixture.ParseRawCardDataAsync();

            result.First().MatchingNumbers.Should().Be(4);
            result.First().CardWorth.Should().Be(8);
        }

        [Test]
        public async Task For_Card_Two()
        {
            fileReader.ReadAsync("CardData.txt").Returns(new List<string> { "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19" });

            var result = await Fixture.ParseRawCardDataAsync();

            result.First().MatchingNumbers.Should().Be(2);
            result.First().CardWorth.Should().Be(2);
        }

        [Test]
        public async Task For_Card_Three()
        {
            fileReader.ReadAsync("CardData.txt").Returns(new List<string> { "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1" });

            var result = await Fixture.ParseRawCardDataAsync();

            result.First().MatchingNumbers.Should().Be(2);
            result.First().CardWorth.Should().Be(2);
        }

        [Test]
        public async Task For_Card_Four()
        {
            fileReader.ReadAsync("CardData.txt").Returns(new List<string> { "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83" });

            var result = await Fixture.ParseRawCardDataAsync();

            result.First().MatchingNumbers.Should().Be(1);
            result.First().CardWorth.Should().Be(1);
        }
    }
}
