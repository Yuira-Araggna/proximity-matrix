using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity_Matrix_LIB
{
    public class Person
    {
        private string refund;
        private string marital;
        private int tax;
        private string cheat;

        public Person(string refund, string marital, int tax, string cheat)
        {
            Refund = refund;
            Marital = marital;
            Tax = tax;
            Cheat = cheat;
        }

        public string Refund { get => refund; set => refund = value; }
        public string Marital { get => marital; set => marital = value; }
        public int Tax { get => tax; set => tax = value; }
        public string Cheat { get => cheat; set => cheat = value; }

    }
}
