using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TP_BattleShips_Server
{
    class MatchMakingServeur
    {
        public static List< GameInstance> GameInstances = new List<GameInstance>();

        public bool Stop{get;set;}
        public void ListenServeur()
        {
            Stop = false;
            //TcpListener serverSocket = new TcpListener(8888);
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8080);
            try
            {

                serverSocket.Server.ReceiveTimeout = 500;
                serverSocket.Start();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
            

            //TcpClient clientSocket = default(TcpClient);


            Console.WriteLine("Début");
            while (!Stop)
            {
                
                if (serverSocket.Pending())
                {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();

                    Console.WriteLine(" >> " + "Nouvelle connection de " + IPAddress.Parse(((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString()) + " started!");
                    if (CheckExistingInstances(clientSocket))
                    {
                        GameInstances.Add(new GameInstance(clientSocket));
                    }
                }
                cleanInstances();
                    
                

                
                
            }
            Console.WriteLine("Fin");
            serverSocket.Stop();
        }

        private bool CheckExistingInstances(TcpClient client)
        {
            foreach (GameInstance game in GameInstances)
            {
                if(game.IsWaitingForPlayer)
                {
                    game.AjoutJoueur(client);
                    return false;

                }
            }
            return true;
        }

        private void cleanInstances()
        {
            List<GameInstance> Rip = new List<GameInstance>();
            foreach (GameInstance instance in GameInstances)
            {
                if (!ConnUtility.TestClient(instance.Joueur2) && !ConnUtility.TestClient(instance.Joueur1))
                    Rip.Add(instance);

                /*if ((instance.Joueur1 == null || !instance.Joueur1.Connected) && (instance.Joueur2 == null || !instance.Joueur2.Connected))
                {
                    
                        GameInstances.Remove(instance);
                }
                else if(instance.Joueur1 != null && instance.Joueur2 != null)
                    if (!testconn(instance.Joueur2) && !testconn(instance.Joueur1))
                        GameInstances.Remove(instance);*/

            }

            foreach (GameInstance instance in Rip)
            {
                GameInstances.Remove(instance);
            }
        }

        

        private void deleteInstance(GameInstance instance)
        {
            instance.StopGameInstance();
            GameInstances.Remove(instance);
        }
    }
}
