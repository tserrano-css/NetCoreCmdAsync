using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async.Program
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Café está listo");

            //Tareas que se ejecutan en paralelo
            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            var list = new List<Task>{eggsTask, baconTask, toastTask};

            while(list.Count > 0){
                //Cuando ALGUNA de estas tareas este completada avisamos al usuario
                Task finishedTask = await Task.WhenAny(list); 

                if (finishedTask == eggsTask)
                    Console.WriteLine("Huevos están listo");
                
                if (finishedTask == baconTask)
                    Console.WriteLine("Tocino está listo");

                if (finishedTask == toastTask)
                    Console.WriteLine("Tostadas están listo");

                list.Remove(finishedTask);
            }
            

            //Con WhenAll, el programa continua cuando TODAS las tareas se han completado
            /*await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("Huevos están listo");
            Console.WriteLine("Tocino está listo");
            Console.WriteLine("Tostadas están listo");
            */

            Juice oj = PourOJ();
            Console.WriteLine("Zumo está listo");

            Console.WriteLine("Desayuno completo!!");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Servir zumo de naranja");
            return new Juice();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number){
            Toast toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
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
