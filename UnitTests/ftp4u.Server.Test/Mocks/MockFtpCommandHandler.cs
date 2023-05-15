using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.Test.Mocks
{
    public class MockFtpCommandHandler : IFtpCommandHandler
    {
        private readonly List<string> _commands = new List<string>();

        public List<string> GetCommands() => _commands.ToList();
        
        public void HandleCommand(string command, TcpClient clientSocket)
        {
            // Mock implementation of the FTP command handling logic for testing
            _commands.Add(command);
        }
    }
}