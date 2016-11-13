using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace nombrePremier
{
    class Program
    {
        private delegate int monDelegue(int x); 
        private static bool estPremier(int nb)
        {
            for(int i = 2; i<=(int)Math.Sqrt(nb); i++)
            {
                if(nb % i == 0)
                {
                    return false; 
                }
            }
            return true;
        } 

        private static int ComptePremier(int max)
        {
            int resultat = 0;
            for (int i = 2; i <= max; i++)
            {
                if (estPremier(i))
                {
                    resultat = resultat + 1; 
                }
            }
            return resultat;
        }
        static void Main(string[] args)
        {
            monDelegue calcul = ComptePremier;
            Console.Write("Saisir la valeur maximal pour le calcul : ");
            string nombreMax = Console.ReadLine();
            Console.WriteLine();
            int maximum = Int32.Parse(nombreMax);
            IAsyncResult asyncResult = calcul.BeginInvoke(maximum, new AsyncCallback(Complete), calcul);
            
            Console.WriteLine("Appuyer sur entrée pour arrêter avant la fin du calcul");
            Console.ReadLine(); 
        }

        static void Complete(IAsyncResult result)
        {
            monDelegue d = (monDelegue)result.AsyncState;
            Console.WriteLine("Resultat :" + d.EndInvoke(result));
        }
    }
}
