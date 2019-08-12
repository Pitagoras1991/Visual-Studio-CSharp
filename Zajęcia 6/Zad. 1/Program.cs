using System;
using System.Collections.Generic;

//Korzystając z mechanizmu funkcji wirtualnych, 
//zmodyfikuj utworzone klasy na potrzeby programu operującego na oknach. 
// Zamień metodę DrawWindow w klasie Window na wirtualną. 
// Dodaj metodę wirtualną MoveWindow, 
// dodaj pola width i height oraz metodę ResizeWindow. 
//-BEZ TEGO ---------------Klasy "okienkowe" umieść w osobnej bibliotece Okna.dll i wykorzystaj ją w programie głównym. 
//Dodaj inne typy okien - CheckBox, RadioButton itp.



public abstract class Window
{
    // zawieszone w pewnym punkcie lewy górny róg okna
    protected int top;
    protected int left;
    protected int width;
    protected int heigth;

    public Window(int top, int left, int w, int h)
    {
        this.top = top;
        this.left = left;
        this.width = w;
        this.heigth = h;
    }
    // rysowanie 
    public virtual void DrawWindow()
    {
        Console.WriteLine("Zaczep : " + top + " " + left + ", szerokosc:" + width + "; wysokosc: " + heigth);
    }

    public virtual void MoveWindow(int x, int y)
    {
        top += y;
        left += x;
    }
    public virtual void ResizeWindow(int newWidth, int newHeight)
    {
        width = newWidth;
        heigth = newHeight;
    }
}

public class Panel : Window
{
    protected List<Window> okna;
    public Panel(int top, int left, int w, int h)
        : base(top, left, w, h)
    {
        okna = new List<Window>();
    }

    public override void DrawWindow()
    {
        Console.Write("Panel: "); base.DrawWindow();
        foreach (Window w in okna)
            w.DrawWindow();
    }

    public override void MoveWindow(int x, int y)
    {
        base.MoveWindow(x, y);
        foreach (Window w in okna)
            w.MoveWindow(x, y);
    }

    public void Dodaj(Window w)
    {
        okna.Add(w);
    }
}

public class TextBox : Window
{
    private string textBoxContents;

    public TextBox(int top, int left, string contents)
        : base(top, left, contents.Length + 2, 10)
    {
        textBoxContents = contents;
    }

    public override void DrawWindow()
    {
        Console.Write("textBox: {0} ", textBoxContents);
        base.DrawWindow();
    }

    public override void ResizeWindow(int newWidth, int newHeight)
    {
        base.ResizeWindow(newWidth, 10);// nie można zmienić wysokosci
    }
}

public class Button : Window
{
    private string name;
    public Button(int top, int left, string name)
        : base(top, left, name.Length + 4, 14)
    {
        this.name = name;
    }

    public override void DrawWindow()
    {
        Console.Write("button: {0} ", name);
        base.DrawWindow();
    }

    public override void ResizeWindow(int newWidth, int newHeight)
    {
        if (newHeight < 14) newHeight = 14;
        base.ResizeWindow(newWidth, newHeight);// minimalna wysokosć to 14
    }
}

class RadioButton : Window
{
    public RadioButton(int top, int left)
        : base(top, left, 10, 10)
    {
    }

    public override void DrawWindow()
    {
        Console.Write("radio button: ");
        base.DrawWindow();
    }

    public override void ResizeWindow(int newWidth, int newHeight)
    {
        // bez zmain
    }
}

public class Test
{
    static void Main()
    {
        Window[] winArray = new Window[5];
        winArray[0] = new TextBox(1, 2, "First Text Box");
        winArray[1] = new TextBox(3, 4, "Second Text Box");
        winArray[2] = new Button(5, 6, "Open");
        winArray[3] = new Button(9, 10, "Close");
        winArray[4] = new RadioButton(20, 20);
        for (int i = 0; i < winArray.Length; i++)
        {
            winArray[i].DrawWindow();
        }
        Console.WriteLine();
        Panel panel = new Panel(0, 0, 100, 100);
        panel.Dodaj(winArray[0]);
        panel.Dodaj(winArray[1]);
        panel.Dodaj(winArray[2]);
        panel.Dodaj(winArray[3]);

        panel.DrawWindow();
        Console.WriteLine();

        panel.Dodaj(winArray[4]);
        panel.MoveWindow(5, 5);
        panel.DrawWindow();
        Console.WriteLine();

        winArray[0].ResizeWindow(20, 20);
        winArray[1].ResizeWindow(40, 5);
        winArray[2].ResizeWindow(30, 20);
        winArray[3].ResizeWindow(50, 5);
        winArray[4].ResizeWindow(50, 50);
        panel.ResizeWindow(200, 300);
        panel.DrawWindow();

        Console.ReadKey();
    }
}         
