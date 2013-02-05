using System;
using System.IO;
using System.Text;

namespace AmandaWS
{
    /// <summary>
    /// A collection of extensions methods used in the BuisnesLogic namespace
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// An abstraction over reading a string from a stream
        /// </summary>
        /// <param name="s">The stream to read from</param>
        /// <returns>The string read</returns>
        public static string AsString(this Stream s)
        {
            return (new StreamReader(s)).ReadToEnd();
        }

        /// <summary>
        /// An abstraction over reading a string from a stream
        /// </summary>
        /// <param name="s">The stream to read from</param>
        /// <param name="detectEncodingFromByteOrderMarks">A boolean indicating whether the 
        /// metod should attempt to detect the encoding from the byte order marks</param>
        /// <returns>The string read</returns>
        public static string AsString(this Stream s, bool detectEncodingFromByteOrderMarks)
        {
            return (new StreamReader(s, detectEncodingFromByteOrderMarks)).ReadToEnd();
        }

        /// <summary>
        /// An abstraction over reading a string from a stream
        /// </summary>
        /// <param name="s">The stream to read from</param>
        /// <param name="encoding">The encoding used to read the string</param>
        /// <returns>The string read</returns>
        public static string AsString(this Stream s, Encoding encoding)
        {
            return (new StreamReader(s, encoding)).ReadToEnd();
        }

        /// <summary>
        /// An abstraction over reading a string from a stream
        /// </summary>
        /// <param name="s">The stream to read from</param>
        /// <param name="encoding">The encoding used to read the string</param>
        /// <param name="detectEncodingFromByteOrderMarks">A boolean indicating whether the 
        /// metod should attempt to detect the encoding from the byte order marks</param>
        /// <returns>The string read</returns>
        public static string AsString(this Stream s, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            return (new StreamReader(s, encoding, detectEncodingFromByteOrderMarks)).ReadToEnd();
        }

        /// <summary>
        /// An abstraction over reading a string from a stream
        /// </summary>
        /// <param name="s">The stream to read from</param>
        /// <param name="encoding">The encoding used to read the string</param>
        /// <param name="detectEncodingFromByteOrderMarks">A boolean indicating whether the 
        /// metod should attempt to detect the encoding from the byte order marks</param>
        /// <param name="bufferSize">The size of the buffer used in reading the string</param>
        /// <returns>The string read</returns>
        public static string AsString(this Stream s, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize)
        {
            return (new StreamReader(s, encoding, detectEncodingFromByteOrderMarks, bufferSize)).ReadToEnd();
        }

        public static bool IsBasic(this Type t)
        {
            return  t == typeof(bool)       ||
                    t == typeof(byte)       ||
                    t == typeof(sbyte)      ||
                    t == typeof(char)       ||
                    t == typeof(decimal)    ||
                    t == typeof(double)     ||
                    t == typeof(float)      ||
                    t == typeof(int)        ||
                    t == typeof(uint)       ||
                    t == typeof(long)       ||
                    t == typeof(ulong)      ||
                    t == typeof(object)     ||
                    t == typeof(short)      ||
                    t == typeof(ushort)     ||
                    t == typeof(string);
        }
    }
}
