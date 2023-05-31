using System.Net;
using System.Net.Sockets;

public interface ITcpListenerWrapper
{
    bool Active { get; }
    bool ExclusiveAddressUse { get; set; }
    Socket Server { get; }
    EndPoint LocalEndpoint { get; }
    void Start();
    void Stop();
    TcpClient AcceptTcpClient();
    IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state);
    TcpClient EndAcceptTcpClient(IAsyncResult asyncResult);
}