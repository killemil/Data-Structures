namespace _07DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[,] labyrinth = ReadLab(n);
            bool[,] visited = new bool[labyrinth.GetLength(0), labyrinth.GetLength(1)];

            int row = 0;
            int col = 0;

            bool isfound = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (labyrinth[i, j] == "*")
                    {
                        row = i;
                        col = j;
                        isfound = true;
                        break;
                    }
                }

                if (isfound)
                {
                    break;
                }
            }

            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(row, col, 0, true));

            while (queue.Count != 0)
            {
                Cell currentCell = queue.Dequeue();
                visited[currentCell.Row, currentCell.Col] = true;

                row = currentCell.Row;
                col = currentCell.Col;
                if (labyrinth[row, col] != "*")
                {
                    labyrinth[row, col] = currentCell.Moves.ToString();
                }

                //up
                if (row - 1 >= 0 && labyrinth[row - 1, col] != "x" && !visited[row - 1, col])
                {
                    queue.Enqueue(new Cell(row - 1, col, currentCell.Moves + 1, false));
                }
                //right
                if (col + 1 < labyrinth.GetLength(1) && labyrinth[row, col + 1] != "x" && !visited[row, col + 1])
                {
                    queue.Enqueue(new Cell(row, col + 1, currentCell.Moves + 1, false));
                }
                //down
                if (row + 1 < labyrinth.GetLength(0) && labyrinth[row + 1, col] != "x" && !visited[row + 1, col])
                {
                    queue.Enqueue(new Cell(row + 1, col, currentCell.Moves + 1, false));
                }
                //left
                if (col - 1 >= 0 && labyrinth[row, col - 1] != "x" && !visited[row, col - 1])
                {
                    queue.Enqueue(new Cell(row, col - 1, currentCell.Moves + 1, false));
                }
            }
            PrintLabyrintg(labyrinth);
        }

        private static void PrintLabyrintg(string[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j].Equals("*"))
                    {
                        Console.Write("*");
                    }
                    else if (labyrinth[i, j].Equals("0"))
                    {
                        Console.Write("u");
                    }
                    else
                    {
                        Console.Write(labyrinth[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static string[,] ReadLab(int n)
        {
            string[,] lab = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] line = Console.ReadLine().ToArray();
                for (int j = 0; j < n; j++)
                {
                    lab[i, j] = line[j].ToString();
                }
            }
            return lab;
        }
    }
    class Cell
    {
        public Cell(int row, int col, int moves, bool isVisited)
        {
            this.Row = row;
            this.Col = col;
            this.Moves = moves;
            this.IsVisited = IsVisited;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Moves { get; set; }

        public bool IsVisited { get; set; }
    }
}
