using System;

namespace SvgToolkit
{
    public class SvgGuid
    {
        private readonly Guid guid;

        private SvgGuid(Guid guid)
        {
            this.guid = guid;
        }

        public static SvgGuid NewGuid()
        {
            return new SvgGuid(Guid.NewGuid());
        }

        public static SvgGuid Empty()
        {
            return new SvgGuid(Guid.Empty);
        }

        public override string ToString()
        {
            return guid.ToString().Replace("-", string.Empty);
        }
    }
}
