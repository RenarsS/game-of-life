using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Specifies state of the game at any given moment. 
    /// Used to communicate with player.
    /// </summary>
    public enum GameState
    {
        StandBy,
        Playing,
        Paused,
        Saving,
        Exited
    }
}
