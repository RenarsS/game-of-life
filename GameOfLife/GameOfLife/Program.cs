using GameOfLife;

Console.WriteLine("Hello! This is Conway's Game of Life.");

Console.WriteLine();

string height;
string width;

do
{
    Console.WriteLine("Enter height, please: ");
    height = Console.ReadLine();
}
while(!Validation.ValidateNaturalNum(height));

do
{
    Console.WriteLine("Enter width, please:");
    width = Console.ReadLine();
} 
while(!Validation.ValidateNaturalNum(width));

Console.Clear();

var board = new Board(int.Parse(height), int.Parse(width));

board.Play();
