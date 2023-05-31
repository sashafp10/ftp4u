using System.Net;
using System.Net.Sockets;

namespace ftp4u.Core.Network
{
    public class TcpListenerWrapper : TcpListener, ITcpListenerWrapper
    {
        [Obsolete]
        public TcpListenerWrapper(int port) : base(port)
        {
        }

        public TcpListenerWrapper(IPAddress addr, int port) : base(addr, port)
        {
        }

        bool ITcpListenerWrapper.Active => Active;
    }
}