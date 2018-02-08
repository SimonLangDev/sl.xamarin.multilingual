using System;
using System.Threading;

namespace Multilingual
{
    /// <summary>
    /// Cross platform multilingual implemenation
    /// </summary>
    public class MultilingualCore
    {
        private static readonly Lazy<IMultilingual> Implementation = new Lazy<IMultilingual>(Create, LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings
        /// </summary>
        public static IMultilingual Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static IMultilingual Create()
        {
            return new Culture();
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented.");
        }
    }
}
