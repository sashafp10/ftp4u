using System.Net;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.ftp
{
    public class FtpServer
    {
        private readonly IClientConnection _clientConnection;
        private readonly ITcpListenerFactory _tcpListenerFactory;
        private bool _canRun = false;

        public FtpServer(IClientConnection clientConnection, ITcpListenerFactory tcpListenerFactory)
        {
            _tcpListenerFactory = tcpListenerFactory;
            _clientConnection = clientConnection;
        }

        public void Start()
        {
            const int port = 8021;
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var tcpListenerWrapper = _tcpListenerFactory.CreateTcpListenerWrapper();

            tcpListenerWrapper.Start();
            Console.WriteLine($"FTP Server started on {ipAddress}:{port}");

            _canRun = true;
            while (_canRun)
            {
                var clientSocket = tcpListenerWrapper.AcceptTcpClient();
                Console.WriteLine($"New client connected: {clientSocket.Client.RemoteEndPoint}");

                // var clientConnection = ActivatorUtilities.CreateInstance<ClientConnection>(clientSocket, commandHandler);
                Task.Run(() => _ = _clientConnection.StartAsync(clientSocket));
                
            }
        }

        public void Stop()
        {
            _canRun = false;
        }
    }
}