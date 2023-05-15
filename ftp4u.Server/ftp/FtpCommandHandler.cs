using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.ftp
{
internal class FtpCommandHandler : IFtpCommandHandler
{
    public void HandleCommand(string command, TcpClient clientSocket)
    {
        // Handle FTP commands here
        // Implement the necessary logic based on the received command
    }
}
}