using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Helpers
{
    public static class CacheKeyBuilder
    {
        public static string Build(string identifierObject, string identifierId)
        {
            return string.Format("SistematIT-{0}-{1}", identifierObject, identifierId);
        }
    }
}
