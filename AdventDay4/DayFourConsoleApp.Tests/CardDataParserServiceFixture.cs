using NUnit.Framework;

namespace DayFourConsoleApp.Tests
{
    using AdventOfCode.Shared;
    using NSubstitute;

    [TestFixture]
    public abstract class CardDataParserServiceFixture
    {
        [SetUp]
        public void Setup()
        {
            fileReader = Substitute.For<FileReader>();

            TestSetup();

            Fixture = new CardDataParser(fileReader);
        }

        protected CardDataParser Fixture;

        protected FileReader fileReader;

        protected abstract void TestSetup();

    }
}
