namespace ftp4u.Core.Abstraction
{
    public interface IFtpCommandHandler
    {
        void HandleCommand(string command, ITcpClientWrapper clientSocket);
    }
}