using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Library
{
    public class SocketClient : Socket
    {
        public SocketClient(IPEndPoint ipEndP) 
            : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) 
        {
            this.Connect(ipEndP);
        }

        public void netStreamSend(in string fname)
        {
            using (NetworkStream netStream = new NetworkStream(this))
            {
                Console.WriteLine($"client address {netStream.Socket.LocalEndPoint}");
                Console.WriteLine($"server address {netStream.Socket.RemoteEndPoint}");

                ReadOnlySpan<byte> buffer = Encoding.UTF8.GetBytes(fname);
                netStream.Write(buffer);

                Console.WriteLine($"Client send {fname}");
            }
        }

        public void netStreamWriter(in string fname)
        {
            using (NetworkStream netStream = new NetworkStream(this))
            {
                Console.WriteLine($"client address {netStream.Socket.LocalEndPoint}");
                Console.WriteLine($"server address {netStream.Socket.RemoteEndPoint}");

                using (StreamWriter swriter = new StreamWriter(netStream))
                {
                    swriter.Write(fname);
                    swriter.Flush();

                    Console.WriteLine($"Client send {fname}");
                }                
            }
        }

        public void fromFsToNs(in string fname)
        {
            using (FileStream fs = File.OpenRead(fname))
            {
                using (NetworkStream ns = new NetworkStream(this))
                {
                    fs.CopyTo(ns);
                    fs.Flush();
                    Console.WriteLine($"Client send {fname}");
                }
            }               
        }

    }
}