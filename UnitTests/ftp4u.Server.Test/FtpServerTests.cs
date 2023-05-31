using ftp4u.Core.Abstraction;
using ftp4u.Server.ftp;
using ftp4u.Server.Test.Mocks;
using Moq;

namespace ftp4u.Server.Test;

public class UnitTest1
{
 [Fact]
        public void FtpServer_Start_Should_StartServerSocket()
        {
            // Arrange
            var commandHandler = new MockFtpCommandHandler();
//            var clientSocket = new MockTcpClient();
            var clientConnection = new Mock<IClientConnection>(); //new ClientConnection(clientSocket, commandHandler);
            var tcpClientFactoryMock = new Mock<ITcpListenerFactory>();
            // tcpClientFactoryMock.Setup(n => n.CreateTcpListenerWrapper()).Returns((new Mock<ITcpListenerWrapper>()).Object);
            var ftpServer = new FtpServer(clientConnection.Object, tcpClientFactoryMock.Object);

            // Act
            // ftpServer.Start();

            // Assert
            // Add assertions to verify that the server socket is started successfully
        }

        [Fact]
        public void ClientConnection_Start_Should_SendServiceReadyResponse()
        {
            // Arrange
            MemoryStream ms = new MemoryStream();
            var clientSocket = new Mock<ITcpClientWrapper>();
            clientSocket.Setup(n => n.GetStream()).Returns(ms);
            var commandHandler = new MockFtpCommandHandler();
            var clientConnection = new ClientConnection(clientSocket.Object, commandHandler);

            // Act

            // Assert
            // Add assertions to verify that the "220 Service ready" response is sent
        }

        [Fact]
        public void ClientConnection_Start_Should_HandleCommand()
        {
            // Arrange
            MemoryStream ms = new MemoryStream();
            var clientSocket = new Mock<ITcpClientWrapper>();
            clientSocket.Setup(n => n.GetStream()).Returns(ms);
            var commandHandler = new MockFtpCommandHandler();
            var clientConnection = new ClientConnection(clientSocket.Object, commandHandler);
            var command = "TEST COMMAND";

            // Act

            // Assert
            // Add assertions to verify that the command handler is called with the correct command
        }

        // [Fact]
        // public void ClientConnection_Cleanup_Should_CloseSocketsAndStreams()
        // {
        //     // Arrange
        //     var clientSocket = new MockTcpClient();
        //     var commandHandler = new MockFtpCommandHandler();
        //     var clientConnection = new ClientConnection(clientSocket, commandHandler);

        //     // Act
        //     clientConnection.Cleanup();

        //     // Assert
        //     // Add assertions to verify that the client socket and streams are closed
        // }
}