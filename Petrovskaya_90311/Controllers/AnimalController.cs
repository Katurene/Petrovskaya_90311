﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petrovskaya_90311.DAL.Data;
using Petrovskaya_90311.DAL.Entities;
using Petrovskaya_90311.Extensions;
using Petrovskaya_90311.Models;

namespace Petrovskaya_90311.Controllers
{
    public class AnimalController : Controller
    {
        //public List<Animal> _animals;  //паблик для теста
        //List<AnimalGroup> _animalGroups;
        ApplicationDbContext _context;
        int _pageSize;
        private ILogger _logger;

        public AnimalController(ApplicationDbContext context, ILogger<AnimalController> logger)
        {
            _pageSize = 3;
            //SetupData();
            _context = context;
            _logger = logger;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]       
        public IActionResult Index(int? group, int pageNo=1)
        {
            var groupName = group.HasValue
                ? _context.AnimalGroups.Find(group.Value)?.GroupName
                : "all groups";

            _logger.LogInformation($"info: group={group}, page={pageNo}");

            var animalsFiltered = _context.Animals.Where(d => !group.HasValue || d.AnimalGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.AnimalGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            //return View(ListViewModel<Animal>.GetModel(animalsFiltered, pageNo, _pageSize));

            var model = ListViewModel<Animal>.GetModel(animalsFiltered, pageNo, _pageSize);
            //if (Request.Headers["x-requested-with"]
            //.ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_listpartial", model);

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);

            else
                return View(model);
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        //private void SetupData()
        //{
        //    _animalGroups = new List<AnimalGroup>
        //    {
        //        new AnimalGroup {AnimalGroupId=1, GroupName="Попугаи"},
        //        new AnimalGroup {AnimalGroupId=2, GroupName="Приматы"},
        //        new AnimalGroup {AnimalGroupId=3, GroupName="Змеи"},
        //        new AnimalGroup {AnimalGroupId=4, GroupName="Грызуны"},
        //        new AnimalGroup {AnimalGroupId=5, GroupName="Кошки"}                
        //    };
        //    _animals = new List<Animal>
        //    {
        //        new Animal {AnimalId = 1, AnimalName="Попугай Ара", 
        //            Description="Крупные попугаи с очень яркой окраской зелёных, " +
        //            "красных, голубых и жёлтых тонов ",
        //            Age =50, AnimalGroupId=1, Image="Ara.jpg" },
        //        new Animal {AnimalId = 2, AnimalName="Попугай корелла",
        //            Description="Средних размеров попугай, почти половину длины тела составляет длина хвоста." +
        //            "Вес тела от 80 до 150 грамм.",
        //            Age =15, AnimalGroupId=1, Image="Corella.jpg" },

        //        new Animal { AnimalId = 3, AnimalName="Мартышка", 
        //            Description="Довольно небольшие обезьяны. Длина тела составляет от 30 до 100 сантиметров.",
        //            Age =10, AnimalGroupId=2, Image="Martishka.jpg" },
        //        new Animal { AnimalId = 4, AnimalName="Шимпанзе",
        //            Description="Род обезьян из семейства гоминидов.",
        //            Age =35, AnimalGroupId=2, Image="Shimpanze.jpg" },
        //        new Animal { AnimalId = 5, AnimalName="Павиан",
        //            Description="Эти обезьяны отличаются высокой агрессивностью, но при этом умело уживаются с людьми.",
        //            Age =15, AnimalGroupId=2, Image="Pavian.jpg" },

        //        new Animal { AnimalId = 6, AnimalName="Коралловый аспид",
        //            Description="Род ядовитых змей из семейства аспидов (Elapidae). Имеют яркую окраску с " +
        //            "характерными чёрными, красными и жёлтыми кольцами",
        //            Age =3, AnimalGroupId=3, Image="Aspid.jpg" },
        //        new Animal { AnimalId = 7, AnimalName="Черная мамба",
        //            Description="Ядовитая змея, распространённая в Африке. Длина тела может превышать 3 м",
        //            Age =5, AnimalGroupId=3, Image="Mamba.jpg" },
        //        new Animal { AnimalId = 8, AnimalName="Тигровый питон",
        //            Description="Крупная неядовитая змея. Длина тела может варьироваться от 1,5 до 4 м и более, в зависимости от пола",
        //            Age =15, AnimalGroupId=3, Image="Piton.jpg" },

        //        new Animal {AnimalId = 9, AnimalName="Сурок",
        //            Description="Крупные, весом в несколько килограммов, животные, обитающие в открытых " +
        //            "ландшафтах, в сооружаемых самостоятельно норах." ,
        //            Age =2, AnimalGroupId=4, Image="Surok.jpg" },
        //        new Animal {AnimalId = 10, AnimalName="Хомяк",
        //            Description="Размеры хомячков могут варьироваться от 5 до 37 см," +
        //            " а вес — от 45 до 700 граммов.",
        //            Age =1, AnimalGroupId=4, Image="Homyak.jpg" },

        //        new Animal { AnimalId = 11, AnimalName="Бенгальская кошка",
        //            Description="Межродовой гибрид домашней кошки и бенгальской кошки ",
        //            Age =7, AnimalGroupId=5, Image="Koshka.jpg" }
        //    };
        }
    
}

