// using System.Net.Sockets;
// using ftp4u.Core.Abstraction;
// using Moq;

// namespace ftp4u.Server.Test.Mocks
// {
//     public class MockTcpClient : ITcpClientWrapper
//     {
//         private Mock<Socket> _socketMock;

//         public MemoryStream InputStream { get; } = new MemoryStream();
//         public MemoryStream OutputStream { get; } = new MemoryStream();
//         public Socket Client { get => _socketMock.Object; set { } }

//         public MockTcpClient()
//         {
//             _socketMock = new Mock<Socket>();
//             _socketMock.Setup(s => s.Receive(It.IsAny<byte[]>())).Returns(42);
//             _socketMock.SetupGet(s => s.Connected).Returns(true);
//         }

//         public Stream? GetStream()
//         {
//             return OutputStream;
//         }

//         public void Close()
//         {
//             InputStream.Close();
//             OutputStream.Close();
//         }

//         public string ReadFromInputStream()
//         {
//             InputStream.Position = 0;
//             using var reader = new StreamReader(InputStream);
//             return reader.ReadToEnd();
//         }

//         public void WriteToOutputStream(string data)
//         {
//             var writer = new StreamWriter(OutputStream);
//             writer.Write(data);
//             writer.Flush();
//         }
//     }
// }