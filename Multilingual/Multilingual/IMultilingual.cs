using System;
using System.Collections.Generic;
using System.Globalization;

namespace Multilingual
{
    /// <summary>
    /// Interface for Multilingual
    /// </summary>
    public interface IMultilingual
    {
        CultureInfo CurrentCultureInfo {get; set;}
        CultureInfo DeviceCultureInfo { get; }
        CultureInfo[] CultureInfoList { get; }
        CultureInfo[] NeutralCultureInfoList { get; }
        CultureInfo GetCultureInfo(string name);
    }
}
