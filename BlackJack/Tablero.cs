using System;

public class Tablero
{
    string[] manoDefault = { "X", "X" };
    public void MesaSuperior()
    {
        Console.WriteLine("|------------------------------------------|");
        Console.WriteLine("|\t \t \t" + " \t \t   |");
        Console.WriteLine("|\t \t [X" + "]  " + "[X] \t \t   |");
        Console.WriteLine("|\t \t \t" + " \t \t   |");
        Console.Write("|\t \t ");
    }

    public void mensajeDeApuesta()
    {
        
    }
    

}