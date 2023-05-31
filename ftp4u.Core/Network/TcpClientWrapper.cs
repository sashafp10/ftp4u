using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Core.Network
{

    public class TcpClientWrapper : ITcpClientWrapper
    {
        private readonly TcpClient _tcpClient;

        public TcpClientWrapper()
        {
            _tcpClient = new TcpClient();
        }

        public void Close()
        {
            _tcpClient.Close();
        }

        Socket ITcpClientWrapper.Client { get => _tcpClient.Client; }

        public void Dispose()
        {
            _tcpClient.Dispose();
        }

        Stream? ITcpClientWrapper.GetStream()
        {
            return _tcpClient.GetStream();
        }
    }

}