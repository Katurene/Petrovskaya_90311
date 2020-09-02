using System;
using System.Collections.Generic;
using System.Text;

namespace Petrovskaya_90311.DAL.Entities
{
    public class Animal
    {
        public int AnimalId { get; set; } // id животного
        public string AnimalName { get; set; } // название животного
        public string Description { get; set; } // описание 
        public int Age { get; set; } // возраст
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int AnimalGroupId { get; set; }
        public AnimalGroup Group { get; set; }
    }
}
