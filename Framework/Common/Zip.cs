using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Auu.Framework.Common
{
    public static class Zip
    {
        public static byte[] Compress(byte[] toCompress)
        {
            var ms = new MemoryStream();
            var compressedZipStream = new GZipStream(ms, CompressionMode.Compress, true);
            compressedZipStream.Write(toCompress, 0, toCompress.Length);
            compressedZipStream.Close();
            return ms.ToArray();
        }

        public static byte[] DeCompress(byte[] toDeCompress)
        {
            var ms = new MemoryStream(toDeCompress);
            var compressedZipStream = new GZipStream(ms, CompressionMode.Decompress);
            var outBuffer = new MemoryStream();
            var block = new byte[1024];
            while (true)
            {
                var bytesRead = compressedZipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                outBuffer.Write(block, 0, bytesRead);
            }

            compressedZipStream.Close();
            return outBuffer.ToArray();
        }

        /// <summary>
        ///     将传入字符串以GZip算法压缩后，返回Base64编码字符
        /// </summary>
        /// <param name="rawString">需要压缩的字符串</param>
        /// <returns>压缩后的Base64编码的字符串</returns>
        public static string GZipCompressString(string rawString)
        {
            if (string.IsNullOrEmpty(rawString) || rawString.Length == 0) return "";

            var rawData = Encoding.UTF8.GetBytes(rawString);
            var zippedData = Compress(rawData);
            return Convert.ToBase64String(zippedData);
        }

        /// <summary>
        ///     将传入的二进制字符串资料以GZip算法解压缩
        /// </summary>
        /// <param name="zippedString">经GZip压缩后的二进制字符串</param>
        /// <returns>原始未压缩字符串</returns>
        public static string GZipDecompressString(string zippedString)
        {
            if (string.IsNullOrEmpty(zippedString) || zippedString.Length == 0) return "";

            var zippedData = Convert.FromBase64String(zippedString);
            return Encoding.UTF8.GetString(DeCompress(zippedData));
        }
    }
}