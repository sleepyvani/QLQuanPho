using System;
using System.IO;
using System.Text;

namespace PhoManager.Utilities
{
    /// <summary>
    /// Lớp ghi log đơn giản ghi lại thông tin và lỗi vào file trong thư mục Logs.
    /// Việc sử dụng lớp này giúp dễ dàng theo dõi hành vi ứng dụng và hỗ trợ gỡ lỗi sau này.
    /// </summary>
    public static class Logger
    {
        private static readonly object _lockObj = new object();

        private static string LogDirectory
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string logDir = Path.Combine(baseDir, "Logs");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                return logDir;
            }
        }

        /// <summary>
        /// Ghi một dòng thông tin vào file log với thời gian hiện tại.
        /// </summary>
        /// <param name="message">Thông điệp cần ghi.</param>
        public static void Info(string message)
        {
            Write("INFO", message);
        }

        /// <summary>
        /// Ghi một lỗi vào file log.
        /// </summary>
        /// <param name="message">Thông điệp lỗi.</param>
        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        /// <summary>
        /// Ghi thông điệp vào file log kèm theo loại và thời gian.
        /// </summary>
        /// <param name="level">Mức độ log (INFO/ERROR).</param>
        /// <param name="message">Nội dung log.</param>
        private static void Write(string level, string message)
        {
            string logFile = Path.Combine(LogDirectory, DateTime.Now.ToString("yyyyMMdd") + ".log");
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            try
            {
                lock (_lockObj)
                {
                    File.AppendAllText(logFile, line + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                // Nếu việc ghi log thất bại, không ném lỗi để tránh ảnh hưởng đến luồng chính.
            }
        }
    }
}