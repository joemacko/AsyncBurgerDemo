using BurgerMasterDemo.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerMasterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BurgerMaster burgerMaster = new BurgerMaster();

            var stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            Task<Patty> pattyTask = burgerMaster.CookPattyAsync();
            var friesTask = burgerMaster.FryFriesAsync();
            var produceTask = burgerMaster.ChopProduceAsync();
            var bunTask = burgerMaster.ToastBunAsync();

            // Cook patty
            Patty patty = pattyTask.Result;

            // Fry some fries
            Fries fries = friesTask.Result;

            // Chop some veggies
            Produce produce = produceTask.Result;

            // Toasted bun
            Bun bun = bunTask.Result;

            // Assemble burger
            Burger burger = burgerMaster.AssembleBurger();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
