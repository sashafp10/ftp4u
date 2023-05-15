// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using ftp4u.Core.Abstraction;
using ftp4u.Server.ftp;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

        // Setup dependency injection container (e.g., using a framework like Microsoft.Extensions.DependencyInjection)

//         var serviceProvider = new ServiceCollection()
//             .AddSingleton<IFtpCommandHandler, FtpCommandHandler>()
//             .AddSingleton<IFtpCommandHandler, FtpCommandHandler>()
//             .BuildServiceProvider();

//         var ftpServer = serviceProvider.GetRequiredService<FtpServer>();
//         ftpServer.Start();

// const int port = 21;
//         var ipAddress = IPAddress.Parse("127.0.0.1");
//         var serverSocket = new TcpListener(ipAddress, port);

//         serverSocket.Start();
//         Console.WriteLine($"FTP Server started on {ipAddress}:{port}");

//         while (true)
//         {
//             var clientSocket = serverSocket.AcceptTcpClient();
//             Console.WriteLine($"New client connected: {clientSocket.Client.RemoteEndPoint}");

//             var clientConnection = new ClientConnection(clientSocket);
//             clientConnection.Start();
//         }

        var serviceProvider = new ServiceCollection()
            .AddTransient<IFtpCommandHandler, FtpCommandHandler>()
            .AddScoped<IClientConnection, ClientConnection>()
            // .AddSingleton<ILogger, ConsoleLogger>()
            .BuildServiceProvider();

        var ftpServer = serviceProvider.GetRequiredService<FtpServer>();
        ftpServer.Start();