using System;
using Microsoft.VisualBasic;

class MainProgramm
{
    static void Main(string[] args)
    {
        //Invocando clases
        Jugador player = new Jugador(); //Información del Jugador
        Contrincante bot = new Contrincante();
        Cartas card = new Cartas(); //Las cartas que se jugaran
        Random rand = new Random(); //Numero random
        Tablero tablero = new Tablero();

        
        bool partida = true;
        bool otraCrt = false;
        bool APP = true;
        bool AsP = true;//Es posible la apuesta?


        Console.WriteLine("Bienvenido al casino CASTILLO");
        //Console.Write("Por favor, introduzca su nombre de Jugador: ");
        //player.nombre = Console.ReadLine();

        Console.WriteLine("Bienvenido jugador \"" + player.nombre + "\"");

        Console.WriteLine(player.monedas);
        //player.info();
        //card.carta();
        player.monedas += 500;
        Console.WriteLine("Te regalamos 500 monedas extras:" + player.monedas);


        //------------El programa empieza a repartir las cartas----------------//

        
        while(partida==true){
            int[] cartaValor = new int[20]; //Este array sera para imprimir las cartas (su valor del 1 al 11)
            int[] cartaSimbolo = new int[20]; //Este array sera para imprimir las cartas (Su simbolo)
            int[] manoValor = new int[5]; //Este array suma el valor de las cartas
            int AP=0; //La apuesta de ambos jugadores
            int As = 0;
            int ApBot = 0;

            Console.WriteLine("Hagan sus apuestas");
            Console.WriteLine("Cuanto quieres apostar jugador ");
            Console.WriteLine("");
            Console.WriteLine("SALDO: " + player.monedas);
            Console.Write("APUESTA: ");

            while (!int.TryParse(Console.ReadLine(), out AP))
            {
                Console.WriteLine("ENTRADA INVALIDA. POR FAVOR, INGRESA UN NUMERO ENTERO: ");
            }
            Console.WriteLine("Muy bien, veamos si tu apuesta no supera tu saldo");

            do
            {
                if (AP > player.monedas)
                {
                    APP = false;
                    Console.WriteLine("!!NO TIENES ESA CANTIDAD DE DINERO!! ");
                    Console.WriteLine("Cuanto quieres apostar jugador ");
                    Console.WriteLine("");
                    Console.WriteLine("SALDO: " + player.monedas);
                    Console.Write("APUESTA: ");
                    while (!int.TryParse(Console.ReadLine(), out AP))
                    {
                        Console.WriteLine("ENTRADA INVALIDA. POR FAVOR, INGRESA UN NUMERO ENTERO: ");
                        Console.WriteLine("SALDO: " + player.monedas);
                        Console.Write("APUESTA: ");
                    }

                }
                else
                {
                    player.monedas -= AP;
                    ApBot = rand.Next(100,1001);

                    APP = true;
                    Console.WriteLine("Haz apostado: $" + AP);
                    Console.WriteLine("SALDO: " + player.monedas);
                    Console.WriteLine("");
                    Console.WriteLine("Tu contrincante ha apostado: "+ApBot);
                }
            } while (APP == false);

            tablero.MesaSuperior();

            for (int i = 0; i < 2; i++)
            {
                cartaSimbolo[i] = rand.Next(4);
                int numCarta = rand.Next(13); //Un numero random del 0 al 12
                cartaValor[i] = numCarta; //una carta del A a la K segun el rand
                manoValor[i] = numCarta + 1; /*El valor de la carta se agrega a un nuevo array*/

                if (numCarta == 10) { manoValor[i] = 10; }
                else if (numCarta == 11) { manoValor[i] = 10; }
                if (numCarta == 12) { manoValor[i] = 10; }

                Console.Write("[" + card.mazo[cartaSimbolo[i], cartaValor[i]] + "] ");//Imprime la carta            
            }

            int valorJuego = manoValor.Sum();
            Console.WriteLine("= " + valorJuego);

            for (int j = 0; j < 2; j++)
            {
                if (cartaValor[j] == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Tienes un A's en tu mano, ¿quieres que valga 1 u 11?");
                    Console.Write("Ingresa el numero 1 u 11: ");


                    while (!int.TryParse(Console.ReadLine(), out As))
                    {
                        Console.WriteLine("ENTRADA INVALIDA. POR FAVOR, INGRESA UN NUMERO ENTERO: ");
                    }
                    Console.WriteLine("");

                    do
                    {
                        if (As == 1 || As == 11)
                        {
                            AsP = true; 
                            

                        }
                        else
                        {
                           AsP = false;
                            Console.WriteLine("!!NUMERO NO VALIDO!! ");
                            Console.WriteLine("Por favor, ingresa un numero \"1\" u \"11\" ");
                            Console.WriteLine("");

                            while (!int.TryParse(Console.ReadLine(), out As))
                            {
                                Console.WriteLine("ENTRADA INVALIDA. POR FAVOR, INGRESA UN NUMERO ENTERO: ");
                            }
                        }
                        
                    } while (AsP == false);

                    switch (As)
                    {
                        case 1:
                            manoValor[j] = 1;
                            break;
                        case 11:
                            manoValor[j] = 11;
                            break;
                    }
                    Console.Write(" [" + card.mazo[cartaSimbolo[j], cartaValor[j]] + "] ");
                }

            }

            valorJuego = manoValor.Sum();
            Console.WriteLine(valorJuego);

            int cont = 2;
            do
            {
                Console.Write("¿Quieres otra carta? Sí(S)/No(N): ");
                string Resp = Console.ReadLine();

                if (Resp == "S" || Resp == "s")
                {
                    otraCrt = true;
                    cartaSimbolo[cont] = rand.Next(4);
                    int numCarta = rand.Next(13); //Un numero random del 0 al 12
                    cartaValor[cont] = numCarta; //una carta del A a la K segun el rand
                    manoValor[cont] = numCarta + 1; /*El valor de la carta se agrega a un nuevo array*/

                    if (numCarta == 10) { manoValor[cont] = 10; }
                    else if (numCarta == 11) { manoValor[cont] = 10; }
                    if (numCarta == 12) { manoValor[cont] = 10; }

                    cont++;

                }
                else { otraCrt = false; }

                for (int k = 0; k < cont; k++)
                {
                    Console.Write(" [" + card.mazo[cartaSimbolo[k], cartaValor[k]] + "] ");

                }

                valorJuego = manoValor.Sum();
                Console.WriteLine("= " + valorJuego);

                if (valorJuego > 21)
                {
                    otraCrt = false;
                }
            } while (otraCrt == true);

            bot.manoDelBOT();

            if (valorJuego < bot.manoValorBOT.Sum() || valorJuego > 21)
            {
                Console.WriteLine("Haz perdido");
                Console.WriteLine("TU contrincante se lleva la apuesta de: "+(AP + ApBot));
                
            }
            else if (valorJuego > bot.manoValorBOT.Sum() && valorJuego <= 21)
            {
                Console.WriteLine("Haz ganado");
                Console.WriteLine("La ganancias se agregan a tu saldo");
                player.monedas += (AP+ApBot);
            }

            Console.WriteLine("");
            Console.WriteLine("SALDO: " + player.monedas);
            Console.WriteLine("");
            Console.Write("¿Quieres volver a jugar? Sí(S)/No(N): ");
            string RespOtr = Console.ReadLine();

            if (RespOtr == "S" || RespOtr == "s")
            {
                partida = true;
                Console.WriteLine("Seguimos con la partida");
            }
            else
            {

                Console.WriteLine("Gracias por Jugar :D");
                partida = false;
            }


        } 


    }
}
