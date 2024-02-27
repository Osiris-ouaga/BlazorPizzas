using BlazorPizzas.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPizzas.Pages
{
    public class PizzasBase : ComponentBase 
    {
        protected bool isAdmin;

        protected List<Pizza> Basket;
        protected List<Pizza> Pizzas;
        protected Pizza EditingPizza;

        protected override void OnInitialized()
        {
            Basket = new List<Pizza>();
            Pizzas = new List<Pizza>
            {
                new Pizza{ Id =1, Name ="Bacon", Price = 12, Ingredients = new[] { "bacon", "mozzarella", "champignon", "emmental" }, ImageName = "bacon.jpg"  },
                new Pizza{ Id =2, Name ="4 fromages", Price= 11, Ingredients = new[] { "cantal", "mozzarella", "fromage de chèvre", "gruyère" }, ImageName = "cheese.jpg"  },
                new Pizza{ Id =3, Name ="Margherita", Price = 10, Ingredients = new[] { "sauce tomate", "mozzarella", "basilic" }, ImageName = "margherita.jpg"  },
                new Pizza{ Id =4, Name ="Mexicaine", Price=12, Ingredients = new[] { "boeuf", "mozzarella", "maïs", "tomates", "oignon", "coriandre" }, ImageName = "meaty.jpg"  },
                new Pizza{ Id =5, Name ="Reine", Price=11, Ingredients = new[] { "jambon", "champignons", "mozzarella" }, ImageName = "mushroom.jpg"  },
                new Pizza{ Id =6, Name ="Pepperoni", Price=11, Ingredients = new[] { "mozzarella", "pepperoni", "tomates" }, ImageName = "pepperoni.jpg"  },
                new Pizza{ Id =7, Name ="Végétarienne",Price = 10, Ingredients = new[] { "champignons", "roquette", "artichauts", "aubergine" }, ImageName = "veggie.jpg"  },
            };

            EditingPizza = null;
            isAdmin = false;
        }

        protected string Ingredients
        {
            get
            {
                return EditingPizza != null ? string.Join(separator: ",", EditingPizza.Ingredients) : null;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    EditingPizza.Ingredients = value.Split(separator: ',').Select(v => v.Trim()).ToArray();
                }
                else
                {
                    EditingPizza.Ingredients = null;
                }
            }
        }

        public void AddToBasket(Pizza pizza) => Basket.Add(pizza);

        public void RemoveFromBasket(Pizza pizza) => Basket.Remove(pizza);

        public void EditPizza(Pizza p)
        {
            EditingPizza = new Pizza
            {
                Id = p.Id,
                Name = p.Name,
                ImageName = p.ImageName,
                Ingredients = p.Ingredients,
                Price = p.Price
            };
        }

        public void Close()
        {
            var pizza = Pizzas.Find(p => p.Id == EditingPizza.Id);
            pizza.Price = EditingPizza.Price;
            pizza.Name = EditingPizza.Name;
            pizza.Ingredients = EditingPizza.Ingredients;
            EditingPizza = null;
        }
    }
}
