using System;
using System.IO;
using System.Text;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                using var stream = new FileStream(@"c:\tmp\test_output.txt", FileMode.CreateNew);
                using var writer = new StreamWriter(stream, Encoding.Unicode);
                writer.Write("Алик ел салат");
            }

            {
                using var stream = new FileStream(@"c:\tmp\test_output2.txt", FileMode.CreateNew);
                using var writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write(" и закусывал простоквашей");
            }

            {
                using var stream = new FileStream(@"c:\tmp\test_output3.txt", FileMode.CreateNew);
                using var writer = new StreamWriter(stream, Encoding.Unicode);

                using var src1 = new FileStream(@"c:\tmp\test_output.txt", FileMode.Open, FileAccess.Read);
                using var reader1 = new StreamReader(src1);
                using var src2 = new FileStream(@"c:\tmp\test_output2.txt", FileMode.Open, FileAccess.Read);
                using var reader2 = new StreamReader(src2);


                while (!reader1.EndOfStream)
                    writer.Write((char)reader1.Read());

                while (!reader2.EndOfStream)
                    writer.Write((char)reader2.Read());



            }


            Console.WriteLine("DONE");
        }
    }
}
