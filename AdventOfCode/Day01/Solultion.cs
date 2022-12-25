namespace AdventOfCode.Day01
{
    public class Solution
    {
        public static int Part1(string path, string filename)
        {
            List<int> totalCaloriesByElf = ReadInput(path, filename);
            return totalCaloriesByElf.OrderByDescending(tc => tc).Take(1).Sum();
        }

        public static int Part2(string path, string filename)
        {
            List<int> totalCaloriesByElf = ReadInput(path, filename);
            return totalCaloriesByElf.OrderByDescending(tc => tc).Take(3).Sum();
        }
        static List<int> ReadInput(string path, string filename)
        {
            string[] input = File.ReadAllText(Path.Combine(path, filename)).Split("\r\n\r\n");
            List<int> elfs = new();
            foreach (var calories in input)
            {
                elfs.Add(calories.Split("\r\n").Select(x => int.Parse(x)).ToArray().Sum());
            }
            return elfs;
        }
    }
}
