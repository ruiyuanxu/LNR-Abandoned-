using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace Core
{
    /// <summary>
    /// A enum that contains all names of the configuration
    /// </summary>
    public enum ConfigNames
    {
        WrapWidth                   = 0,
        ParaLength                  = 1,
        Font                        = 2,
        ForeGroundWidthPercentage   = 3,
        Themes                      = 4
    }
    
    public static class Config
    {
        /// <summary>
        /// Returns Container of the settings
        /// </summary>
        /// <returns>Configuration Collection</returns>
        public static ApplicationDataContainer GlobalSettings()
        {
            return ApplicationData.Current.LocalSettings;
        }

        public static void SetConfig(ConfigNames cname, object value)
        {
            string scn = Enum.GetName(typeof(ConfigNames), cname);
            GlobalSettings().Values[scn] = value;
        }

        public static object GetConfig(ConfigNames cname)
        {
            return GlobalSettings().Values[Enum.GetName(typeof(ConfigNames), cname)];
        }

        public static void reset()
        {
            SetConfig(ConfigNames.WrapWidth, 40);
            SetConfig(ConfigNames.ParaLength, 13 * 40);
            SetConfig(ConfigNames.ForeGroundWidthPercentage, 0.618);
            Themes.reset();
        }

    }

    /// <summary>
    /// A class contains all theme configs.
    ///                                 ->  theme0  ->backColor,foreColor...
    ///                                 ->  theme1
    /// Themes  ->  themes(composite)   ->  theme2
    ///                                     ...
    /// </summary>
    public static class Themes
    {
        public static ApplicationDataCompositeValue ThemesContainer()
        {
            return (ApplicationDataCompositeValue)Config.GetConfig(ConfigNames.Themes);
        }

        public static void reset()
        {
            var themes = new ApplicationDataCompositeValue();
            var themeDefaultLight = new ApplicationDataCompositeValue();
            themeDefaultLight["backColor"] = "#C7EDCC";
            themeDefaultLight["foreColor"] = "#EAF4FC"; //"月白"
            themes["default-light"] = themeDefaultLight;
            Config.GlobalSettings().Values["Themes"] = themes;
        }

    }

}
