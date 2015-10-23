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
                jeu.Start();
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
            NetworkStream StreamJ1 = Joueur1.GetStream();
            NetworkStream StreamJ2 = Joueur2.GetStream();
            LogConsole.Log("envoie de Allo");
            try
            {
                ConnUtility.SerializeAndSend(StreamJ1, "alloJ1");
                ConnUtility.SerializeAndSend(StreamJ2, "alloJ2");
            }
            catch (Exception e)
            {

                LogConsole.Log(e.Message);
            }
            
            
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
