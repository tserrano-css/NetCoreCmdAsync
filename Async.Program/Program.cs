using System;
using System.Threading.Tasks;

namespace Async.Program
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Café está listo");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("Huevos están listo");

            Bacon bacon = await  FryBaconAsync(3);
            Console.WriteLine("Tocino está listo");

            Toast toast = await ToastBreadAsync(2);
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

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Colocar una lamina de pan en la tostadora");
            }
            Console.WriteLine("Comenzar a tostar pan...");
            await Task.Delay(3000);
            Console.WriteLine("Terminar de tostar pan");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Colocar {slices} laminas de tocino en la sarten");
            Console.WriteLine("Cocinar tocino por arriba");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Dar vuelta al tocino");
            }
            Console.WriteLine("Cocinar el segundo lado del tocino...");
            await Task.Delay(3000);
            Console.WriteLine("Colocar el tocino en el plato");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Quebrar huevos en la sarten...");
            await Task.Delay(3000);
            Console.WriteLine($"Cocinar {howMany} huevos");
            await Task.Delay(3000);
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
