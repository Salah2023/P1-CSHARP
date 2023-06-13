using System;
using System.Diagnostics.Metrics;
using System.Net;

public class Program
{
//Quantes m'emporto?

     //Quan aprenem a sumar números aviat ens expliquen allò de “emportar-se'n una”: quan els dos dígits que sumem arriben a la desena tenim “carreig” que hem de sumar als següents dígits(de l'esquerra).

     //Quan els nostres mestres ens posaven exercicis, abans havien de comptar quantes vegades hauríem de "portar-nos-en una" i en base a això mesuraven la dificultat de l'exercici.

     //Pots fer un programa que automatitzi aquesta tasca?

     //Entrada
     //L'entrada estarà composta de nombrosos casos de prova, cadascun d'ells en una línia. A cada línia apareixeran dos números positius separats per un espai. Es garanteix que els números no tindran més de 1000 dígits.

     //Els casos de prova acaben amb el cas especial 0 0, que no provocarà sortida.

     //Sortida
     //Per a cada cas de prova cal escriure en una línia el nombre de vegades que hi ha "carreig" a la suma.

     //Entrada d'exemple
     //123 456
     //555 555
     //123 594
     //0 0
     //Sortida d'exemple

     //0
     //3
     //1
    public static void Main()
    {
       
        string numeroDeCasos = Console.ReadLine();  //Entrada de 2 numeros positius, separats entre espais més petits de 1000
        string[] split = numeroDeCasos.Split(" "); //Es guarden els numeros en la array en posicio 0 i 1
        int numeroLength1 = split[0].Length; //Guardo la llargada dels numeros guardats en aquesta posicio
        int numeroLength2 = split[1].Length; //Guardo la llargada dels numeros guardats en aquesta posicio
        int cont = 0; //Contador de numeros on la suma de 2 numeros supera 1 length

        //Aixo és per sortir del programa, si hi entra 2 zeros entre espais, es surt
        if (split[0] == "0" && split[1] =="0")
        {
            return;
        }
        //Aqui, declaro la condicio de que els 2 numeros siguen més petits de 1000
        if (numeroLength1 > 3 || numeroLength2 > 3)
        {
            Console.WriteLine("Los números no tendrán más de 1000 dígitos");
            return;
        }
         
        if (numeroLength1 - numeroLength2 != 0) //si la llargada del primero numero - el sgon numero és diferent de 0, es fa lo següent:
        {
            string numeropetit = ""; //Es guarda el numero que tingue menys llargada
            int num = Math.Abs(numeroLength1 - numeroLength2); //guardo la resta de la llargada dels 2 numeros
            // Aqui identifico el numero de llargada més petit i el guardo en la variable numeropetit --
            if (numeroLength1 > numeroLength2)
            {
                numeropetit = split[1];
            }
            else if (numeroLength2 > numeroLength1)
            {
                numeropetit = split[0];
            }
            //--

            for (int i = 0; i < num; i++) //Al for no para fins que la llargada de la resta dels 2 numeros sigue més petit de i
            {
                numeropetit = "0" + numeropetit; //Afageixo els zeros per compensar la diferencia de llargada entre els 2 numeros
            }
            //Identifico quin dels numeros, te la llargada més petita dels 2 i guardo la variable, numeropetit amb els zeros afagits en la posicio corresponent de la array
            if (numeroLength1 > numeroLength2) 
            {
                split[1] = numeropetit;
            }
            else if (numeroLength2 > numeroLength1)
            {
                split[0] = numeropetit;
            }
            //--
        }
        //!Important entendre que en aquest pont tant la posicio 0 i la posicio 1 del for, tenent mateixa mida o llargada
        for (int i = 0; i < split[0].Length; i++) //al for es para quan la llargada de la posicio 0 de la array es igual a la i
        {
            int num1 = int.Parse(split[0].Substring(split[0].Length -1 -i, 1)); //guardo un numero que es troba en la ultima posicio del primero numero
            int num2 = int.Parse(split[1].Substring(split[1].Length -1 -i, 1)); //guardo un numero que es troba en la ultima posicio del segon numero
            if ((num1 + num2).ToString().Length > 1) //si la llargada de la suma de les 2 variables és més gran que 1 es fa lo següent:
            {
                cont++; //La llargada de la suma dels primers numeros de la ultima posicio és més gran que 1, el contador augmenta
                if (split[0].Length == 1) //aqui comprovo la llargada del posicio 0 per veure si és igual a 1, per no continuar i sortir del bucle
                {
                    break;
                }
                //if (split[0].Length == 2) //si la llargada de la posicio 0 de la array és igual a 2, es fara el break per dortir de la array
                //{
                //    break;
                //}
                if (i < 2) // si i és més petit de 2
                {
                    try
                    {
                        num1 = int.Parse(split[0].Substring(split[0].Length -2 -i, 1)); //guardo la segona posicio del primero numero
                        num2 = int.Parse(split[1].Substring(split[1].Length -2 -i, 1)); //guardo la segona posicio del segon numero
                    }
                    catch { break; }
                        if ((num1 + num2 + 1).ToString().Length > 1) //si la llargada de la suma de les 2 variables + 1 és més gran que 1 es fa lo següent:
                    {
                        cont++; //augmenta el contador ja que la llargada de la suma dels 2 numeros + 1 és més gran que 1
                        if (split[0].Length == 2) //si la llargada de la posicio 0 de la array és igual a 2, es fara el break per dortir de la array
                        {
                            break;
                        }
                        if (i < 1) //si i és més petit de 1, faig aixo ja que es fa en la primera volta del for
                        {
                            try
                            {
                                num1 = int.Parse(split[0].Substring(split[0].Length -3 -i, 1)); //guardo la primera posicio del primero numero
                                num2 = int.Parse(split[1].Substring(split[1].Length -3 -i, 1)); //guardo la primera posicio del segon numero
                            }
                            catch { break; }
                                if ((num1 + num2 +1).ToString().Length > 1) //Si la llargada de la suma de les 2 variables + 1, és més gran de 1
                            {
                                cont++; //augmenta el contador ja que la llargada de la suma de les 2 variables + 1 és més gran de 1
                                break; //Sortim del bucle
                            }
                        }
                        break;//Acabem i sortim del bucle
                    }
                }
            }
        }
        Console.WriteLine(cont); //imprimeixo el resultat de la variable cont que és cuantes vegades quan és van sumar els 2 numeros, hi va haver una llargada més gran que 1
        Main(); //torno a repetir el procés
    }
}