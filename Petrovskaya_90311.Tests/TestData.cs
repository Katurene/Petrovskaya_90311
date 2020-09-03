using System;
using System.Collections.Generic;
using System.Text;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Tests
{
    public class TestData
    {
        //public static List<Animal> GetDishesList()
        //{
        //    return new List<Animal>
        //    {
        //        new Animal{ AnimalId=1},
        //        new Animal{ AnimalId=2},
        //        new Animal{ AnimalId=3},
        //        new Animal{ AnimalId=4},
        //        new Animal{ AnimalId=5}
        //    };
        //}

        public static List<Animal> GetDishesList()
        {
            return new List<Animal>
            {
                new Animal{ AnimalId=1, AnimalGroupId=1},
                new Animal{ AnimalId=2, AnimalGroupId=1},
                new Animal{ AnimalId=3, AnimalGroupId=2},
                new Animal{ AnimalId=4, AnimalGroupId=2},
                new Animal{ AnimalId=5, AnimalGroupId=3}
            };
        }

        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }
    }
}
