using System;

namespace AdventOfCode.Day06
{
    public class Solution
    {
        public static int Part1(string path, string filename)
        {
            List<char> letters = ReadInput(path, filename);
            if (letters.Count < 4)
            {
                return 0;
            }
            for (int i = 0; i < letters.Count - 4; i++)
            {
                if (VerifyDistincts(letters.GetRange(i, 4)))
                {
                    return i + 4;
                }
            }
            return 0;
        }

        public static int Part2(string path, string filename)
        {
            List<char> letters = ReadInput(path, filename);
            if (letters.Count < 14)
            {
                return 0;
            }
            for (int i = 0; i < letters.Count - 14; i++)
            {
                if (VerifyDistincts(letters.GetRange(i, 14)))
                {
                    return i + 14;
                }
            }
            return 0;
        }
        
        private static List<char> ReadInput(string path, string filename)
        {
            return File.ReadAllText(Path.Combine(path, filename)).ToList();            
        }

        private static bool VerifyDistincts(List<char> range)
        {
            for (int i = 0; i < range.Count; i++)
            {
                for (int j = i + 1; j < range.Count; j++)
                {
                    if (range[i] == range[j])
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
