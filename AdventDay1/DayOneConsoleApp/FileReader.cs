namespace DayOneConsoleApp
{
    public class FileReader
    {
        public virtual async Task<List<string>> ReadAsync()
        {
            return (await File.ReadAllLinesAsync("CalibrationValues.txt")).ToList();
        }
    }
}
