using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace AgentSecure.Helpers
{
  public static class EncryptionHelper
  {
    // Exactly 32 bytes = AES-256
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF"); // ✅ 32 ASCII chars
    // Exactly 16 bytes = AES block size
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("ABCDEF1234567890"); // ✅ 16 ASCII chars

    public static string Encrypt(string plainText)
    {
      using var aes = Aes.Create();
      aes.Key = Key;
      aes.IV = IV;

      using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
      using var ms = new MemoryStream();
      using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
      using (var sw = new StreamWriter(cs))
      {
        sw.Write(plainText);
      }

      return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
      using var aes = Aes.Create();
      aes.Key = Key;
      aes.IV = IV;

      using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
      var buffer = Convert.FromBase64String(cipherText);
      using var ms = new MemoryStream(buffer);
      using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
      using var sr = new StreamReader(cs);
      return sr.ReadToEnd();
    }
  }
}
