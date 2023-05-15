using ftp4u.Server.ftp;
using ftp4u.Server.Test.Mocks;

namespace ftp4u.Server.Test;

public class UnitTest1
{
 [Fact]
        public void FtpServer_Start_Should_StartServerSocket()
        {
            // Arrange
            var commandHandler = new MockFtpCommandHandler();
            var clientSocket = new MockTcpClient();
            var clientConnection = new ClientConnection(clientSocket, commandHandler);
            var ftpServer = new FtpServer(clientConnection);

            // Act
            ftpServer.Start();

            // Assert
            // Add assertions to verify that the server socket is started successfully
        }

        [Fact]
        public void ClientConnection_Start_Should_SendServiceReadyResponse()
        {
            // Arrange
            var clientSocket = new MockTcpClient();
            var commandHandler = new MockFtpCommandHandler();
            var clientConnection = new ClientConnection(clientSocket, commandHandler);

            // Act
            clientConnection.Start();

            // Assert
            // Add assertions to verify that the "220 Service ready" response is sent
        }

        [Fact]
        public void ClientConnection_Start_Should_HandleCommand()
        {
            // Arrange
            var clientSocket = new MockTcpClient();
            var commandHandler = new MockFtpCommandHandler();
            var clientConnection = new ClientConnection(clientSocket, commandHandler);
            var command = "TEST COMMAND";

            // Act
            clientConnection.Start();

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