using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petrovskaya_90311.DAL.Entities;
using Petrovskaya_90311.Models;

namespace Petrovskaya_90311.Controllers
{
    public class AnimalController : Controller
    {
        public List<Animal> _animals;  //паблик для теста
        List<AnimalGroup> _animalGroups;

        int _pageSize;

        public AnimalController()
        {
            _pageSize = 3;
            SetupData();
        }

        //public IActionResult Index(int pageNo = 1)
        //{
        //    var items = _animals
        //    .Skip((pageNo - 1) * _pageSize)
        //    .Take(_pageSize)
        //    .ToList();
        //    return View(items);
        //}

        public IActionResult Index(int pageNo = 1)
        {
            return View(ListViewModel<Animal>.GetModel(_animals, pageNo, _pageSize));
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _animalGroups = new List<AnimalGroup>
            {
                new AnimalGroup {AnimalGroupId=1, GroupName="Попугаи"},
                new AnimalGroup {AnimalGroupId=2, GroupName="Приматы"},
                new AnimalGroup {AnimalGroupId=3, GroupName="Змеи"},
                new AnimalGroup {AnimalGroupId=4, GroupName="Грызуны"},
                new AnimalGroup {AnimalGroupId=5, GroupName="Кошки"}                
            };
            _animals = new List<Animal>
            {
                new Animal {AnimalId = 1, AnimalName="Попугай Ара", 
                    Description="Крупные попугаи с очень яркой окраской зелёных, " +
                    "красных, голубых и жёлтых тонов ",
                    Age =50, AnimalGroupId=1, Image="Ara.jpg" },
                new Animal {AnimalId = 2, AnimalName="Попугай корелла",
                    Description="Средних размеров попугай, почти половину длины тела составляет длина хвоста." +
                    "Вес тела от 80 до 150 грамм.",
                    Age =15, AnimalGroupId=1, Image="Corella.jpg" },

                new Animal { AnimalId = 3, AnimalName="Мартышка", 
                    Description="Довольно небольшие обезьяны. Длина тела составляет от 30 до 100 сантиметров.",
                    Age =10, AnimalGroupId=2, Image="Martishka.jpg" },
                new Animal { AnimalId = 4, AnimalName="Шимпанзе",
                    Description="Род обезьян из семейства гоминидов.",
                    Age =35, AnimalGroupId=2, Image="Shimpanze.jpg" },
                new Animal { AnimalId = 5, AnimalName="Павиан",
                    Description="Эти обезьяны отличаются высокой агрессивностью, но при этом умело уживаются с людьми.",
                    Age =15, AnimalGroupId=2, Image="Pavian.jpg" },

                new Animal { AnimalId = 6, AnimalName="Коралловый аспид",
                    Description="Род ядовитых змей из семейства аспидов (Elapidae). Имеют яркую окраску с " +
                    "характерными чёрными, красными и жёлтыми кольцами",
                    Age =3, AnimalGroupId=3, Image="Aspid.jpg" },
                new Animal { AnimalId = 7, AnimalName="Черная мамба",
                    Description="Ядовитая змея, распространённая в Африке. Длина тела может превышать 3 м",
                    Age =5, AnimalGroupId=3, Image="Mamba.jpg" },
                new Animal { AnimalId = 8, AnimalName="Тигровый питон",
                    Description="Крупная неядовитая змея. Длина тела может варьироваться от 1,5 до 4 м и более, в зависимости от пола",
                    Age =15, AnimalGroupId=3, Image="Piton.jpg" },

                new Animal {AnimalId = 9, AnimalName="Сурок",
                    Description="Крупные, весом в несколько килограммов, животные, обитающие в открытых " +
                    "ландшафтах, в сооружаемых самостоятельно норах." ,
                    Age =2, AnimalGroupId=4, Image="Surok.jpg" },
                new Animal {AnimalId = 10, AnimalName="Хомяк",
                    Description="Размеры хомячков могут варьироваться от 5 до 37 см," +
                    " а вес — от 45 до 700 граммов.",
                    Age =1, AnimalGroupId=4, Image="Homyak.jpg" },

                new Animal { AnimalId = 11, AnimalName="Бенгальская кошка",
                    Description="Межродовой гибрид домашней кошки и бенгальской кошки ",
                    Age =7, AnimalGroupId=5, Image="Koshka.jpg" }
            };
        }
    }
}

