using System.Net;
using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.ftp
{
    public class FtpServer
    {
        private readonly IClientConnection _clientConnection;

        public FtpServer(IClientConnection clientConnection)
        {
            _clientConnection = clientConnection;
        }

        public void Start()
        {
            const int port = 21;
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var serverSocket = new TcpListener(ipAddress, port);

            serverSocket.Start();
            Console.WriteLine($"FTP Server started on {ipAddress}:{port}");

            while (true)
            {
                var clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine($"New client connected: {clientSocket.Client.RemoteEndPoint}");

                // var clientConnection = ActivatorUtilities.CreateInstance<ClientConnection>(clientSocket, commandHandler);
                _clientConnection.Start();
            }
        }
    }
}