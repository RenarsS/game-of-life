using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class BoardGame : Game
    {
        /// <summary>
        /// Board of the game
        /// </summary>
        private IBoard _gameBoard { get; set; }

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public BoardGame(IBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public override void Play()
        {
            while (State == GameState.Playing)
            {
                Action keyAction = () =>
                {
                    switch (Panel.GetKeyInput())
                    {
                        case ConsoleKey.Spacebar:
                            Pause();
                            break;

                        case ConsoleKey.Enter:
                            Start();
                            break;

                        case ConsoleKey.Escape:
                            Stop();
                            break;
                    }
                };

                Task keyTask = new Task(keyAction);

                keyTask.Start();

                _gameBoard.Flow();

                if (State == GameState.Paused)
                {
                    Panel.DisplayMessage("Game was paused. \n\nTo resume press enter. \nTo exit press escape.");
                }
            }
        }
    }
}
