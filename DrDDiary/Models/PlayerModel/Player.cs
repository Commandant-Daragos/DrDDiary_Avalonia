using DrDDiary.Interfaces.PlayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Models.PlayerModel
{
    public class Player
    {
        private readonly ICharacterModel _characterModel;
        private readonly IInventoryModel _inventoryModel;
        private readonly ISkillModel _skillModel;
        private readonly ILoreModel _loreModel;
        private readonly INotesModel _notesModel;

        public Player(ICharacterModel characterModel, IInventoryModel inventoryModel, ISkillModel skillModel, ILoreModel loreModel, INotesModel notesModel)
        {
            _characterModel = characterModel;
            _inventoryModel = inventoryModel;
            _skillModel = skillModel;
            _loreModel = loreModel;
            _notesModel = notesModel;
        }

        public ICharacterModel CharacterModel { get {  return _characterModel; } }
        public IInventoryModel InventoryModel { get { return _inventoryModel; } }
        public ISkillModel SkillModel { get { return _skillModel; } }
        public ILoreModel loreModel1 { get { return _loreModel; } }
        public INotesModel NotesModel { get { return _notesModel; } }   
    }
}
