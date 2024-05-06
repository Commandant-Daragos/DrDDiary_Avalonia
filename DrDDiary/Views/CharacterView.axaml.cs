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
            LanguageEventHandler.LanguageEvent += ReloadViewLabels;
        }

        public void SetLabelContent()
        {
            //Labels will create before language is changed 
            //Solo method invoked by Event called when button to change language is called ?
            nameOfCharacter.Content = LanguageManager.GetString("lblName");
            raceOfCharacter.Content = LanguageManager.GetString("lblRace");
            //Classes-Basic
            ClassesBasic.Content = LanguageManager.GetString("lblClassesBasic");
            lblFighter.Content = LanguageManager.GetString("lblFighter");
            lblTrickster.Content = LanguageManager.GetString("lblTrickster");
            lblHunter.Content = LanguageManager.GetString("lblHunter");
            lblMedicaster.Content = LanguageManager.GetString("lblMedicaster");
            lblConjurer.Content = LanguageManager.GetString("lblConjurer");
            //Classes-Advanced
            ClassesAdvanced.Content = LanguageManager.GetString("lblClassesAdvanced");
            lblWarrior.Content = LanguageManager.GetString("lblWarrior");
            lblBorderGuard.Content = LanguageManager.GetString("lblBorderGuard");
            lblScholar.Content = LanguageManager.GetString("lblScholar");
            lblWizard.Content = LanguageManager.GetString("lblWizard");
            lblScout.Content = LanguageManager.GetString("lblScout");
            lblRobber.Content = LanguageManager.GetString("lblRobber");
            lblMage.Content = LanguageManager.GetString("lblMage");
            lblDruid.Content = LanguageManager.GetString("lblDruid");
            lblShaman.Content = LanguageManager.GetString("lblShaman");
            lblAlchemist.Content = LanguageManager.GetString("lblAlchemist");
        }

        private void ReloadViewLabels(object sender, LanguageEvent e)
        {
            SetLabelContent();
        }
    }
}
