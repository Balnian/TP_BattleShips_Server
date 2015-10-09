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
        public List< GameInstance> GameInstances = new List<GameInstance>();
        public void ListenServeur()
        {
            //TcpListener serverSocket = new TcpListener(8888);
            TcpListener serverSocket = new TcpListener(IPAddress.Any,1521);

            TcpClient clientSocket = default(TcpClient);
            

            serverSocket.Start();
            while(true)
            {
                Console.WriteLine("Début");
                clientSocket = serverSocket.AcceptTcpClient();

                Console.WriteLine(" >> " + "Nouvelle connection de " + clientSocket.Client.AddressFamily.ToString() + " started!");
                if (CheckExistingInstances(clientSocket))
                {
                    GameInstances.Add(new GameInstance(clientSocket));
                }
                
            }
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
    }
}
