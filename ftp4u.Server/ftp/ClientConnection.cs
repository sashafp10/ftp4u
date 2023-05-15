using System.Net.Sockets;
using System.Text;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.ftp
{
    public class ClientConnection : IClientConnection
    {
        private readonly IFtpCommandHandler commandHandler;
        private readonly TcpClient clientSocket;
        private NetworkStream networkStream;
        private StreamReader reader;
        private StreamWriter writer;

        public ClientConnection(TcpClient clientSocket, IFtpCommandHandler commandHandler)
        {
            this.clientSocket = clientSocket;
            this.commandHandler = commandHandler;
            networkStream = clientSocket.GetStream();
            reader = new StreamReader(networkStream, Encoding.ASCII);
            writer = new StreamWriter(networkStream, Encoding.ASCII) { AutoFlush = true };
        }

        public void Start()
        {
            SendResponse("220 Service ready.");

            string clientMessage;
            while ((clientMessage = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Received from {clientSocket.Client.RemoteEndPoint}: {clientMessage}");

                commandHandler.HandleCommand(clientMessage, clientSocket);
            }

            Cleanup();
        }

        private void SendResponse(string message)
        {
            writer.WriteLine(message);
            Console.WriteLine($"Sent to {clientSocket.Client.RemoteEndPoint}: {message}");
        }

        private void Cleanup()
        {
            reader.Close();
            writer.Close();
            networkStream.Close();
            clientSocket.Close();
        }
    }

}