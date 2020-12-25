using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Extensions
{
	public static class PrimitiveTypeExtensions
	{
		public static byte ToByte(this object value)
		{
			bool result = Byte.TryParse(value.ToString(), out var val);
			return (result) ? val : Convert.ToByte(0);
		}

		public static short ToInt16(this object value)
		{
			bool result = Int16.TryParse(value.ToString(), out var val);
			return (result) ? val : Convert.ToInt16(0);
		}

		public static int ToInt32(this object value)
		{
			bool result = Int32.TryParse(value.ToString(), out var val);
			return (result) ? val : 0;
		}

		public static long ToInt64(this object value)
		{
			bool result = Int64.TryParse(value.ToString(), out var val);
			return (result) ? val : 0L;
		}

		public static float ToFloat(this object value)
		{
			bool result = float.TryParse(value.ToString(), out var val);
			return (result) ? val : 0.0F;
		}

		public static double ToDouble(this object value)
		{
			bool result = double.TryParse(value.ToString(), out var val);
			return (result) ? val : 0.0D;
		}

		public static decimal ToDecimal(this object value)
		{
			bool result = Decimal.TryParse(value.ToString(), out var val);
			return (result) ? val : 0.0M;
		}

		public static bool ToBool(this object value)
		{
			bool result = bool.TryParse(value.ToString(), out var val);
			return (result) && val;
		}

		public static object ToType<T>(this object obj, T type)
		{

			//create instance of T type object:
			var tmp = Activator.CreateInstance(Type.GetType(type.ToString()));

			//loop through the properties of the object you want to covert:          
			foreach (PropertyInfo pi in obj.GetType().GetProperties())
			{
				try
				{

					//get the value of property and try 
					//to assign it to the property of T type object:
					tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
				}
				catch
				{
					// ignored
				}
			}

			//return the T type object:         
			return tmp;
		}

		public static Color ToColor(this string argb)
		{
			argb = argb.Replace("#", "");
			byte a = Convert.ToByte("ff", 16);
			byte pos = 0;
			if (argb.Length == 8)
			{
				a = Convert.ToByte(argb.Substring(pos, 2), 16);
				pos = 2;
			}
			byte r = Convert.ToByte(argb.Substring(pos, 2), 16);
			pos += 2;
			byte g = Convert.ToByte(argb.Substring(pos, 2), 16);
			pos += 2;
			byte b = Convert.ToByte(argb.Substring(pos, 2), 16);
			return Color.FromArgb(a, r, g, b);
		}

		/// <summary>
		/// IsNullOrEmpty 
		/// </summary>
		/// <param name="theString"></param>
		/// <returns></returns>
		public static bool IsNotNullOrEmpty(this string theString)
		{
			return !string.IsNullOrEmpty(theString);
		}

		/// <summary>
		/// IsNullOrEmptyOrWhiteSpace
		/// </summary>
		/// <param name="theString"></param>
		/// <returns></returns>
		public static bool IsNullOrEmptyOrWhiteSpace(this string theString)
		{
			return string.IsNullOrEmpty(theString) || theString.Trim() == string.Empty;
		}

		/// <summary>
		/// Is strong Password
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static bool IsStrongPassword(this string s)
		{
			bool isStrong = Regex.IsMatch(s, @"[\d]");
			if (isStrong) isStrong = Regex.IsMatch(s, @"[a-z]");
			if (isStrong) isStrong = Regex.IsMatch(s, @"[A-Z]");
			if (isStrong) isStrong = Regex.IsMatch(s, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");
			if (isStrong) isStrong = s.Length > 7;
			return isStrong;
		}
	}
}
