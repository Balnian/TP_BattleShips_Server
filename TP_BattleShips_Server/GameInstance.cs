using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP_BattleShips_Server
{
    class GameInstance
    {
        public bool IsWaitingForPlayer;

        TcpClient Joueur1;
        TcpClient Joueur2;
        Thread jeu;

        public GameInstance(TcpClient client)
        {
            Joueur1 = client;
            IsWaitingForPlayer = true;
        }

        public void AjoutJoueur(TcpClient client)
        {
            if(Joueur1.Connected)
            {
                Joueur2 = client;
                IsWaitingForPlayer = false;
                jeu = new Thread(StartGame);
            }
            else
            {
                Joueur1 = client;
            }
        }

        private void StartGame()
        {
            /*recevoir tableau*/

            /*partir boucle Joueur1*/
            jeu.Abort();

        }

    }
}
