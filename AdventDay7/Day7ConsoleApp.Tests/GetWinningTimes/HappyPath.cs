namespace Day6ConsoleApp.Tests.GetWinningTimes
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

            var result = Fixture.GetWinningTimes(7, 9);

            result.Should().Be(4);
        }

    }
}
