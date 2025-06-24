using System;

public class Contrincante
{
    Cartas card = new Cartas(); //Las cartas que se jugaran
    Random rand = new Random(); //Numero random

    int[] cartaValorBOT = new int[5]; //Este array sera para imprimir las cartas (su valor del 1 al 11)
    int[] cartaSimboloBOT = new int[5]; //Este array sera para imprimir las cartas (Su simbolo)
    public int saldoBOT = 25000;

    public int[] manoValorBOT = new int[5];

    public void manoDelBOT()
    {
        for (int i = 0; i < 2; i++)
        {
            cartaSimboloBOT[i] = rand.Next(4);
            int numCartaBOT = rand.Next(13); //Un numero random del 0 al 12
            cartaValorBOT[i] = numCartaBOT; //una carta del A a la K segun el rand
            manoValorBOT[i] = numCartaBOT + 1; /*El valor de la carta se agrega a un nuevo array*/

            if (numCartaBOT == 10) { manoValorBOT[i] = 10; }
            else if (numCartaBOT == 11) { manoValorBOT[i] = 10; }
            if (numCartaBOT == 12) { manoValorBOT[i] = 10; }

            Console.Write(" [" + card.mazo[cartaSimboloBOT[i], cartaValorBOT[i]] + "] ");//Imprime la carta            
        }
        int valorJuegoBOT = manoValorBOT.Sum();
        Console.WriteLine("= "+valorJuegoBOT);
    }
   
    

}