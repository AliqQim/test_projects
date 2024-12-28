
try
{
    f2();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
}



void f1()
{
    throw new Exception("Ura!");
}

void f2()
{
    try
    {
        f1();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
        throw;
    }
}