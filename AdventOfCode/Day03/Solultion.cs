namespace AdventOfCode.Day03
{
    public class Solution
    {
        static Dictionary<char, int> chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            .Select((c, i) => new { Key = (char)c, Value = i + 1 })
            .ToDictionary(x => x.Key, x => x.Value);

        public static int Part1(string path, string filename)
        {
            List<Tuple<char[], char[]>> rucksacks = new List<Tuple<char[], char[]>>();
            var input = ReadInput(path, filename);
            foreach (var rucksack in input)
            {
                int lengthCompartment = rucksack.Length / 2;
                var compartment1 = rucksack.Substring(0, lengthCompartment).ToCharArray();
                var compartment2 = rucksack.Substring(lengthCompartment, lengthCompartment).ToCharArray();
                var tupla = Tuple.Create(compartment1, compartment2);
                rucksacks.Add(tupla);
            }

            int priority = 0;
            foreach (var rucksack in rucksacks)
            {
                char commonItem = rucksack.Item1.Intersect(rucksack.Item2).FirstOrDefault();
                priority += chars[commonItem];
            }

            return priority;
        }

        public static int Part2(string path, string filename)
        {
            List<string[]> groups = ReadInput(path, filename).Chunk(3).ToList();
            int priority = 0;
            foreach (var group in groups)
            {
                char commonItem = group[0].Intersect(group[1]).Intersect(group[2]).FirstOrDefault();
                priority += chars[commonItem];
            }

            return priority;
        }
        
        static List<string> ReadInput(string path, string filename)
        {
            return File.ReadAllText(Path.Combine(path, filename)).Split("\r\n").ToList();
        }
    }
}
