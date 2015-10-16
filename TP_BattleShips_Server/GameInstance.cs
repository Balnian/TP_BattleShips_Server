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

        public TcpClient Joueur1{get;private set;}
        public TcpClient Joueur2{get;private set;}
        Thread jeu;

        public GameInstance(TcpClient client)
        {
            Joueur1 = client;
            IsWaitingForPlayer = true;
        }

        public void AjoutJoueur(TcpClient client)
        {
            if(ConnUtility.TestClient(Joueur1))
            {

                Joueur2 = client;
                IsWaitingForPlayer = false;
                jeu = new Thread(StartGame);
            }
            else
            {
                LogConsole.LogWithTime("La connection à " + ConnUtility.GetIP(Joueur1) + " à été terminer");
                Joueur1 = client;
            }
        }

        public void StopGameInstance()
        {
            try
            {
                jeu.Abort();
            }
            catch (Exception)
            {

                
            }
        }

        private void StartGame()
        {
            /*recevoir tableau*/

            /*partir boucle Joueur1*/
            //jeu.Abort();
            while (true)
            {
                Thread.Sleep(500);

            }

            MatchMakingServeur.GameInstances.Remove(this);

        }

    }
}
