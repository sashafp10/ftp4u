using System.Net.Sockets;

namespace ftp4u.Server.Test.Mocks
{
    public class MockTcpClient : TcpClient
    {
        public MemoryStream InputStream { get; } = new MemoryStream();
        public MemoryStream OutputStream { get; } = new MemoryStream();

        public new Stream GetStream()
        {
            return OutputStream;
        }

        public new void Close()
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