using System;

namespace SvgToolkit.Tests.Utilities
{
    public class MinifiedString : IEquatable<MinifiedString>
    {
        public string OriginalValue { get; }

        public MinifiedString(string val)
        {
            OriginalValue = val;
        }

        public override string ToString()
        {
            return Minify(OriginalValue);
        }

        private string Minify(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return val;
            }

            return val
                .Replace("\r\n", string.Empty)
                .Replace(" ", string.Empty)
                .Replace("\t", string.Empty);
        }

        public override int GetHashCode()
        {
            return Minify(OriginalValue).GetHashCode();
        }

        public bool Equals(MinifiedString other)
        {
            return Minify(OriginalValue) == Minify(other.OriginalValue);
        }
    }
}
