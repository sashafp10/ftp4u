using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Core
{

    public class TcpClientWrapper : ITcpClientWrapper
    {
        private readonly TcpClient _tcpClient;

        public TcpClientWrapper(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        public void Close()
        {
            _tcpClient.Close();
        }

        public TcpClient Client => _tcpClient;

        Socket ITcpClientWrapper.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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