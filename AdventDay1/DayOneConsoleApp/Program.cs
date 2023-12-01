namespace DayOneConsoleApp
{
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<FileReader>()
                .AddSingleton<ICalibrationValueService, CalibrationValueService>()
                .BuildServiceProvider();

            var calibrationValueService = serviceProvider.GetService<ICalibrationValueService>();

            var values = await calibrationValueService!.GetValuesForEachRowAsync();

            var result = values.Sum();
        }
    }
}
