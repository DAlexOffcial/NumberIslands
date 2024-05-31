using static System.Console;
using System.Collections;
using System.Collections.Generic;

namespace NumberIslands
{
    class Program
    {
        public static HashSet<Tuple<int, int>> visit = new HashSet<Tuple<int, int>>();
        public static int island = 0;
        public static void Main(string[] args)
        {
            char[][] grid = new char[][]
                {
                   new char[] {'1', '1', '1', '0', '1'},
                   new char[] {'1', '1', '0', '0', '0'},
                   new char[] {'1', '1', '0', '0', '0'},
                   new char[] {'0', '0', '0', '1', '1'}
                };

            int Islands = NumIslands(grid);
            WriteLine("Number of Islands: " + Islands);
        }

        public static int NumIslands(char[][] grid)
        {
            if (grid.Length == 0 || grid == null) return 0;

            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] == '1' && !visit.Contains(new Tuple<int, int>(r, c)))
                    {
                        bfs(r, c, grid);
                        island++;
                    }
                }
            }
            return island;
        }

        private static bool bfs(int r, int c, char[][] grid)
        {

            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            visit.Add(new Tuple<int, int>(r, c));
            q.Enqueue(new Tuple<int, int>(r, c));

            while (q.Count > 0)
            {
                var cell = q.Dequeue();
                int row = cell.Item1;
                int col = cell.Item2;
                var directions = new (int, int)[]
                {
                   (1, 0),
                   (-1, 0),
                   (0, 1),
                   (0, -1)
                };


                foreach (var (dr, dc) in directions)
                {
                    int newRow = row + dr;
                    int newCol = col + dc;
                    if (IsValid(newRow, newCol, grid) && grid[newRow][newCol] == '1' && !visit.Contains(new Tuple<int, int>(newRow, newCol)))
                    {
                        visit.Add(new Tuple<int, int>(newRow, newCol));
                        q.Enqueue(new Tuple<int, int>(newRow, newCol));
                    }
                }
            }
            return true;
        }

        private static bool IsValid(int r, int c, char[][] grid)
        {
            return r >= 0 && r < grid.Length && c >= 0 && c < grid[0].Length;
        }
    }
}