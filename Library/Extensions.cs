using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Extensions
    {
        public static string getFileName(in string? path)
        {
            if (path == null) return "unknown";
            return path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
        }

        public static bool createNetStream(Socket? socket, out NetworkStream? netStream)
        {
            try
            {
                if (socket != null)
                {
                    netStream = new NetworkStream(socket);
                    return true;
                }
            }
            catch { }

            netStream = null;
            return false;
        }

        public static bool createStreamWriter(NetworkStream? netStream, out StreamWriter? sWriter)
        {
            try
            {
                if (netStream != null)
                {
                    sWriter = new StreamWriter(netStream);
                    return true;
                }
            }
            catch { }

            sWriter = null;
            return false;
        }
    }
}
