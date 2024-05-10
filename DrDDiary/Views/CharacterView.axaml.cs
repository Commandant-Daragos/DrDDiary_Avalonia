using Avalonia.Controls;
using Avalonia.Input;
using DrDDiary.Helpers;

namespace DrDDiary.Views
{
    public partial class CharacterView : UserControl
    {
        public CharacterView()
        {
            InitializeComponent();
            SetLabelContent();
            SetTextBoxElementsPreviewEvent();

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

        private void SetTextBoxElementsPreviewEvent()
        {
            lvlFighter.KeyDown += LevelTextBox_KeyDown;
        }

        /// <summary>
        /// Event check to allow only numeric characters (0-9) in level text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                  (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                  e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true; // Reject input
            }
        }
    }
}
