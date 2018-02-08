using System.Globalization;
using System.Threading;

namespace Multilingual
{
    /// <summary>
    /// Implementation of multilingual
    /// </summary>
    public class Culture : IMultilingual
    {
        CultureInfo _currentCultureInfo = CultureInfo.InstalledUICulture;
        public CultureInfo CurrentCultureInfo
        {
            get => _currentCultureInfo;
            set
            {
                _currentCultureInfo = value;
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public CultureInfo DeviceCultureInfo => CultureInfo.InstalledUICulture;

        public CultureInfo[] CultureInfoList => CultureInfo.GetCultures(CultureTypes.AllCultures);

        public CultureInfo[] NeutralCultureInfoList => CultureInfo.GetCultures(CultureTypes.NeutralCultures);

        public CultureInfo GetCultureInfo(string name) => CultureInfo.GetCultureInfo(name);
    }
}