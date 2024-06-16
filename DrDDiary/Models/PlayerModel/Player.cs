using DrDDiary.Interfaces.PlayerInterfaces;
using DrDDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrDDiary.Models.PlayerModel
{
    [Serializable]
    public class Player
    {
        public CharacterModel CharacterModel { get; set; }
        public InventoryModel InventoryModel { get; set; }
        public SkillModel SkillModel { get; set; }
        public LoreModel LoreModel { get; set; }
        public NotesModel NotesModel { get; set; }

        public Player(CharacterModel characterModel, InventoryModel inventoryModel, SkillModel skillModel, LoreModel loreModel, NotesModel notesModel)
        {
            CharacterModel = characterModel;
            InventoryModel = inventoryModel;
            SkillModel = skillModel;
            LoreModel = loreModel;
            NotesModel = notesModel;
        }

        // Parameterless constructor for serialization, is needed ?
        public Player() { }
    }
}
