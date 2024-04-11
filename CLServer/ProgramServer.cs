using Library;
using System;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using System.Xml.Schema;


namespace CLServer
{
    internal class ProgramServer
    {
        static void Main(string[] args)
        {
            using (SocketServer server = new SocketServer(new ConnectIPEndP().getIpeP()))
            {
                Console.WriteLine($"Server address {server.LocalEndPoint}");

                Socket client = server.Accept();
                Console.WriteLine($"Client address {client.RemoteEndPoint}");

                using (NetworkStream netStream = new NetworkStream(client))
                {
                    using (StreamReader sreader = new StreamReader(netStream))
                    {
                        while (true)
                        {
                            string? msg = sreader.ReadLine();
                            Console.Clear();

                            if (msg?.ToLower() == "exit") { break; }
                            Console.WriteLine($"FromClient msg: {msg}");

                            using (FileStream fs = File.Open(msg, FileMode.OpenOrCreate))
                            {
                               netStream?.CopyToAsync(fs);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Server close...");
        }
    }
}