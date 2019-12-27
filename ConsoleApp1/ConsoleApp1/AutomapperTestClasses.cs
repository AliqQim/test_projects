using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
    }

    public class MaleUser: User
    {
        public string CarName { get; set; }
    }

    public class FemaleUser : User
    {
        public int BoobsSize { get; set; }
    }


    public class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MaleUserDto : UserDto
    {
        public string CarName { get; set; }
    }

    public class FemaleUserDto : UserDto
    {
        public int BoobsSize { get; set; }
    }
}
