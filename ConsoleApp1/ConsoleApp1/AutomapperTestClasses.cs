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
        public Branch Branch { get; set; }
    }

    public class Branch
    {
        public string Name { get; set; }
    }


    public class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BranchName { get; set; }
    }
}
