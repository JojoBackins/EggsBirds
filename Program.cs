using System;


namespace PacktShered;
class Program
{
    static void Main(string[] args)
    {
        Bird bird;
        Console.WriteLine("\nPress P for pigeon, O for ostrich: ");
        char key = Char.ToUpper(Console.ReadKey().KeyChar);
        if (key == 'P') bird = new Pigeon();
        else if (key == '0') bird = new Ostrich();
        else return;
        Console.WriteLine("\nHow many eggs should it lay? ");
        if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
        Egg[] eggs = bird.LayEggs(numberOfEggs);
        foreach(Egg egg in eggs)
        {
            Console.WriteLine(egg.Description);
        }
    }
}

class Egg
{
    public double Size { get; private set; }
    public string Color { get; private set; }
    public Egg(double size, string color)
    {
        Size = size;
        Color = color;
    }
    public string Description
    {
        get { return $"A {Size:0.0}cm {Color} egg"; }
    }
}

class Bird
{
    public static Random rand = new Random();
    public virtual Egg[] LayEggs(int numberOfEggs)
    {
        Console.Error.WriteLine("Bird.LayEggs should never get called");
        return new Egg[0];
    }
}

class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for(int i = 0; i < eggs.Length; i++)
        {
            eggs[i] = new Egg(Bird.rand.NextDouble() * 2 + 1, "white");
            
        }
        return eggs;
    }
}

class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for(int i = 0; i < eggs.Length;i++)
        {
            eggs[i] = new Egg(Bird.rand.NextDouble() + 12, "speckled");
        }
        return eggs;
    }
}


