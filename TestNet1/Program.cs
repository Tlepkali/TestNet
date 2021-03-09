using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNet1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            Random rnd = new Random();
            for(int i = 0;i < arr.GetLength(0); ++i)
            {
                arr[i] = rnd.Next(1,100);
            }
            for(int i = 0;i < arr.GetLength(0); ++i)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.WriteLine($"{arr[i]} - четное и составное число");
                }else{
                    string simple = "простое";
                    for(int j = 3;j < arr[i] / 3; j += 2)
                    {
                        if(arr[i] % j == 0)
                        {
                            simple = "составное";
                            break;
                        }
                    }
                    Console.WriteLine($"{arr[i]} - нечетное и {simple} число");
                }
            }
            Console.WriteLine($"Сумма чисел массива равна : {arr.Sum()}");
        }
    }
}