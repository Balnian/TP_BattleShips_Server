using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TP_BattleShips_Server
{
    class ConnUtility
    {
        public static bool TestClient(TcpClient conn)
        {
            if (conn == null)
                return false;
            try
            {
                return !(conn.Client.Poll(50, SelectMode.SelectRead) && conn.Client.Available == 0);
            }
            catch (SocketException) { return false; }


        }
    }
}
