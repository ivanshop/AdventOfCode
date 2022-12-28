using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problemDay = "04";

            // test.txt -> To test data from example
            // input.txt -> To solve the real challenge
            string input = "input.txt";

            string path = Path.Combine(Environment.CurrentDirectory, "Day" + problemDay);

            Console.WriteLine($"Part 1: {Day04.Solution.Part1(path, input)}");
            Console.WriteLine($"Part 2: {Day04.Solution.Part2(path, input)}");
        }
    }
}