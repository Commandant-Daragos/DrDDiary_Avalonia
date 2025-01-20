using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers;
using System.IO;

namespace DrDDiary.Views
{
    public partial class CharacterView : UserControl
    {
        private const string IMAGESELECT = "Assets/Images/CharacterScreen/button_selection_character_screen.png";

        public CharacterView()
        {
            InitializeComponent();
            SetLabelContent();
            SetTextBoxElementsPreviewEvent();
            //SetBasicImageButtonConten();

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
            //Character resources
            lblStrength.Content = LanguageManager.GetString("lblStrength");
            lblSoul.Content = LanguageManager.GetString("lblSoul");
            lblInfluence.Content = LanguageManager.GetString("lblInfluence");
        }

        private void ReloadViewLabels(object ?sender, LanguageEvent e)
        {
            SetLabelContent();
        }

        private void SetTextBoxElementsPreviewEvent()
        {
            //Basic Classes
            lvlFighter.KeyDown += LevelTextBox_KeyDown;
            lvlTrickster.KeyDown += LevelTextBox_KeyDown;
            lvlHunter.KeyDown += LevelTextBox_KeyDown;
            lvlMedicaster.KeyDown += LevelTextBox_KeyDown;
            lvlConjurer.KeyDown += LevelTextBox_KeyDown;    
            //Advanced Classes
            lvlWarrior.KeyDown += LevelTextBox_KeyDown;
            lvlBorderGuard.KeyDown += LevelTextBox_KeyDown;
            lvlScholar.KeyDown += LevelTextBox_KeyDown;
            lvlWizard.KeyDown += LevelTextBox_KeyDown;
            lvlScout.KeyDown += LevelTextBox_KeyDown;
            lvlRobber.KeyDown += LevelTextBox_KeyDown;
            lvlMage.KeyDown += LevelTextBox_KeyDown;
            lvlDruid.KeyDown += LevelTextBox_KeyDown;
            lvlShaman.KeyDown += LevelTextBox_KeyDown;
            lvlAlchemist.KeyDown += LevelTextBox_KeyDown;
        }

        /// <summary>
        /// Event check to allow only numeric characters (0-9) in level text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelTextBox_KeyDown(object ?sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                  (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                  e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true; // Reject input
            }
        }

        /// <summary>
        /// Set default image content for button in character image select area
        /// </summary>
        private void SetBasicImageButtonConten()
        {
            ButtonSelectionCharacterScreen.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGESELECT)) };
        }
    }
}
