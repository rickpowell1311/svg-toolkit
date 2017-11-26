using System;

namespace SvgToolkit
{
    public class SvgGuid
    {
        private readonly Guid guid;

        public SvgGuid(Guid guid)
        {
            this.guid = guid;
        }

        public override string ToString()
        {
            return guid.ToString().Replace("-", string.Empty);
        }
    }
}
