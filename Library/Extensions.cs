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

        public static bool createStreamWriter(Socket? socket, out StreamWriter? sWriter)
        {
            try
            {
                if (socket != null)
                {
                    NetworkStream netStream = new NetworkStream(socket);
                    sWriter = new StreamWriter(netStream);
                    return true;
                }
                sWriter = null;
                return false;
            }
            catch 
            {
                sWriter = null;
                return false; 
            }
        }
    }
}
