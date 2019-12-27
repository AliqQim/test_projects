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

            var users = new List<User>
            {
                new MaleUser
                {
                    Age = 21,
                    Name = "Алик",
                    CarName = "Kyron"
                },
                new FemaleUser
                {
                    Age = 18,
                    Name = "Света",
                    BoobsSize = 4
                }
            };


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<MaleUser, MaleUserDto>()
                    .IncludeBase<User, UserDto>();
                cfg.CreateMap<FemaleUser, FemaleUserDto>()
                    .IncludeBase<User, UserDto>();
            });
                

            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();
            var dto = mapper.Map<IList<UserDto>>(users);


            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }

    

}
