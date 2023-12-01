namespace DayOneConsoleApp.Tests.GetValuesForEachRowAsync
{
    using DayOneConsoleApp.Tests;
    using FluentAssertions;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class HappyPath : CalibrationValueServiceFixture
    {

        protected override void TestSetup()
        {
            fileReader.ReadAsync().Returns(new List<string>());
        }


        [Test]
        public async Task Should_Put_Numbers_Side_By_Side()
        {
            fileReader.ReadAsync().Returns(new List<string> { "1a2" });

            var result = await Fixture.GetValuesForEachRowAsync();

            result.Should().Equal(12);
        }

        [Test]
        public async Task If_Only_1_Number_Result_Should_Be_Added()
        {
            fileReader.ReadAsync().Returns(new List<string>() { "hhkjsdh5jkhsjkd" });

            var result = await Fixture.GetValuesForEachRowAsync();

            result.Should().Equal(55);
        }

        [Test]
        public async Task Should_only_use_first_and_last()
        {
            fileReader.ReadAsync().Returns(new List<string> { "363" });

            var result = await Fixture.GetValuesForEachRowAsync();

            result.Should().Equal(33);
        }

        [Test]
        public async Task Should_Be_Correct()
        {
            fileReader.ReadAsync().Returns(new List<string> { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet", "1abc" });

            var results = await Fixture.GetValuesForEachRowAsync();

            results.Should().BeEquivalentTo(new List<int>
            {
                12,
                38,
                15,
                77,
                11
            });

            results.Sum().Should().Be(153);
        }

        [Test]
        public async Task Should_Include_Words()
        {
            fileReader.ReadAsync().Returns(new List<string> { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" });

            var results = await Fixture.GetValuesForEachRowAsync();

            results.Should().BeEquivalentTo(new List<int>
            {
                29,
                83,
                13,
                24,
                42,
                14,
                76
            });

            results.Sum().Should().Be(281);
        }

        [Test]
        public async Task Additional()
        {
            fileReader.ReadAsync().Returns(new List<string> { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen", "eighthree", "blah7foo" });

            var results = await Fixture.GetValuesForEachRowAsync();

            results.Should().BeEquivalentTo(new List<int>
            {
                29,
                83,
                13,
                24,
                42,
                14,
                76,
                83,
                77
            });
        }
    }
}