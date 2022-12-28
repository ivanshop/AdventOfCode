namespace AdventOfCode.Day04
{
    public class Solution
    {
        public static int Part1(string path, string filename)
        {
            var tuplas = ReadInput(path, filename);

            int containedCount = 0;

            foreach (var item in tuplas)
            {
                containedCount += AnyIsFullyContained(item) ? 1 : 0;
            }
            return containedCount;
        }

        public static int Part2(string path, string filename)
        {
            var tuplas = ReadInput(path, filename);

            int containedCount = 0;

            foreach (var item in tuplas)
            {
                containedCount += AnyIsPartiallyContained(item) ? 1 : 0;
            }
            return containedCount;
        }
        
        private static List<Tuple<Tuple<int, int>, Tuple<int, int>>> ReadInput(string path, string filename)
        {
            List<Tuple<Tuple<int, int>, Tuple<int, int>>> assigmentPairs = new();
            var input = File.ReadAllText(Path.Combine(path, filename)).Split("\r\n").ToList();
            foreach (var intervals in input)
            {
                Tuple<string?, string?> intervalPairs = Tuple.Create
                    (
                    intervals.Split(',').ToList().FirstOrDefault(),
                    intervals.Split(',').ToList().LastOrDefault()
                    );
                assigmentPairs.Add(CreateInterval(intervalPairs));
            }
            return assigmentPairs;
        }

        private static Tuple<Tuple<int, int>, Tuple<int, int>> CreateInterval(Tuple<string, string> intervals)
        {
            List<int> firstInterval = intervals.Item1.Split('-').Select(n => int.Parse(n)).ToList();
            var intervalOne = Tuple.Create(firstInterval.FirstOrDefault(), firstInterval.LastOrDefault());
            List<int> secondInterval = intervals.Item2.Split('-').Select(n => int.Parse(n)).ToList();
            var intervalTwo = Tuple.Create(secondInterval.FirstOrDefault(), secondInterval.LastOrDefault());
            return Tuple.Create(intervalOne, intervalTwo);
        }

        private static bool AnyIsFullyContained(Tuple<Tuple<int, int>, Tuple<int, int>> intervals)
        {
            if (intervals.Item1.Item1 <= intervals.Item2.Item1 && intervals.Item1.Item2 >= intervals.Item2.Item2)
            {
                return true;
            }
            if (intervals.Item2.Item1 <= intervals.Item1.Item1 && intervals.Item2.Item2 >= intervals.Item1.Item2)
            {
                return true;
            }
            return false;
        }

        private static bool AnyIsPartiallyContained(Tuple<Tuple<int, int>, Tuple<int, int>> intervals)
        {
            if (intervals.Item1.Item1 <= intervals.Item2.Item1 && intervals.Item2.Item1 <= intervals.Item1.Item2)
            {
                return true;
            }
            if (intervals.Item2.Item1 <= intervals.Item1.Item1 && intervals.Item1.Item1 <= intervals.Item2.Item2)
            {
                return true;
            }
            return false;
        }
    }
}
