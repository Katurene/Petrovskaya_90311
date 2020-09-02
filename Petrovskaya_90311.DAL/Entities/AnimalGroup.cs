using System;
using System.Collections.Generic;
using System.Text;

namespace Petrovskaya_90311.DAL.Entities
{
    public class AnimalGroup
    {
        public int AnimalGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Animal> Animals { get; set; }
    }
}
