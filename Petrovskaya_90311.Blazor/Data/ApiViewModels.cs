using System.Text.Json.Serialization;

namespace Petrovskaya_90311.Blazor.Data
{
    public class AnimalListViewModel
    {
        [JsonPropertyName("animalId")]
        public int AnimalId { get; set; } // id 
        [JsonPropertyName("animalName")]
        public string AnimalName { get; set; } // название 
    }

    public class AnimalDetailsViewModel
    {
        [JsonPropertyName("animalName")]
        public string AnimalName { get; set; } // название 
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание 
        [JsonPropertyName("age")]
        public int Age { get; set; } // 
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}