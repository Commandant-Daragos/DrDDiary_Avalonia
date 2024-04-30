using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Helpers
{
    /// <summary>
    /// Static class to handle language changes.
    /// After different language is selected on initial screen, global event to refresh label content in corresponding language is sent.
    /// </summary>
    public static class LanguageEventHandler
    {
        private static event EventHandler<LanguageEvent> languageEventHandler;

        public static event EventHandler<LanguageEvent> LanguageEvent
        {
            add { languageEventHandler += value; }
            remove { languageEventHandler -= value; }
        }

        public static void InvokeEvent()
        {
            languageEventHandler?.Invoke(null, new LanguageEvent());
        }
    }

    public class LanguageEvent : EventArgs
    {
    }
}
