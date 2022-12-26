using System;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problemDay = "02";

            // test.txt -> To test data from example
            // input.txt -> To solve the real challenge
            string input = "input.txt";

            string path = Path.Combine(Environment.CurrentDirectory, "Day" + problemDay);

            Console.WriteLine($"Part 1: {Day02.Solution.Part1(path, input)}");
            Console.WriteLine($"Part 2: {Day02.Solution.Part2(path, input)}");
        }
    }
}