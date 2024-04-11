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

        public void netStreamWriter(in string fname)
        {
            using (NetworkStream netStream = new NetworkStream(this))
            {
                using (StreamWriter swriter = new StreamWriter(netStream))
                {
                    swriter.Write(fname);
                    swriter.Flush();
                }                
            }
        }
    }
}