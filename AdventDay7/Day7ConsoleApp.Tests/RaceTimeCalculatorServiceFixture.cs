namespace Day6ConsoleApp.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public abstract class RaceTimeCalculatorServiceFixture
    {
        [SetUp]
        public void Setup()
        {

            TestSetup();

            Fixture = new RaceTimeCalculatorService();
        }

        protected RaceTimeCalculatorService Fixture;


        protected abstract void TestSetup();

    }
}
