using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] familyMembers = { "Andriy", "Tanya", "Liliya", "Maksym", "Picachu", "Lady" };
            for (var i = 0; i < familyMembers.Length; i++)
            {
                Console.WriteLine($"{familyMembers[i]} Viytyk");
            }

            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            Console.ReadLine();
        }
    }
}
