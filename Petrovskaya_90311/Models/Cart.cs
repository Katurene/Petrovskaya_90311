using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество калорий
        /// </summary>
        public int Age
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Animal.Age);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="animal">добавляемый объект</param>
        public void AddToCart(Animal animal)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(animal.AnimalId))
                Items[animal.AnimalId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(animal.AnimalId, new CartItem
                {
                    Animal = animal,
                    Quantity = 1
                });
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void ClearAll()
        {
            Items.Clear();
        }

        /// <summary>
        /// Клас описывает одну позицию в корзине
        /// </summary>        
    }
    public class CartItem
    {
        public Animal Animal { get; set; }
        public int Quantity { get; set; }
    }
}
