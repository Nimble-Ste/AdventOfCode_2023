namespace AdventOfCode.Shared
{
    public class FileReader
    {
        public virtual async Task<List<string>> ReadAsync(string fileName)
        {
            return (await File.ReadAllLinesAsync(fileName)).ToList();
        }
    }
}
