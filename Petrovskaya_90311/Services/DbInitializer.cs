using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Petrovskaya_90311.DAL.Data;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

            //проверка наличия групп объектов
            if (!context.AnimalGroups.Any())
            {
                context.AnimalGroups.AddRange(
                new List<AnimalGroup>
                {
                    new AnimalGroup {GroupName="Попугаи"},
                    new AnimalGroup {GroupName="Приматы"},
                    new AnimalGroup {GroupName="Змеи"},
                    new AnimalGroup {GroupName="Грызуны"},
                    new AnimalGroup {GroupName="Кошки"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Animals.Any())
            {
                context.Animals.AddRange(
                new List<Animal>
                {
                new Animal {AnimalName="Попугай Ара",
                    Description="Крупные попугаи с очень яркой окраской зелёных, " +
                    "красных, голубых и жёлтых тонов ",
                    Age =50, AnimalGroupId=1, Image="Ara.jpg" },
                new Animal {AnimalName="Попугай корелла",
                    Description="Средних размеров попугай, почти половину длины тела составляет длина хвоста." +
                    "Вес тела от 80 до 150 грамм.",
                    Age =15, AnimalGroupId=1, Image="Corella.jpg" },

                new Animal {AnimalName="Мартышка",
                    Description="Довольно небольшие обезьяны. Длина тела составляет от 30 до 100 сантиметров.",
                    Age =10, AnimalGroupId=2, Image="Martishka.jpg" },
                new Animal { AnimalName="Шимпанзе",
                    Description="Род обезьян из семейства гоминидов.",
                    Age =35, AnimalGroupId=2, Image="Shimpanze.jpg" },
                new Animal {AnimalName="Павиан",
                    Description="Эти обезьяны отличаются высокой агрессивностью, но при этом умело уживаются с людьми.",
                    Age =15, AnimalGroupId=2, Image="Pavian.jpg" },

                new Animal {AnimalName="Коралловый аспид",
                    Description="Род ядовитых змей из семейства аспидов (Elapidae). Имеют яркую окраску с " +
                    "характерными чёрными, красными и жёлтыми кольцами",
                    Age =3, AnimalGroupId=3, Image="Aspid.jpg" },
                new Animal {AnimalName="Черная мамба",
                    Description="Ядовитая змея, распространённая в Африке. Длина тела может превышать 3 м",
                    Age =5, AnimalGroupId=3, Image="Mamba.jpg" },
                new Animal {AnimalName="Тигровый питон",
                    Description="Крупная неядовитая змея. Длина тела может варьироваться от 1,5 до 4 м и более, в зависимости от пола",
                    Age =15, AnimalGroupId=3, Image="Piton.jpg" },

                new Animal {AnimalName="Сурок",
                    Description="Крупные, весом в несколько килограммов, животные, обитающие в открытых " +
                    "ландшафтах, в сооружаемых самостоятельно норах." ,
                    Age =2, AnimalGroupId=4, Image="Surok.jpg" },
                new Animal {AnimalName="Хомяк",
                    Description="Размеры хомячков могут варьироваться от 5 до 37 см," +
                    " а вес — от 45 до 700 граммов.",
                    Age =1, AnimalGroupId=4, Image="Homyak.jpg" },

                new Animal { AnimalId = 11, AnimalName="Бенгальская кошка",
                    Description="Межродовой гибрид домашней кошки и бенгальской кошки ",
                    Age =7, AnimalGroupId=5, Image="Koshka.jpg" }
                });
                await context.SaveChangesAsync();
            }

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
