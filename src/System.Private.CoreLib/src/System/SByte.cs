// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Diagnostics.Contracts;

namespace System
{
    // A place holder class for signed bytes.
    [CLSCompliant(false), System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct SByte : IComparable, IFormattable, IComparable<SByte>, IEquatable<SByte>, IConvertible
    {
        private sbyte _value;

        // The maximum value that a Byte may represent: 127.
        public const sbyte MaxValue = (sbyte)0x7F;

        // The minimum value that a Byte may represent: -128.
        public const sbyte MinValue = unchecked((sbyte)0x80);


        // Compares this object to another object, returning an integer that
        // indicates the relationship. 
        // Returns a value less than zero if this  object
        // null is considered to be less than any instance.
        // If object is not of type SByte, this method throws an ArgumentException.
        // 
        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is SByte))
            {
                throw new ArgumentException(SR.Arg_MustBeSByte);
            }
            return _value - ((SByte)obj)._value;
        }

        public int CompareTo(SByte value)
        {
            return _value - value;
        }

        // Determines whether two Byte objects are equal.
        public override bool Equals(Object obj)
        {
            if (!(obj is SByte))
            {
                return false;
            }
            return _value == ((SByte)obj)._value;
        }

        [NonVersionable]
        public bool Equals(SByte obj)
        {
            return _value == obj;
        }

        // Gets a hash code for this instance.
        public override int GetHashCode()
        {
            return ((int)_value ^ (int)_value << 8);
        }


        // Provides a string representation of a byte.
        public override String ToString()
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return FormatProvider.FormatInt32(_value, null, null);
        }

        public String ToString(IFormatProvider provider)
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return FormatProvider.FormatInt32(_value, null, provider);
        }

        public String ToString(String format)
        {
            Contract.Ensures(Contract.Result<String>() != null);
            return ToString(format, null);
        }

        public String ToString(String format, IFormatProvider provider)
        {
            Contract.Ensures(Contract.Result<String>() != null);


            if (_value < 0 && format != null && format.Length > 0 && (format[0] == 'X' || format[0] == 'x'))
            {
                uint temp = (uint)(_value & 0x000000FF);
                return FormatProvider.FormatUInt32(temp, format, provider);
            }
            return FormatProvider.FormatInt32(_value, format, provider);
        }

        [CLSCompliant(false)]
        public static sbyte Parse(String s)
        {
            return Parse(s, NumberStyles.Integer, null);
        }

        [CLSCompliant(false)]
        public static sbyte Parse(String s, NumberStyles style)
        {
            UInt32.ValidateParseStyleInteger(style);
            return Parse(s, style, null);
        }

        [CLSCompliant(false)]
        public static sbyte Parse(String s, IFormatProvider provider)
        {
            return Parse(s, NumberStyles.Integer, provider);
        }

        // Parses a signed byte from a String in the given style.  If
        // a NumberFormatInfo isn't specified, the current culture's 
        // NumberFormatInfo is assumed.
        // 
        [CLSCompliant(false)]
        public static sbyte Parse(String s, NumberStyles style, IFormatProvider provider)
        {
            UInt32.ValidateParseStyleInteger(style);
            int i = 0;
            try
            {
                i = FormatProvider.ParseInt32(s, style, provider);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(SR.Overflow_SByte, e);
            }

            if ((style & NumberStyles.AllowHexSpecifier) != 0)
            { // We are parsing a hexadecimal number
                if ((i < 0) || i > Byte.MaxValue)
                {
                    throw new OverflowException(SR.Overflow_SByte);
                }
                return (sbyte)i;
            }

            if (i < MinValue || i > MaxValue) throw new OverflowException(SR.Overflow_SByte);
            return (sbyte)i;
        }

        [CLSCompliant(false)]
        public static bool TryParse(String s, out SByte result)
        {
            return TryParse(s, NumberStyles.Integer, null, out result);
        }

        [CLSCompliant(false)]
        public static bool TryParse(String s, NumberStyles style, IFormatProvider provider, out SByte result)
        {
            UInt32.ValidateParseStyleInteger(style);
            result = 0;
            int i;
            if (!FormatProvider.TryParseInt32(s, style, provider, out i))
            {
                return false;
            }

            if ((style & NumberStyles.AllowHexSpecifier) != 0)
            { // We are parsing a hexadecimal number
                if ((i < 0) || i > Byte.MaxValue)
                {
                    return false;
                }
                result = (sbyte)i;
                return true;
            }

            if (i < MinValue || i > MaxValue)
            {
                return false;
            }
            result = (sbyte)i;
            return true;
        }

        //
        // IConvertible implementation
        // 

        public TypeCode GetTypeCode()
        {
            return TypeCode.SByte;
        }


        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(_value);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_value);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return _value;
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return _value;
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_value);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value);
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_value);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException(String.Format(SR.InvalidCast_FromTo, "SByte", "DateTime"));
        }

        Object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return Convert.DefaultToType((IConvertible)this, type, provider);
        }
    }
}
