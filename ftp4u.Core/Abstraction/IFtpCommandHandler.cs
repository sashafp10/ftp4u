using System.Net.Sockets;

namespace ftp4u.Core.Abstraction
{
    public interface IFTPCommandHandler
    {
        void HandleCommand(string command, TcpClient clientSocket);
    }
}