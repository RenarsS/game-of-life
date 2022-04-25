using GameOfLife;
using GameOfLife.Conway;

int height = Panel.GetIntegerInput("Height:");
int width = Panel.GetIntegerInput("Width:");

var conwayBoard = new ConwayBoard(height, width);

var conwayGame = new Game(conwayBoard);

while(conwayGame.State != GameState.Exited)
{
    conwayGame.Play();
}

