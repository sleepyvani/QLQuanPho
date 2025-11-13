using System;
using System.Security.Cryptography;
using System.Text;

namespace PhoManager.Utilities
{
    /// <summary>
    /// Cung cấp các hàm tiện ích cho việc băm và xác thực mật khẩu.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Tạo chuỗi hash từ mật khẩu thuần, kèm theo salt ngẫu nhiên. Chuỗi kết quả có dạng "salt:hash".
        /// </summary>
        /// <param name="password">Mật khẩu thuần (plain text) cần băm.</param>
        /// <returns>Chuỗi đã băm với salt.</returns>
        public static string HashPassword(string password)
        {
            if (password == null) return null;
            // Tạo một salt ngẫu nhiên dựa trên GUID để tăng độ bảo mật.
            string salt = Guid.NewGuid().ToString("N");
            string hash = ComputeSha256Hash(salt + password);
            return $"{salt}:{hash}";
        }

        /// <summary>
        /// Kiểm tra xem mật khẩu người dùng nhập vào có khớp với mật khẩu đã băm lưu trữ hay không.
        /// </summary>
        /// <param name="password">Mật khẩu thuần do người dùng nhập.</param>
        /// <param name="storedHash">Chuỗi đã băm lưu trữ trong cơ sở dữ liệu (dạng "salt:hash").</param>
        /// <returns>True nếu mật khẩu khớp, ngược lại false.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash)) return false;
            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;
            var salt = parts[0];
            var hash = parts[1];
            var computed = ComputeSha256Hash(salt + password);
            return string.Equals(computed, hash, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Xác định chuỗi mật khẩu đã băm hay chưa dựa vào định dạng "salt:hash".
        /// </summary>
        /// <param name="value">Chuỗi cần kiểm tra.</param>
        /// <returns>True nếu chuỗi có chứa dấu hai chấm, ngược lại false.</returns>
        public static bool IsHashed(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Contains(":");
        }

        /// <summary>
        /// Tính toán giá trị băm SHA-256 cho một chuỗi bất kỳ.
        /// </summary>
        /// <param name="input">Chuỗi đầu vào.</param>
        /// <returns>Chuỗi mã hex đại diện cho giá trị băm.</returns>
        private static string ComputeSha256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}