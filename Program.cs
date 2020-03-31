using System;
namespace SocketCom
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null)
            {
                Console.WriteLine("null");
            }
            if(args[0] == "server")
            {
                TCPServer server = new TCPServer("127.0.0.1", 8080, true);
                server.Listen();
            } else if(args[0] == "client")
            {
                TCPClient cliente = new TCPClient();
                cliente.Connect("127.0.0.1", 8080);
                while (true){
                    cliente.client.GetStream();
                    Console.WriteLine(cliente.ReadMessage());
                    cliente.SendMessage(Console.ReadLine());
                };
            }
        }
    }
}
