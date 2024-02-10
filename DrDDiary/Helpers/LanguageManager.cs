using DrDDiary.Assets.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Helpers
{
    public static class LanguageManager
    {
        private static ResourceManager myManager = new ResourceManager(typeof(languageSK));

        public static string GetString(string resourceName)
        {
            return myManager.GetString(resourceName);
        }

        public static void SetLanguageResource(string language)
        {
            switch (language)
            {
                case "SK": myManager = new ResourceManager(typeof(languageSK));
                    break;
                case "EN": myManager = new ResourceManager(typeof(languageEN));
                    break;
                default: myManager = new ResourceManager(typeof(languageEN));
                    break;
            }
        }
    }
}
