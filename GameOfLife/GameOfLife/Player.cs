using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Class responsible for UI managment and a medium between the game and the user.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Game initiated by player.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Parameterless constructor that initiates and starts game.
        /// </summary>
        public Player()
        {
            Game = new Game();

            Game.Prepare();

            Game.StartGame();


        }
        public void Run()
        {
            StopGame();

            Game.PlayOnDisplay();


        }

        public void DisplayMainMenu()
        {

        }

        private void ExitGame()
        {

        }

        private void StopGame()
        {
            Action stop = () =>
            {
                Thread.Sleep(5000);
                Game.StopGame();
            };

            Task stopTask = new Task(stop);

            stopTask.Start();
;        }

        private void ContinueGame()
        {

        }

        private void SaveAndExit()
        {

        }


    }
}
