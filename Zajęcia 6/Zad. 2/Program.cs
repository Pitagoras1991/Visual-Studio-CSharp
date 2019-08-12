using System;

//Poniższy "pseudobiektowy" przykład przepisz stosując dziedziczenie i 
//funkcje wirtualne (zwierze powinno mieć głos). 
//Dodaj inne trenowane umiejętności (np. skoki). 
//Dodaj metodę ToString. Umieść zwierzęta w osobnej bibliotece. 
//W programie głównym dodaj definicje nowego zwierzęcia np. węża.

//KROK 1

class Zwierze
{
    public virtual void DajGlos()
    {
        Console.WriteLine("???");

    }
}
class Pies : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("hau");
    }

}
class Kot : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("miau");
    }
}
class Krowa : Zwierze
{
    public override void DajGlos()
    {

        Console.WriteLine("muuuu");
    }
}
class Mysz : Zwierze
{

}

class Waz : Zwierze
{
    public override void DajGlos()
    {
        Console.WriteLine("sss!");
    }
}

class Trener
{
    public static void DajGlos(Zwierze z)
    {
        z.DajGlos();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Zwierze p = new Pies();
        Zwierze k = new Kot();
        Zwierze m = new Krowa();
        Zwierze t = new Mysz();
        Zwierze w = new Waz();
        Trener.DajGlos(p);
        Trener.DajGlos(k);
        Trener.DajGlos(m);
        Trener.DajGlos(t);
        Trener.DajGlos(w);

        Console.ReadKey();
    }

}

