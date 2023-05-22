using System.Net.Sockets;
using ftp4u.Core.Abstraction;

namespace ftp4u.Server.Test.Mocks
{
    public class MockTcpClient : ITcpClientWrapper
    {
        public MemoryStream InputStream { get; } = new MemoryStream();
        public MemoryStream OutputStream { get; } = new MemoryStream();
        public Socket Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Stream? GetStream()
        {
            return OutputStream;
        }

        public void Close()
        {
            InputStream.Close();
            OutputStream.Close();
        }

        public string ReadFromInputStream()
        {
            InputStream.Position = 0;
            using var reader = new StreamReader(InputStream);
            return reader.ReadToEnd();
        }

        public void WriteToOutputStream(string data)
        {
            var writer = new StreamWriter(OutputStream);
            writer.Write(data);
            writer.Flush();
        }
    }
}