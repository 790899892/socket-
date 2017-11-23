using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace Server
{
    class ServerGame
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ip, 52814);
            serverSocket.Bind(ipe);
            serverSocket.Listen(0);
            Socket clientSocket = serverSocket.Accept();

            string str = "你已成功连接服务器";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            clientSocket.Send(data);

            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);
            string msg= System.Text.Encoding.UTF8.GetString(dataBuffer,0,count );
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}
