using System.Net.Sockets;
using System.Text;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.ftp
{
    public class ClientConnection : IClientConnection
    {
        private readonly IFtpCommandHandler _commandHandler;
        private readonly ITcpClientWrapper _clientSocket;
        private Stream? _networkStream;
        private StreamReader? _reader;
        private StreamWriter? _writer;

        public ClientConnection(ITcpClientWrapper clientSocket, IFtpCommandHandler commandHandler)
        {
            _clientSocket = clientSocket;
            _commandHandler = commandHandler;
            _networkStream = clientSocket.GetStream();
            TryOpenStream();
        }

        public void Start()
        {
            SendResponse("220 Service ready.");

            if (_reader != null) {
                string? clientMessage;
                while ((clientMessage = _reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Received from {_clientSocket.Client.RemoteEndPoint}: {clientMessage}");

                    _commandHandler.HandleCommand(clientMessage, _clientSocket);
                }
            }

            Cleanup();
        }

        private bool TryOpenStream() {
            if (_networkStream != null) {
                _reader = new StreamReader(_networkStream, Encoding.ASCII);
                _writer = new StreamWriter(_networkStream, Encoding.ASCII) { AutoFlush = true };

                return true;
            }

            return false;
        }

        private void SendResponse(string message)
        {
            if (_writer == null) {
                var opened = TryOpenStream();
                if (!opened) {
                    string msg = "Can not open network stream for read/write";
                    Console.WriteLine(msg);
                    throw new IOException(msg);
                }
            }
            _writer?.WriteLine(message);
            Console.WriteLine($"Sent to {_clientSocket.Client.RemoteEndPoint}: {message}");
        }

        private void Cleanup()
        {
            _reader?.Close();
            _writer?.Close();
            _networkStream?.Close();
            _clientSocket.Close();
        }
    }

}