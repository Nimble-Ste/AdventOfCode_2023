namespace DayOneConsoleApp;

public interface ICalibrationValueService
{
    Task<List<int>> GetValuesForEachRowAsync();
}