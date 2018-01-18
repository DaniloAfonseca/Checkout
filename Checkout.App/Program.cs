using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCheckout = new Checkout();

            myCheckout.Scan("B");
            myCheckout.Scan("A");
            myCheckout.Scan("B");


            Console.WriteLine("B, A, B is {0}", myCheckout.GetTotal()); //95
            Console.WriteLine("Press any key to end ...");
            Console.ReadKey();
        }
    }
}
