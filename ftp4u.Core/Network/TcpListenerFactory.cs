using System.Net;
using ftp4u.Core.Abstraction;

namespace ftp4u.Core.Network
{
    public class TcpListenerFactory : ITcpListenerFactory
    {

        public TcpListenerFactory()
        {
        }

        public ITcpListenerWrapper CreateTcpListenerWrapper() => new TcpListenerWrapper(IPAddress.Loopback, 8021);
    }
}