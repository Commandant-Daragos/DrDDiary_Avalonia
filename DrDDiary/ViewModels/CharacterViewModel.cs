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
        private CharacterView _characterView;
        public CharacterView CharacterView 
        {  
            get => _characterView; 
            set 
            {
                if (_characterView != value)
                {
                    _characterView = value;
                }
            }
        }

        private CharacterModel _characterModel;
        public CharacterModel CharacterModel
        {
            get => _characterModel;
            set
            {
                if (_characterModel != value)
                {
                    _characterModel = value;
                    OnPropertyChanged(nameof(CharacterModel));
                    OnPropertyChanged(nameof(NameTextBoxValue));
                    OnPropertyChanged(nameof(RaceTextBoxValue));

                    if (_characterModel.Image != null)
                    {
                        OnPropertyChanged(nameof(ImageButtonContent));
                        CharacterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                    }

                    OnPropertyChanged(nameof(LvlFighterTextBoxValue));
                    OnPropertyChanged(nameof(LvlTricksterTextBoxValue));
                    OnPropertyChanged(nameof(LvlHunterTextBoxValue));
                    OnPropertyChanged(nameof(LvlMedicasterTextBoxValue));
                    OnPropertyChanged(nameof(LvlConjurerTextBoxValue));
                    OnPropertyChanged(nameof(LvlWarriorTextBoxValue));
                    OnPropertyChanged(nameof(LvlBorderGuardTextBoxValue));
                    OnPropertyChanged(nameof(LvlScholarTextBoxValue));
                    OnPropertyChanged(nameof(LvlWizardTextBoxValue));
                    OnPropertyChanged(nameof(LvlScoutTextBoxValue));
                    OnPropertyChanged(nameof(LvlRobberTextBoxValue));
                    OnPropertyChanged(nameof(LvlMageTextBoxValue));
                    OnPropertyChanged(nameof(LvlDruidTextBoxValue));
                    OnPropertyChanged(nameof(LvlShamanTextBoxValue));
                    OnPropertyChanged(nameof(LvlAlchemistTextBoxValue));

                    OnPropertyChanged(nameof(StrenghtScarsTextBoxValue));
                    OnPropertyChanged(nameof(SoulScarsTextBoxValue));
                    OnPropertyChanged(nameof(InfluenceScarsTextBoxValue));
                    // Add OnPropertyChanged calls for other dependent properties
                }
            }
        }

        private const string IMAGESELECT = "Assets/Images/CharacterScreen/button_selection_character_screen.png";
        private const string IMAGECOGWHEELUNCLICKED = "Assets/Images/CharacterScreen/Cogwheel_normal_unclicked.png";
        private const string IMAGECOGWHEELCLICKED = "Assets/Images/CharacterScreen/Cogwheel_normal_clicked.png";
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        public CharacterViewModel(CharacterView charView, CharacterModel charModel)
        {
            CharacterView = charView;
            CharacterModel = charModel;

            SelectCharImageButtonClicked = ReactiveCommand.Create(OpenSelectionWindow);
            EnableImageSelectionButton = ReactiveCommand.Create(EnableCharacterImageButton);
            CharacterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELUNCLICKED)) };

            CharacterView.DataContext = this;

            SetCharacterButtonSelectionImageToDefaultIfNotPresent();
        }

        #region CharacterBasicInfoTextBoxesAndImage
        /// <summary>
        /// Name TextBox
        /// </summary>
        public string? NameTextBoxValue
        {
            get { return CharacterModel.Name; }
            set
            {
                CharacterModel.Name = value;
                OnPropertyChanged(nameof(NameTextBoxValue));
            }
        }

        /// <summary>
        /// Race TextBox
        /// </summary>
        public string? RaceTextBoxValue
        {
            get { return CharacterModel.Race; }
            set
            {
                CharacterModel.Race = value;
                OnPropertyChanged(nameof(RaceTextBoxValue));
            }
        }

        /// <summary>
        /// Image of character
        /// </summary>
        public Control? ImageButtonContent
        {
            get
            {
                if (CharacterModel.Image != null)
                {
                    return new Image { Source = CharacterModel.Image };
                }
                return null;
            }
            set
            {
                if (value is Image image)
                {
                    CharacterModel.Image = image.Source as Bitmap;
                }
                else
                {
                    CharacterModel.Image = null;
                }
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
            get { return CharacterModel.LvlFighter; }
            set
            {
                CharacterModel.LvlFighter = value;
                OnPropertyChanged(nameof(LvlFighterTextBoxValue));
            }
        }

        /// <summary>
        /// Trickster TextBox
        /// </summary>
        public int? LvlTricksterTextBoxValue
        {
            get { return CharacterModel.LvlTrickster; }
            set
            {
                CharacterModel.LvlTrickster = value;
                OnPropertyChanged(nameof(LvlTricksterTextBoxValue));
            }
        }

        /// <summary>
        /// Hunter TextBox
        /// </summary>
        public int? LvlHunterTextBoxValue
        {
            get { return CharacterModel.LvlHunter; }
            set
            {
                CharacterModel.LvlHunter = value;
                OnPropertyChanged(nameof(LvlHunterTextBoxValue));
            }
        }

        /// <summary>
        /// Medicaster TextBox
        /// </summary>
        public int? LvlMedicasterTextBoxValue
        {
            get { return CharacterModel.LvlMedicaster; }
            set
            {
                CharacterModel.LvlMedicaster = value;
                OnPropertyChanged(nameof(LvlMedicasterTextBoxValue));
            }
        }

        /// <summary>
        /// Conjurer TextBox
        /// </summary>
        public int? LvlConjurerTextBoxValue
        {
            get { return CharacterModel.LvlConjurer; }
            set
            {
                CharacterModel.LvlConjurer = value;
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
            get { return CharacterModel.LvlWarrior; }
            set
            {
                CharacterModel.LvlWarrior = value;
                OnPropertyChanged(nameof(LvlWarriorTextBoxValue));
            }
        }

        /// <summary>
        /// Border Guard TextBox
        /// </summary>
        public int? LvlBorderGuardTextBoxValue
        {
            get { return CharacterModel.LvlBorderGuard; }
            set
            {
                CharacterModel.LvlBorderGuard = value;
                OnPropertyChanged(nameof(LvlBorderGuardTextBoxValue));
            }
        }

        /// <summary>
        /// Scholar TextBox
        /// </summary>
        public int? LvlScholarTextBoxValue
        {
            get { return CharacterModel.LvlScholar; }
            set
            {
                CharacterModel.LvlScholar = value;
                OnPropertyChanged(nameof(LvlScholarTextBoxValue));
            }
        }

        /// <summary>
        /// Wizard TextBox
        /// </summary>
        public int? LvlWizardTextBoxValue
        {
            get { return CharacterModel.LvlWizard; }
            set
            {
                CharacterModel.LvlWizard = value;
                OnPropertyChanged(nameof(LvlWizardTextBoxValue));
            }
        }

        /// <summary>
        /// Scout TextBox
        /// </summary>
        public int? LvlScoutTextBoxValue
        {
            get { return CharacterModel.LvlScout; }
            set
            {
                CharacterModel.LvlScout = value;
                OnPropertyChanged(nameof(LvlScoutTextBoxValue));
            }
        }

        /// <summary>
        /// Robber TextBox
        /// </summary>
        public int? LvlRobberTextBoxValue
        {
            get { return CharacterModel.LvlRobber; }
            set
            {
                CharacterModel.LvlRobber = value;
                OnPropertyChanged(nameof(LvlRobberTextBoxValue));
            }
        }

        /// <summary>
        /// Mage TextBox
        /// </summary>
        public int? LvlMageTextBoxValue
        {
            get { return CharacterModel.LvlMage; }
            set
            {
                CharacterModel.LvlMage = value;
                OnPropertyChanged(nameof(LvlMageTextBoxValue));
            }
        }

        /// <summary>
        /// Druid TextBox
        /// </summary>
        public int? LvlDruidTextBoxValue
        {
            get { return CharacterModel.LvlDruid; }
            set
            {
                CharacterModel.LvlDruid = value;
                OnPropertyChanged(nameof(LvlDruidTextBoxValue));
            }
        }

        /// <summary>
        /// Shaman TextBox
        /// </summary>
        public int? LvlShamanTextBoxValue
        {
            get { return CharacterModel.LvlShaman; }
            set
            {
                CharacterModel.LvlShaman = value;
                OnPropertyChanged(nameof(LvlShamanTextBoxValue));
            }
        }

        /// <summary>
        /// Alchemist TextBox
        /// </summary>
        public int? LvlAlchemistTextBoxValue
        {
            get { return CharacterModel.LvlAlchemist; }
            set
            {
                CharacterModel.LvlAlchemist = value;
                OnPropertyChanged(nameof(LvlAlchemistTextBoxValue));
            }
        }
        #endregion
        #region CharacterScars
        /// <summary>
        /// Strength scars TextBox
        /// </summary>
        public string? StrenghtScarsTextBoxValue
        {
            get { return CharacterModel.StrengthScars; }
            set
            {
                CharacterModel.StrengthScars = value;
                OnPropertyChanged(nameof(StrenghtScarsTextBoxValue));
            }
        }

        /// <summary>
        /// Soul scars TextBox
        /// </summary>
        public string? SoulScarsTextBoxValue
        {
            get { return CharacterModel.SoulScars; }
            set
            {
                CharacterModel.SoulScars = value;
                OnPropertyChanged(nameof(SoulScarsTextBoxValue));
            }
        }

        /// <summary>
        /// Influence scars TextBox
        /// </summary>
        public string? InfluenceScarsTextBoxValue
        {
            get { return CharacterModel.InfluenceScars; }
            set
            {
                CharacterModel.InfluenceScars = value;
                OnPropertyChanged(nameof(InfluenceScarsTextBoxValue));
            }
        }
        #endregion
        public UserControl GetView()
        {
            return CharacterView;
        }

        public CharacterModel GetCharacterModel()
        {
            return CharacterModel;
        }

        //public void SetCharacterModel(CharacterModel charModel)
        //{
        //    CharacterModel = charModel;
        //}

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

        /// <summary>
        /// Private method to open file explorer to choose character image
        /// </summary>
        //private void OpenFileExplorer()
        //{
        //    var openFileDialog = new OpenFileDialog
        //    {
        //        Filters = new List<FileDialogFilter>
        //{
        //    new FileDialogFilter { Name = "Images", Extensions = { "jpg", "jpeg", "png", "gif", "bmp" } }
        //}
        //    };

        //    // Show the file dialog asynchronously
        //    var task = openFileDialog.ShowAsync(App.MainWindowInstance);

        //    // Wait for the user to select a file
        //    task.ContinueWith(t =>
        //    {
        //        if (t.IsCompletedSuccessfully && t.Result != null && t.Result.Length > 0)
        //        {
        //            var imagePath = t.Result.FirstOrDefault(); // Get the first selected file

        //            if (!string.IsNullOrEmpty(imagePath))
        //            {
        //                // Perform UI updates from a non-UI thread
        //                Dispatcher.UIThread.InvokeAsync(() =>
        //                {
        //                    try
        //                    {
        //                        var bitmap = new Bitmap(imagePath);

        //                        // Update UI elements here
        //                        ImageButtonContent = bitmap;
        //                        CharacterView.ButtonSelectionCharacterScreen.Content = new Image { Source = bitmap };
        //                        CharacterView.ButtonSelectionCharacterScreen.IsEnabled = false;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Handle exceptions (e.g., file not found, invalid image format)
        //                        Console.WriteLine($"Error loading image: {ex.Message}");
        //                    }
        //                });
        //            }
        //        }
        //    });
        //}
        private void OpenFileExplorer()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filters = new List<FileDialogFilter>
        {
            new FileDialogFilter { Name = "Images", Extensions = { "jpg", "jpeg", "png", "gif", "bmp" } }
        }
            };

            // Show the file dialog asynchronously
            var task = openFileDialog.ShowAsync(App.MainWindowInstance);

            // Handle the file selection result
            task.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully && t.Result != null && t.Result.Length > 0)
                {
                    var imagePath = t.Result.FirstOrDefault(); // Get the first selected file

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        // Perform UI updates on the UI thread
                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            try
                            {
                                // Load the image into a Bitmap
                                var bitmap = new Bitmap(imagePath);

                                // Update the button's content with an Image control
                                CharacterView.ButtonSelectionCharacterScreen.Content = new Image { Source = bitmap };

                                // Update the ImageButtonContent property
                                ImageButtonContent = new Image { Source = bitmap };

                                // Disable the button to prevent further changes
                                CharacterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                            }
                            catch (Exception ex)
                            {
                                // Log any exceptions
                                Console.WriteLine($"Error loading image: {ex.Message}");
                            }
                        });
                    }
                }
            });
        }

        private void SetCharacterButtonSelectionImageToDefaultIfNotPresent()
        {
            if (CharacterModel.Image == null)
            {
                CharacterView.ButtonSelectionCharacterScreen.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGESELECT)) };
            }
            else
            {
                CharacterView.ButtonSelectionCharacterScreen.IsEnabled = false;
            }
        }

        private void EnableCharacterImageButton()
        {
            if (!CharacterView.ButtonSelectionCharacterScreen.IsEnabled)
            {
                CharacterView.ButtonSelectionCharacterScreen.IsEnabled = true;
                CharacterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELCLICKED)) };
            }
            else
            {
                CharacterView.ButtonSelectionCharacterScreen.IsEnabled = false;
                CharacterView.CogwheelButton.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECOGWHEELUNCLICKED)) };
            }
        }
    }
}
