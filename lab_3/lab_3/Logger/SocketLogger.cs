using System;
using System.Text;

namespace ConsoleApp.Logger
{
    public class SocketLogger : ILogger
    {
        private ClientSocket clientSocket;

        public SocketLogger(string host, int port)
        {
            this.clientSocket = new ClientSocket(host, port);
        }

        ~SocketLogger()
        {
            this.Dispose(false);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.clientSocket.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        public void Log(params string[] messages)
        {
            DateTime dateTime = DateTime.Now;
            String currentLog = dateTime.ToString() + " ";
            foreach (var message in messages)
            {
                currentLog += message + " ";

                using (clientSocket)
                {
                    byte[] requestBytes = Encoding.UTF8.GetBytes(currentLog);
                    clientSocket.Send(requestBytes);

                    byte[] responseBuffer = new byte[1024];
                    int responseSize = clientSocket.Receive(responseBuffer);

                    Console.WriteLine("asd");

                    String responseText = Encoding.UTF8.GetString(responseBuffer, 0, responseSize);

                    Console.WriteLine(responseText);
                    Console.WriteLine(dateTime + " " + currentLog + " socket");
                    clientSocket.Close();
                }
            }
        }
    }
}