// using System.Net;
// using System.Net.Sockets;

// namespace ftp4u.Server.Test.Mocks
// {
//     public class MockTcpListenerWrapper : ITcpListenerWrapper
//     {
//         public bool Active => throw new NotImplementedException();

//         public bool ExclusiveAddressUse { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//         public Socket Server => throw new NotImplementedException();

//         public EndPoint LocalEndpoint => throw new NotImplementedException();

//         public TcpClient AcceptTcpClient()
//         {
//             throw new NotImplementedException();
//         }

//         public IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state)
//         {
//             throw new NotImplementedException();
//         }

//         public TcpClient EndAcceptTcpClient(IAsyncResult asyncResult)
//         {
//             throw new NotImplementedException();
//         }

//         public void Start()
//         {
//             throw new NotImplementedException();
//         }

//         public void Stop()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }