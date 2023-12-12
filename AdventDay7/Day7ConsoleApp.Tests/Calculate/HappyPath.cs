namespace Day6ConsoleApp.Tests.Calculate
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class HappyPath : RaceTimeCalculatorServiceFixture
    {
        protected override void TestSetup()
        {

        }

        [Test]
        public async Task Calculate_Winning_Times()
        {

            var result = Fixture.CalculateCombinations(new List<(int raceTime, long distance)>
            {
                new (7, 9),
                new (15, 40),
                new (30, 200),
            });

            result.Should().BeEquivalentTo(new List<Tuple<long, long>>
            {
                new(9, 4),
                new(40, 8),
                new(200, 9)
            });
        }

    }
}
