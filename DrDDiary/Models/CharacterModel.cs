using Avalonia.Controls;
using DrDDiary.Helpers.ValueConverter;
using DrDDiary.Interfaces.PlayerInterfaces;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProtoBuf;
using DrDDiary.Helpers.ValueConverter.BitMapSurrogate;

namespace DrDDiary.Models
{
    [ProtoContract]
    public class CharacterModel : BaseModel, ICharacterModel
    {
        public CharacterModel()
        {

        }
        #region CharacterBasicInfo
        /// <summary>
        /// Name of character
        /// + title
        /// </summary>
        private string? _name;
        [ProtoMember(1)]
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Race of character 
        /// + additional race info
        /// </summary>
        private string? _race;
        [ProtoMember(2)]
        public string? Race
        {
            get { return _race; }
            set
            {
                _race = value;
            }
        }

        /// <summary>
        /// Image of character
        /// </summary>
        private Bitmap? _image;

        [ProtoMember(3)]
        public Bitmap? Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        // Explicitly handle serialization and deserialization for Bitmap
        [ProtoMember(4)]
        private BitmapSurrogate _imageSurrogate
        {
            get => ImageConverter.ToSurrogate(_image); // Convert to surrogate for serialization
            set => _image = ImageConverter.FromSurrogate(value); // Convert back to Bitmap after deserialization
        }

        #endregion
        #region BasicClasses
        /// <summary>
        /// Fighter class level
        /// </summary>
        private int? _lvlFighter;
        [ProtoMember(5)]
        public int? LvlFighter
        {
            get { return _lvlFighter; }
            set
            {
                _lvlFighter = value;
            }
        }

        /// <summary>
        /// Trickster class level
        /// </summary>
        private int? _lvlTrickster;
        [ProtoMember(6)]
        public int? LvlTrickster
        {
            get { return _lvlTrickster; }
            set
            {
                _lvlTrickster = value;
            }
        }

        /// <summary>
        /// Hunter class level
        /// </summary>
        private int? _lvlHunter;
        [ProtoMember(7)]
        public int? LvlHunter
        {
            get { return _lvlHunter; }
            set
            {
                _lvlHunter = value;
            }
        }

        /// <summary>
        /// Medicaster class level
        /// </summary>
        private int? _lvlMedicaster;
        [ProtoMember(8)]
        public int? LvlMedicaster
        {
            get { return _lvlMedicaster; }
            set
            {
                _lvlMedicaster = value;
            }
        }

        /// <summary>
        /// Conjurer class level
        /// </summary>
        private int? _lvlConjurer;
        [ProtoMember(9)]
        public int? LvlConjurer
        {
            get { return _lvlConjurer; }
            set
            {
                _lvlConjurer = value;
            }
        }
        #endregion
        #region AdvancedClasses
        /// <summary>
        /// Warrior class level
        /// </summary>
        private int? _lvlWarrior;
        [ProtoMember(10)]
        public int? LvlWarrior
        {
            get { return _lvlWarrior; }
            set
            {
                _lvlWarrior = value;
            }
        }

        /// <summary>
        /// Border Guard class level
        /// </summary>
        private int? _lvlBorderGuard;
        [ProtoMember(11)]
        public int? LvlBorderGuard
        {
            get { return _lvlBorderGuard; }
            set
            {
                _lvlBorderGuard = value;
            }
        }

        /// <summary>
        /// Scholar class level
        /// </summary>
        private int? _lvlScholar;
        [ProtoMember(12)]
        public int? LvlScholar
        {
            get { return _lvlScholar; }
            set
            {
                _lvlScholar = value;
            }
        }

        /// <summary>
        /// Wizard class level
        /// </summary>
        private int? _lvlWizard;
        [ProtoMember(13)]
        public int? LvlWizard
        {
            get { return _lvlWizard; }
            set
            {
                _lvlWizard = value;
            }
        }

        /// <summary>
        /// Scout class level
        /// </summary>
        private int? _lvlScout;
        [ProtoMember(14)]
        public int? LvlScout
        {
            get { return _lvlScout; }
            set
            {
                _lvlScout = value;
            }
        }

        /// <summary>
        /// Robber class level
        /// </summary>
        private int? _lvlRobber;
        [ProtoMember(15)]
        public int? LvlRobber
        {
            get { return _lvlRobber; }
            set
            {
                _lvlRobber = value;
            }
        }

        /// <summary>
        /// Mage class level
        /// </summary>
        private int? _lvlMage;
        [ProtoMember(16)]
        public int? LvlMage
        {
            get { return _lvlMage; }
            set
            {
                _lvlMage= value;
            }
        }

        /// <summary>
        /// Druid class level
        /// </summary>
        private int? _lvlDruid;
        [ProtoMember(17)]
        public int? LvlDruid
        {
            get { return _lvlDruid; }
            set
            {
                _lvlDruid = value;
            }
        }

        /// <summary>
        /// Shaman class level
        /// </summary>
        private int? _lvlShaman;
        [ProtoMember(18)]
        public int? LvlShaman
        {
            get { return _lvlShaman; }
            set
            {
                _lvlShaman = value;

            }
        }

        /// <summary>
        /// Alchemist class level
        /// </summary>
        private int? _lvlAlchemist;
        [ProtoMember(19)]
        public int? LvlAlchemist
        {
            get { return _lvlAlchemist; }
            set
            {
                _lvlAlchemist = value;
            }
        }
        #endregion
        #region CharacterResourcesAndScars
        ///<summary>
        /// Character levels of Strenght/Soul/Influence + scar descriptions
        ///</summary>
        private int? _strength;
        [ProtoMember(20)]
        public int? Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
            }
        }

        private string? _strengthScars;
        [ProtoMember(21)]
        public string? StrengthScars
        {
            get { return _strengthScars; }
            set
            {
                _strengthScars = value;
            }
        }

        private int? _soul;
        [ProtoMember(22)]
        public int? Soul
        {
            get { return _soul; }
            set
            {
                _soul = value;
            }
        }

        private string? _soulScars;
        [ProtoMember(23)]
        public string? SoulScars
        {
            get { return _soulScars; }
            set
            {
                _soulScars = value;
            }
        }

        private int? _influence;
        [ProtoMember(24)]
        public int? Influence
        {
            get { return _influence; }
            set
            {
                _influence = value;
            }
        }

        private string? _influenceScars;
        [ProtoMember(25)]
        public string? InfluenceScars
        {
            get { return _influenceScars; }
            set
            {
                _influenceScars = value;
            }
        }
        #endregion
    }
}
