using System;
using System.Linq;

namespace advent_of_code_2021
{
    internal class Day11
    {
        private long flashes;
        internal void Part1()
        {
            InitializeGrid();
            flashes = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        IncreaseCell(j, k);
                    }
                }
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (grid[j, k] >= 10)
                            grid[j, k] = 0;
                    }

                }
            }
            System.Console.WriteLine(flashes);
        }

        internal void Part2()
        {
            InitializeGrid();
            int i = 0;
            while (true)
            {
                flashes = 0;
                i++;
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        IncreaseCell(j, k);
                    }
                }
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (grid[j, k] >= 10)
                            grid[j, k] = 0;
                    }
                }
                if (flashes == 100)
                {
                    System.Console.WriteLine(i);
                    break;
                }
            }
        }
        private void IncreaseCell(int i, int j)
        {
            if (i < 0 || i >= grid.GetLength(0) ||
                j < 0 || j >= grid.GetLength(1))
                return;
            grid[i, j]++;
            if (grid[i, j] == 10)
            {
                flashes++;
                IncreaseCell(i - 1, j - 1);
                IncreaseCell(i, j - 1);
                IncreaseCell(i + 1, j - 1);
                IncreaseCell(i - 1, j);
                IncreaseCell(i + 1, j);
                IncreaseCell(i - 1, j + 1);
                IncreaseCell(i, j + 1);
                IncreaseCell(i + 1, j + 1);
            }
        }

        private void InitializeGrid()
        {
            var lines = data.Split("\r\n").ToArray();
            grid = new int[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    grid[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
        }
        private int[,] grid;
        private static string data = @"1172728874
6751454281
2612343533
1884877511
7574346247
2117413745
7766736517
4331783444
4841215828
6857766273";
    }
}