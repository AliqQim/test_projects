using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var info = new Logic.Logic(null)
                .RequestDataFromLogic(); ;
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }

    
}
