// See https://aka.ms/new-console-template for more information
using GameOfLife;

Console.WriteLine("Hello! This is Conway's Game of Life.");
Console.WriteLine();

Console.WriteLine("Enter height: ");
string height = Console.ReadLine();

Console.WriteLine("Enter width please");
string width = Console.ReadLine();

Console.Clear();

var board = new Board(Int32.Parse(height), Int32.Parse(width));
board.DisplayBoard();
