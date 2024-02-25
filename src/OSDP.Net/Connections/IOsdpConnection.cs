using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSDP.Net.Connections
{
    /// <summary>
    /// Defines a connection for communicating with PDs
    /// </summary>
    public interface IOsdpConnection : IDisposable
    {
        /// <summary>Speed of the connection</summary>
        int BaudRate { get; }

        /// <summary>
        /// Is the connection open and ready to communicate
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Timeout value waiting for a reply
        /// </summary>
        TimeSpan ReplyTimeout { get; set; }

        /// <summary>
        /// Write to connection
        /// </summary>
        /// <param name="buffer">Array of bytes to write</param>
        Task WriteAsync(byte[] buffer);

        /// <summary>
        /// Read from connection
        /// </summary>
        /// <param name="buffer">Array of bytes to read</param>
        /// <param name="token">Cancellation token to end reading of bytes</param>
        /// <returns>Number of actual bytes read</returns>
        Task<int> ReadAsync(byte[] buffer, CancellationToken token);

        /// <summary>
        /// Close the connection for communications
        /// </summary>
        void Close();

        /// <summary>
        /// Open the connection for communications
        /// </summary>
        void Open();
    }

    public interface IOsdpServer : IDisposable
    {
        void Start(Func<IOsdpConnection, Task> newConnectionHandler);

        void Stop();

        bool IsRunning { get; }
    }
}
