using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure
{
    public static class IntParseIgnoreException
    {
        public static Int32 ParseIgnoreException(this String query)
        {
            try
            {
                return Int32.Parse(query);
            }
            catch
            {
                return 0;
            }
        }
    }
}
