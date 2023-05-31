namespace ftp4u.Core.Abstraction
{
    public interface IClientConnection
    {
        Task StartAsync(System.Net.Sockets.TcpClient clientSocket);
    }
}