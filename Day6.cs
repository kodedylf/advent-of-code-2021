using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2021
{
    internal class Day6
    {
        internal void Part1()
        {
            var school = _data.Split(",").Select(d => int.Parse(d)).ToList();
            for (int i = 0; i < 80; i++)
            {
                var newFish = school.Where(d => d == 0).Select(d => 8).ToList();
                school = school.Select(d => d == 0 ? 6 : d - 1).ToList();
                school.AddRange(newFish);
            }
            System.Console.WriteLine(school.Count());
        }

        internal void Part2()
        {
            var school = new long[9];
            _data.Split(",").ToList().ForEach(d => school[int.Parse(d)]++);
            for (int i = 0; i < 256; i++)
            {
                var newFish = school[0];
                for (int j = 1; j < 9; j++) {
                    school[j-1] = school[j];
                }
                school[6] += newFish;
                school[8] = newFish;
            }
            System.Console.WriteLine(school.Sum());
        }


        private static readonly string _data = @"1,1,1,2,1,1,2,1,1,1,5,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,4,1,1,1,1,3,1,1,3,1,1,1,4,1,5,1,3,1,1,1,1,1,5,1,1,1,1,1,5,5,2,5,1,1,2,1,1,1,1,3,4,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,5,4,1,1,1,1,1,5,1,2,4,1,1,1,1,1,3,3,2,1,1,4,1,1,5,5,1,1,1,1,1,2,5,1,4,1,1,1,1,1,1,2,1,1,5,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,3,1,1,3,1,3,1,4,1,5,4,1,1,2,1,1,5,1,1,1,1,1,5,1,1,1,1,1,1,1,1,1,4,1,1,4,1,1,1,1,1,1,1,5,4,1,2,1,1,1,1,1,1,1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,4,1,1,1,2,1,4,1,1,1,1,1,1,1,1,1,4,2,1,2,1,1,4,1,1,1,1,1,1,3,1,1,1,1,1,1,1,1,3,2,1,4,1,5,1,1,1,4,5,1,1,1,1,1,1,5,1,1,5,1,2,1,1,2,4,1,1,2,1,5,5,3";
    }
}