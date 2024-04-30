using Avalonia.Controls;
using DrDDiary.Helpers;

namespace DrDDiary.Views
{
    public partial class CharacterView : UserControl
    {
        public CharacterView()
        {
            InitializeComponent();
            SetLabelContent();
        }

        public void SetLabelContent()
        {
            //Labels will create before language is changed 
            //Solo method invoked by Event called when button to change language is called ?
            nameOfCharacter.Content = LanguageManager.GetString("lblName");
            raceOfCharacter.Content = LanguageManager.GetString("lblRace");
        }
    }
}
