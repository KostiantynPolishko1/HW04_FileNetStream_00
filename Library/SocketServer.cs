using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    public class SocketServer : Socket
    {
        public SocketServer(IPEndPoint ipEndP)
            : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            this.Bind(ipEndP);
            this.Listen();
        }

        public void fillClients(in int SIZE, List<Socket?> clients)
        {
            int i = 0;

            while (i < SIZE)
            {
                if (getClient(out Socket? client))
                {
                    clients.Add(client);                    
                    i++;
                }
            }
        }

        private bool getClient(out Socket? socket)
        {
            try
            {
                socket = this.Accept();
                return true;
            }
            catch
            {
                socket = null;
                return false;
            }
        }

        public void arrByteReceiveToFile(Socket client, in string fname)
        {           
            List<byte> responce = new List<byte>();
            byte[] buffer = new byte[1024];
            int size = default;
            int i = 0;
            do
            {
                size = client.Receive(buffer);
                responce.AddRange(buffer.Take(size));
                Console.WriteLine($"{i++}");
            }
            while (size != 0);

            Console.WriteLine("Server receive...");

            File.WriteAllBytes(fname, responce.ToArray());
            responce.Clear();

            Console.WriteLine("Server wrote to File...");
        }

        public void netStreamReceiveToStr(Socket client)
        {
            using (NetworkStream netStream = new NetworkStream(client))
            {
                StringBuilder responce = new StringBuilder();
                byte[] buffer = new byte[4];
                int length = 0;
                do
                {
                    length = netStream.Read(buffer);
                    responce.Append(Encoding.UTF8.GetString(buffer, 0, length));

                } while (length != 0);

                Console.WriteLine(responce);
                responce.Clear();
            }
        }

        public void netStreamReader(Socket client)
        {
            using (NetworkStream netStream = new NetworkStream(client))
            {
                using (StreamReader sreader = new StreamReader(netStream))
                {
                    string? responce = sreader.ReadLine();
                    Console.WriteLine(responce??= "no responce");
                }
            }
        }

        public void fromNsToFs(Socket client, in string fname)
        {
            using(NetworkStream ns = new NetworkStream(client))
            {
                using (FileStream fs = File.Open(fname, FileMode.OpenOrCreate))
                {
                    ns.CopyTo(fs);
                    ns.Flush();
                    Console.WriteLine($"Server receive {fname}");
                }
            }
        }
    }
}
