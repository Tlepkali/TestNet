using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Lift
    {
        public Lift(int numOfFloors,double capacity)
        {
            numberOfFloors = numOfFloors;
            currentFloor = 1;
            liftingCapacity = capacity;
            moving = false;
            doorOpenStatus = false;
            currentWeight = 0;
        }
        public void callTheLift(int x) {
            while (x > numberOfFloors || x < 1)
            {
                Console.WriteLine("Такого этажа не существует");
                x = int.Parse(Console.ReadLine());
            }
            if (currentFloor == x)
            {
                if (!moving)
                {
                    Console.WriteLine("Двери лифта открываются");
                    doorOpenStatus = true;
                    unload();
                    load();
                    doorOpenStatus = false;
                    inTheLift();
                }
                else
                {
                    Console.WriteLine($"Лифт останавливается на {currentFloor}-м этаже");
                    moving = false;
                    Console.WriteLine("Двери лифта открываются");
                    doorOpenStatus = true;
                    unload();
                    load();
                    doorOpenStatus = false;
                    inTheLift();
                }
            }
            else {
                if (!moving && !doorOpenStatus)
                {
                    goToFloor(x,currentWeight);
                }
            } 
        }
        public void goToFloor(int x,double currentWeight) {
            while (x > numberOfFloors || x < 1)
            {
                Console.WriteLine("Такого этажа не существует");
                x = int.Parse(Console.ReadLine());
            }
            if (doorOpenStatus) {
                Console.WriteLine("Двери лифта закрываются");
                doorOpenStatus = false;
            }
            Console.WriteLine("Лифт начинает своё движение");
            moving = true;
            if (x > currentFloor)
            {
                for(;currentFloor < x; ++currentFloor)
                {
                    Console.WriteLine($"Лифт проезжает {currentFloor} этаж");
                }
                moving = false;
                Console.WriteLine($"Лифт приехал на {currentFloor} этаж");
                Console.WriteLine("Двери лифта открываются");
                doorOpenStatus = true;
                unload();
                load();
                doorOpenStatus = false;
                inTheLift();
            }
            else if (x < currentFloor)
            {
                for (;currentFloor > x; --currentFloor)
                {
                    Console.WriteLine($"Лифт проезжает {currentFloor} этаж");
                }
                moving = false;
                Console.WriteLine($"Лифт приехал на {currentFloor} этаж");
                Console.WriteLine("Двери лифта открываются");
                doorOpenStatus = true;
                unload();
                load();
                doorOpenStatus = false;
                inTheLift();
            }
            else
            {
                Console.WriteLine("Двери лифта открываются");
                doorOpenStatus = true;
                unload();
                load();
                doorOpenStatus = false;
                inTheLift();
            }
        }
        public double currentWeight;
        private void inTheLift()
        {
            int x = 0;
            do
            {
                Console.WriteLine("Выберите нужный вам этаж или откройте дверь нажав 0");
                x = int.Parse(Console.ReadLine());
                if (x == 0)
                {
                    doorOpenStatus = true;
                    unload();
                    load();
                    doorOpenStatus = false;
                }
                else
                {
                    goToFloor(x, currentWeight);
                }
            } while (x == 0);
        }
        private void load()
        {
            Console.WriteLine("Введите суммарный вес вошедших в лифт");
            double n = double.Parse(Console.ReadLine());
            while(n + currentWeight > liftingCapacity || n < 0)
            {
                Console.WriteLine("Превышена грузоподьемность");
                Console.WriteLine("Введите суммарный вес вошедших в лифте");
                n = double.Parse(Console.ReadLine());
            }
            currentWeight += n;
        }
        private void unload()
        {
            Console.WriteLine("Введите суммарный вес покинувших лифт");
            double n = double.Parse(Console.ReadLine());
            while (n > currentWeight || n < 0)
            {
                Console.WriteLine("Введенеы некорректные данные");
                Console.WriteLine("Введите суммарный вес покинувших лифт");
                n = double.Parse(Console.ReadLine());
            }
            currentWeight -= n;
        }
        private bool moving;
        private bool doorOpenStatus;
        private int currentFloor;
        private static int numberOfFloors;
        private double liftingCapacity;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lift l1 = new Lift(10,1000);
            l1.callTheLift(1);
        }
    }
}
