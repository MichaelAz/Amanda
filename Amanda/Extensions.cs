using System;
using System.IO;
using System.Text;

namespace Amanda
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
            return  t == typeof(bool)        ||
                    t == typeof(byte)        ||
                    t == typeof(sbyte)       ||
                    t == typeof(char)        ||
                    t == typeof(decimal)     ||
                    t == typeof(double)      ||
                    t == typeof(float)       ||
                    t == typeof(int)         ||
                    t == typeof(uint)        ||
                    t == typeof(long)        ||
                    t == typeof(ulong)       ||
                    t == typeof(object)      ||
                    t == typeof(short)       ||
                    t == typeof(ushort)      ||
                    t == typeof(string)      ||
                    t == typeof(bool?)       ||
                    t == typeof(byte?)       ||
                    t == typeof(sbyte?)      ||
                    t == typeof(char?)       ||
                    t == typeof(decimal?)    ||
                    t == typeof(double?)     ||
                    t == typeof(float?)      ||
                    t == typeof(int?)        ||
                    t == typeof(uint?)       ||
                    t == typeof(long?)       ||
                    t == typeof(ulong?)      ||
                    t == typeof(short?)      ||
                    t == typeof(ushort?);
        }

        public static dynamic Default(this Type t)
        {
            if (t == typeof (bool))
            {
                return default(bool);
            }
            else if (t == typeof (byte))
            {
                return default(byte);
            }
            else if (t == typeof (sbyte))
            {
                return default(sbyte);
            }
            else if (t == typeof (char))
            {
                return default(char);
            }
            else if (t == typeof (decimal))
            {
                return default(decimal);
            }
            else if (t == typeof (double))
            {
                return default(double);
            }
            else if (t == typeof (float))
            {
                return default(float);
            }
            else if (t == typeof (int))
            {
                return default(int);
            }
            else if (t == typeof (uint))
            {
                return default(uint);
            }
            else if (t == typeof (long))
            {
                return default(long);
            }
            else if (t == typeof (ulong))
            {
                return default(ulong);
            }
            else if (t == typeof (short))
            {
                return default(short);
            }
            else if (t == typeof (ushort))
            {
                return default(ushort);
            }
            else
            {
                return null;
            }
        }
    }
}
