using System;
using System.Threading.Tasks;

namespace Async.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Café está listo");

            Egg eggs = FryEggs(2);
            Console.WriteLine("Huevos están listo");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("Tocino está listo");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Tostadas están listo");

            Juice oj = PourOJ();
            Console.WriteLine("Zumo está listo");

            Console.WriteLine("Desayuno completo!!");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Servir zumo de naranja");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => 
            Console.WriteLine("Agregar mermelada a las tostadas");

        private static void ApplyButter(Toast toast) => 
            Console.WriteLine("Agregar mantequilla a las tostadas");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Colocar una lamina de pan en la tostadora");
            }
            Console.WriteLine("Comenzar a tostar pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Terminar de tostar pan");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"Colocar {slices} laminas de tocino en la sarten");
            Console.WriteLine("Cocinar tocino por arriba");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Dar vuelta al tocino");
            }
            Console.WriteLine("Cocinar el segundo lado del tocino...");
            Console.WriteLine("Colocar el tocino en el plato");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Quebrar huevos en la sarten...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Cocinar {howMany} huevos");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocar huevos en el plato");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Servir cafe");
            return new Coffee();
        }
    }

    internal class Coffee
    {
    }

    internal class Bacon
    {
    }

    internal class Juice
    {
    }

    internal class Toast
    {
    }

    internal class Egg
    {
    }
}
