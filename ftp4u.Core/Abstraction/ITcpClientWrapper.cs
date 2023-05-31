using System.Net.Sockets;

namespace ftp4u.Core.Abstraction
{
    public interface ITcpClientWrapper
    {
        Socket Client { get; }

        void Close();
        Stream? GetStream();
    }
}