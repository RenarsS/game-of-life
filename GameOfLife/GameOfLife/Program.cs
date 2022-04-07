using GameOfLife;

Console.WriteLine("Hello! This is Conway's Game of Life.");

Console.WriteLine();

Console.WriteLine("Enter height, please: ");
string height = Console.ReadLine();

Console.WriteLine("Enter width, please:");
string width = Console.ReadLine();

Console.Clear();

var board = new Board(int.Parse(height), int.Parse(width));

board.Play();
