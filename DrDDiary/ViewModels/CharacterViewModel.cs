using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using DrDDiary.Helpers;
using DrDDiary.Interfaces;
using DrDDiary.Models;
using DrDDiary.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.ViewModels
{
    public class CharacterViewModel : ViewModelBase, IUserControlViewModel, INotifyPropertyChanged
    {
        private CharacterView characterView;
        private CharacterModel characterModel;
        private const string IMAGESELECT = "Assets/Images/CharacterScreen/button_selection_character_screen.png";
        private const string IMAGECOGWHEELUNCLICKED = "Assets/Images/CharacterScreen/Cogwheel_normal_unclicked.png";
        private const string IMAGECOGWHEELCLICKED = "Assets/Images/CharacterScreen/Cogwheel_normal_clicked.png";
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        public CharacterViewModel(CharacterView charView, CharacterModel charModel)
        {
            characterView = charView;
            characterModel = charModel;

            SelectCharImageButtonClicked = ReactiveCommand.Create(OpenSelectionWindow);
            EnableImageSelectionButton = ReactiveCommand.Create(EnableCharacterImageButton);
            characterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELUNCLICKED)) };

            characterView.DataContext = this;

            SetCharacterButtonSelectionImageToDefaultIfNotPresent();
        }

        #region CharacterBasicInfoTextBoxesAndImage
        /// <summary>
        /// Name TextBox
        /// </summary>
        public string? NameTextBoxValue
        {
            get { return characterModel.Name; }
            set
            {
                characterModel.Name = value;
                OnPropertyChanged(nameof(NameTextBoxValue));
            }
        }

        /// <summary>
        /// Race TextBox
        /// </summary>
        public string? RaceTextBoxValue
        {
            get { return characterModel.Race; }
            set
            {
                characterModel.Race = value;
                OnPropertyChanged(nameof(RaceTextBoxValue));
            }
        }

        /// <summary>
        /// Image of character
        /// </summary>
        public Image? ImageButtonContent
        {
            get { return characterModel.Image; }
            set
            {
                characterModel.Image = value;
                OnPropertyChanged(nameof(ImageButtonContent));
            }
        }
        #endregion
        #region BasicClassesTextBoxes
        /// <summary>
        /// Fighter TextBox
        /// </summary>
        public int? LvlFighterTextBoxValue
        {
            get { return characterModel.LvlFighter; }
            set
            {
                characterModel.LvlFighter = value;
                OnPropertyChanged(nameof(LvlFighterTextBoxValue));
            }
        }

        /// <summary>
        /// Trickster TextBox
        /// </summary>
        public int? LvlTricksterTextBoxValue
        {
            get { return characterModel.LvlTrickster; }
            set
            {
                characterModel.LvlTrickster = value;
                OnPropertyChanged(nameof(LvlTricksterTextBoxValue));
            }
        }

        /// <summary>
        /// Hunter TextBox
        /// </summary>
        public int? LvlHunterTextBoxValue
        {
            get { return characterModel.LvlHunter; }
            set
            {
                characterModel.LvlHunter = value;
                OnPropertyChanged(nameof(LvlHunterTextBoxValue));
            }
        }

        /// <summary>
        /// Medicaster TextBox
        /// </summary>
        public int? LvlMedicasterTextBoxValue
        {
            get { return characterModel.LvlMedicaster; }
            set
            {
                characterModel.LvlMedicaster = value;
                OnPropertyChanged(nameof(LvlMedicasterTextBoxValue));
            }
        }

        /// <summary>
        /// Conjurer TextBox
        /// </summary>
        public int? LvlConjurerTextBoxValue
        {
            get { return characterModel.LvlConjurer; }
            set
            {
                characterModel.LvlConjurer = value;
                OnPropertyChanged(nameof(LvlConjurerTextBoxValue));
            }
        }
        #endregion
        #region AdvancedClassesTextBoxes
        /// <summary>
        /// Warrior TextBox
        /// </summary>
        public int? LvlWarriorTextBoxValue
        {
            get { return characterModel.LvlWarrior; }
            set
            {
                characterModel.LvlWarrior = value;
                OnPropertyChanged(nameof(LvlWarriorTextBoxValue));
            }
        }

        /// <summary>
        /// Border Guard TextBox
        /// </summary>
        public int? LvlBorderGuardTextBoxValue
        {
            get { return characterModel.LvlBorderGuard; }
            set
            {
                characterModel.LvlBorderGuard = value;
                OnPropertyChanged(nameof(LvlBorderGuardTextBoxValue));
            }
        }

        /// <summary>
        /// Scholar TextBox
        /// </summary>
        public int? LvlScholarTextBoxValue
        {
            get { return characterModel.LvlScholar; }
            set
            {
                characterModel.LvlScholar = value;
                OnPropertyChanged(nameof(LvlScholarTextBoxValue));
            }
        }

        /// <summary>
        /// Wizard TextBox
        /// </summary>
        public int? LvlWizardTextBoxValue
        {
            get { return characterModel.LvlWizard; }
            set
            {
                characterModel.LvlWizard = value;
                OnPropertyChanged(nameof(LvlWizardTextBoxValue));
            }
        }

        /// <summary>
        /// Scout TextBox
        /// </summary>
        public int? LvlScoutTextBoxValue
        {
            get { return characterModel.LvlScout; }
            set
            {
                characterModel.LvlScout = value;
                OnPropertyChanged(nameof(LvlScoutTextBoxValue));
            }
        }

        /// <summary>
        /// Robber TextBox
        /// </summary>
        public int? LvlRobberTextBoxValue
        {
            get { return characterModel.LvlRobber; }
            set
            {
                characterModel.LvlRobber = value;
                OnPropertyChanged(nameof(LvlRobberTextBoxValue));
            }
        }

        /// <summary>
        /// Mage TextBox
        /// </summary>
        public int? LvlMageTextBoxValue
        {
            get { return characterModel.LvlMage; }
            set
            {
                characterModel.LvlMage = value;
                OnPropertyChanged(nameof(LvlMageTextBoxValue));
            }
        }

        /// <summary>
        /// Druid TextBox
        /// </summary>
        public int? LvlDruidTextBoxValue
        {
            get { return characterModel.LvlDruid; }
            set
            {
                characterModel.LvlDruid = value;
                OnPropertyChanged(nameof(LvlDruidTextBoxValue));
            }
        }

        /// <summary>
        /// Shaman TextBox
        /// </summary>
        public int? LvlShamanTextBoxValue
        {
            get { return characterModel.LvlShaman; }
            set
            {
                characterModel.LvlShaman = value;
                OnPropertyChanged(nameof(LvlShamanTextBoxValue));
            }
        }

        /// <summary>
        /// Alchemist TextBox
        /// </summary>
        public int? LvlAlchemistTextBoxValue
        {
            get { return characterModel.LvlAlchemist; }
            set
            {
                characterModel.LvlAlchemist = value;
                OnPropertyChanged(nameof(LvlAlchemistTextBoxValue));
            }
        }
        #endregion

        public UserControl GetView()
        {
            return characterView;
        }

        public CharacterModel GetCharacterModel()
        {
            return characterModel;
        }

        public void SetCharacterModel(CharacterModel charModel)
        {
            characterModel = charModel;
        }

        /// <summary>
        /// Property Changed invoke metod
        /// </summary>
        /// <param name="propName"></param>
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Character image button selection
        /// </summary>
        public ReactiveCommand<Unit, Unit> SelectCharImageButtonClicked { get; set; }

        /// <summary>
        /// Enable character image button selection
        /// </summary>
        public ReactiveCommand<Unit, Unit> EnableImageSelectionButton { get; set; }

        private void OpenSelectionWindow()
        {
            //Process.Start("explorer.exe");
            OpenFileExplorer();
        }

        private void OpenFileExplorer()
        {
            var openFileDialog = new OpenFileDialog();
            //openFileDialog.Title = "Select Image";
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "Images", Extensions = { "jpg", "jpeg", "png", "gif", "bmp" } });

            // Show the file dialog asynchronously
            var task = openFileDialog.ShowAsync(App.MainWindowInstance);

            // Wait for the user to select a file
            task.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully && t.Result.FirstOrDefault() != null)
                {
                    var ImagePath = t.Result.FirstOrDefault(); // Get the first selected file

                    // Perform UI updates from a non-UI thread
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        // Update UI elements here
                        if (ImagePath is not null)
                        {   ImageButtonContent = new Image { Source = new Bitmap(ImagePath) };
                            characterView.ButtonSelectionCharacterScreen.Content = ImageButtonContent;
                            characterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                        }
                    });
                }
            });
        }

        private void SetCharacterButtonSelectionImageToDefaultIfNotPresent()
        {
            if (characterModel.Image == null)
            {
                characterView.ButtonSelectionCharacterScreen.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGESELECT)) };
            }
            else
            {
                characterView.ButtonSelectionCharacterScreen.IsEnabled = false;
            }
        }

        private void EnableCharacterImageButton()
        {
            if (!characterView.ButtonSelectionCharacterScreen.IsEnabled)
            {
                characterView.ButtonSelectionCharacterScreen.IsEnabled = true;
                characterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELCLICKED)) };
            }
            else
            {
                characterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                characterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELUNCLICKED)) };
            }
        }
    }
}
