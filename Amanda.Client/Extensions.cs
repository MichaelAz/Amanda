using System;
using System.Collections.Generic;
using System.Dynamic;
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
        /// Checks whether a type is a "basic" type as per the C# specification
        /// or a nullable version thereof
        /// </summary>
        /// <param name="t">The type to check</param>
        /// <returns>Whether the type is a basic type</returns>
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

        /// <summary>
        /// Returns the default value for a type, much like the default keyword
        /// </summary>
        /// <param name="t">The type to get a default value for</param>
        /// <returns>The defualt value for the type</returns>
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
  
        public static ExpandoObject ToExpando(this Dictionary<string,object> dict)
        {
            IDictionary<string, dynamic> ex = new ExpandoObject();

            foreach (var pair in dict)
            {
                ex[pair.Key] = pair.Value;
            }

            return (ExpandoObject) ex;
        }
    }
}
