using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_BattleShips_Server
{
    [Serializable]
    class BattleShipPacket
    {
        enum GameState
        {
            Start,
            YourTurn,
            Update,
            Victory,
            Defeat
           

        }

        enum GridState
        {
            None,
            Hit,
            Flop
        }

        GameState State;

        GridState[,] YourGrid;

        GridState[,] OpponentGrid;


    }
}
