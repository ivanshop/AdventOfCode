namespace AdventOfCode.Day02
{
    public class Solution
    {
        public static int Part1(string path, string filename)
        {
            List<string> game = ReadInput(path, filename);
            int totalScore = 0;
            foreach (var round in game)
            {
                totalScore += round switch
                {
                    "A X" => 1 + 3,
                    "B X" => 1 + 0,
                    "C X" => 1 + 6,
                    "A Y" => 2 + 6,
                    "B Y" => 2 + 3,
                    "C Y" => 2 + 0,
                    "A Z" => 3 + 0,
                    "B Z" => 3 + 6,
                    "C Z" => 3 + 3,
                    _ => 0
                };
            }

            return totalScore;
        }

        public static int Part2(string path, string filename)
        {
            List<string> game = ReadInput(path, filename);
            int totalScore = 0;
            foreach (var round in game)
            {
                totalScore += round switch
                {
                    "A X" => 3 + 0,
                    "B X" => 1 + 0,
                    "C X" => 2 + 0,
                    "A Y" => 1 + 3,
                    "B Y" => 2 + 3,
                    "C Y" => 3 + 3,
                    "A Z" => 2 + 6,
                    "B Z" => 3 + 6,
                    "C Z" => 1 + 6,
                    _ => 0
                };
            }

            return totalScore;
        }
        static List<string> ReadInput(string path, string filename)
        {
            return File.ReadAllText(Path.Combine(path, filename)).Split("\r\n").ToList();
        }
    }
}
