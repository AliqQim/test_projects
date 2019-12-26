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
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps("Logic");
                cfg.AddMaps("DAL");
            });

            config.AssertConfigurationIsValid();

            var info = new Logic.Logic(config.CreateMapper())
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
