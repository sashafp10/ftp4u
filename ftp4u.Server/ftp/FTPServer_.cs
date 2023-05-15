// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace ftp4u.Server.ftp
// {
//     public class FTPServer1
//     {
//         private TcpClient clientSocket;
//         private NetworkStream networkStream;
//         private StreamReader reader;
//         private StreamWriter writer;

//         public ClientConnection(TcpClient clientSocket)
//         {
//             this.clientSocket = clientSocket;
//             networkStream = clientSocket.GetStream();
//             reader = new StreamReader(networkStream, Encoding.ASCII);
//             writer = new StreamWriter(networkStream, Encoding.ASCII) { AutoFlush = true };
//         }

//         public void Start()
//         {
//             SendResponse("220 Service ready.");

//             string clientMessage;
//             while ((clientMessage = reader.ReadLine()) != null)
//             {
//                 Console.WriteLine($"Received from {clientSocket.Client.RemoteEndPoint}: {clientMessage}");

//                 var command = clientMessage.ToUpper();
//                 if (command.StartsWith("LIST"))
//                     SendFileList();
//                 else if (command.StartsWith("RETR"))
//                     SendFile(clientMessage.Substring(5).Trim());
//                 else if (command.StartsWith("STOR"))
//                     ReceiveFile(clientMessage.Substring(5).Trim());
//                 else if (command.StartsWith("QUIT"))
//                 {
//                     SendResponse("221 Service closing control connection.");
//                     break;
//                 }
//                 else
//                     SendResponse("502 Command not implemented.");
//             }

//             Cleanup();
//         }

//         private void SendResponse(string message)
//         {
//             writer.WriteLine(message);
//             Console.WriteLine($"Sent to {clientSocket.Client.RemoteEndPoint}: {message}");
//         }

//         private void SendFileList()
//         {
//             SendResponse("150 File status okay; about to open data connection.");

//             var files = Directory.GetFiles(Directory.GetCurrentDirectory());
//             foreach (var file in files)
//             {
//                 var fileInfo = new FileInfo(file);
//                 var filePermissions = File.GetAttributes(fileInfo.FullName).ToString();
//                 var fileSize = fileInfo.Length;
//                 var fileDate = fileInfo.LastWriteTime.ToString("MMM dd HH:mm");

//                 var fileLine = $"{filePermissions} 1 owner group {fileSize} {fileDate} {fileInfo.Name}";
//                 writer.WriteLine(fileLine);
//                 Console.WriteLine($"Sent to {clientSocket.Client.RemoteEndPoint}: {fileLine}");
//             }

//             SendResponse("226 Closing data connection.");
//         }

//         private void SendFile(string fileName)
//         {
//             var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

//             if (!File.Exists(filePath))
//             {
//                 SendResponse("550 File not found.");
//                 return;
//             }

//             SendResponse("150 File status okay; about to open data connection.");

//             using (var fileStream = File.OpenRead(filePath))
//             {
//                 fileStream.CopyTo(networkStream);
//             }

//             SendResponse("226 Closing data connection.");
//         }

//         private void ReceiveFile(string fileName)
//         {
//             var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

//             SendResponse("150 File status okay; about to open data connection.");

//             using (var fileStream = File.Create(filePath))
//             {
//                 networkStream.CopyTo(fileStream);
//             }

//             SendResponse("226 Closing data connection.");
//         }

//         private void Cleanup()
//         {
//             reader.Close();
//             writer.Close();
//             networkStream.Close();
//             clientSocket.Close();
//         }
//     }
// }