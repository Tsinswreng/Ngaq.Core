namespace Ngaq.Core.Domains.Encryption;

using System;
using System.Security.Cryptography;
using System.Text;

public static class AesGcmHelper {
	private const int KeySize = 32;   // AES-256
	private const int NonceSize = 12; // 96-bit nonce
	private const int TagSize = 16;   // 128-bit tag

	/// <summary>
	/// 生成 256-bit 随机密钥
	/// </summary>
	public static byte[] GenerateKey() => RandomNumberGenerator.GetBytes(KeySize);

	/// <summary>
	/// 加密字符串 → Base64( nonce + tag + ciphertext )
	/// </summary>
	public static string EncryptToBase64(string plaintext, byte[] key) {
		if (plaintext == null) throw new ArgumentNullException(nameof(plaintext));
		if (key == null || key.Length != KeySize)
			throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));

		byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
		var (cipher, nonce, tag) = Encrypt(plainBytes, key);

		// 合并：nonce (12) + tag (16) + ciphertext
		var bundle = new byte[NonceSize + TagSize + cipher.Length];
		Buffer.BlockCopy(nonce, 0, bundle, 0, NonceSize);
		Buffer.BlockCopy(tag, 0, bundle, NonceSize, TagSize);
		Buffer.BlockCopy(cipher, 0, bundle, NonceSize + TagSize, cipher.Length);

		// 清零敏感明文
		CryptographicOperations.ZeroMemory(plainBytes);

		return Convert.ToBase64String(bundle);
	}

	/// <summary>
	/// 解密 Base64( nonce + tag + ciphertext ) → 字符串
	/// </summary>
	public static string DecryptFromBase64(string bundleB64, byte[] key) {
		if (string.IsNullOrEmpty(bundleB64)) throw new ArgumentNullException(nameof(bundleB64));
		if (key == null || key.Length != KeySize)
			throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));

		byte[] bundle = Convert.FromBase64String(bundleB64);
		if (bundle.Length < NonceSize + TagSize)
			throw new ArgumentException("Invalid cipher bundle.");

		byte[] nonce = new byte[NonceSize];
		byte[] tag = new byte[TagSize];
		byte[] cipher = new byte[bundle.Length - NonceSize - TagSize];

		Buffer.BlockCopy(bundle, 0, nonce, 0, NonceSize);
		Buffer.BlockCopy(bundle, NonceSize, tag, 0, TagSize);
		Buffer.BlockCopy(bundle, NonceSize + TagSize, cipher, 0, cipher.Length);

		byte[] plainBytes = Decrypt(cipher, nonce, tag, key);
		string result = Encoding.UTF8.GetString(plainBytes);
		CryptographicOperations.ZeroMemory(plainBytes); // 清零
		return result;
	}

	/// <summary>
	/// 底层加密：返回 (ciphertext, nonce, tag)
	/// </summary>
	private static (byte[] cipher, byte[] nonce, byte[] tag) Encrypt(byte[] plaintext, byte[] key) {
		byte[] nonce = RandomNumberGenerator.GetBytes(NonceSize);
		byte[] tag = new byte[TagSize];
		byte[] cipher = new byte[plaintext.Length];

		using var aes = new AesGcm(key);
		aes.Encrypt(nonce, plaintext, cipher, tag);
		return (cipher, nonce, tag);
	}

	/// <summary>
	/// 底层解密：验证 tag 并返回明文
	/// </summary>
	private static byte[] Decrypt(byte[] ciphertext, byte[] nonce, byte[] tag, byte[] key) {
		byte[] plaintext = new byte[ciphertext.Length];
		using var aes = new AesGcm(key);
		aes.Decrypt(nonce, ciphertext, tag, plaintext);
		return plaintext;
	}
}
