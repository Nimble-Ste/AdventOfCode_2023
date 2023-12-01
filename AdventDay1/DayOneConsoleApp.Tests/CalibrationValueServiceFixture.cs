namespace DayOneConsoleApp.Tests
{
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public abstract class CalibrationValueServiceFixture
    {
        [SetUp]
        public void Setup()
        {
            fileReader = Substitute.For<FileReader>();
            
            TestSetup();

            Fixture = new CalibrationValueService(fileReader);
        }

        protected CalibrationValueService Fixture;


        protected FileReader fileReader;

        protected abstract void TestSetup();
    }
}