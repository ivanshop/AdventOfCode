namespace AdventOfCode.Day05
{
    public class Solution
    {
        public static string Part1(string path, string filename)
        {
            List<int[]> movements = new();
            Dictionary<int, Stack<char>> stacks = new();
            ReadInput(path, filename, ref movements, ref stacks);
            string letters = string.Empty;

            foreach (var item in movements)
            {
                for (int i = 0; i < item[0]; i++)
                {
                    var k = stacks[item[1]].Pop();
                    stacks[item[2]].Push(k);
                }
            }

            for (int i = 1; i <= stacks.Count; i++)
            {
                letters += stacks[i].Pop();
            }
           
            return letters;
        }

        public static string Part2(string path, string filename)
        {
            List<int[]> movements = new();
            Dictionary<int, Stack<char>> stacks = new();
            ReadInput(path, filename, ref movements, ref stacks);
            string letters = string.Empty;

            foreach (var item in movements)
            {
                var temp = new Stack<char>();
                for (int i = 0; i < item[0]; i++)
                {
                    var k = stacks[item[1]].Pop();
                    temp.Push(k);
                }
                for (int i = 0; i < item[0]; i++)
                {
                    var k = temp.Pop();
                    stacks[item[2]].Push(k);
                }
            }

            for (int i = 1; i <= stacks.Count; i++)
            {
                letters += stacks[i].Pop();
            }

            return letters;
        }
        
        private static void ReadInput(string path, string filename, ref List<int[]> movements, ref Dictionary<int, Stack<char>> stacks)
        {
            var input = File.ReadAllText(Path.Combine(path, filename)).Split("\r\n\r\n").ToList();
            var allStacks = input.FirstOrDefault().Split("\r\n").ToList();
            var allMovements = input.LastOrDefault().Split("\r\n").ToList();
            allStacks.Reverse();
            
            for (int i = 1; i <= allStacks[0].Split("   ").Count(); i++)
            {
                stacks.Add(i, new Stack<char>());
            }
            allStacks.RemoveAt(0);
            foreach (var line in allStacks)
            {
                var elements = line.Replace("    ", "#").Replace(" ", "").Replace("[", "").Replace("]", "").ToList();
                for (int j = 0; j < elements.Count(); j++)
                {
                    if (elements[j] != '#')
                    {
                        stacks[j+1].Push(elements[j]);
                    }
                }
            }
            foreach (var movement in allMovements)
            {
                var line = movement.Split(' ');
                movements.Add(new int[] { int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[5]) });
            }
        }
    }
}
