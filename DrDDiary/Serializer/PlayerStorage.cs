using DrDDiary.Models.PlayerModel;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrDDiary.Serializer
{
    public static class PlayerStorage
    {
        //need to be defined as basic path, and during saving, part with CharacterName.json is added
        //private const string FilePath = "playerData.json"; //filepath=C:\Program Files (x86)\Default Company Name - basic root path + \Saved characters +\CharacterName.json

        public static async Task SavePlayerAsync(Player player)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                // This is important for deserializing interfaces back to concrete types
                Converters = { new JsonStringEnumConverter() }
            };

            var json = JsonSerializer.Serialize(player, options);
            //await File.WriteAllTextAsync(player.CharacterModel.NameTextBoxValue + ".json", json);
            var fileName = string.IsNullOrWhiteSpace(player.CharacterModel.Name)
                ? "defaultCharacterName.json"
                : player.CharacterModel.Name + ".json";

            await File.WriteAllTextAsync(fileName, json);
        }

        public static async Task<Player> LoadPlayerAsync()
        {
            if (!File.Exists("Alibaba.json"))
            {
                throw new FileNotFoundException("Player data file not found.");
            }

            var json = await File.ReadAllTextAsync("Alibaba.json");
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };

            return JsonSerializer.Deserialize<Player>(json, options);
        }
    }
}
