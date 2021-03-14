using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class OpenWarehouse
    {
        public double area;
        public Dictionary <Item, int> items = new Dictionary<Item, int>();

        public Address address;
        public ResponsibleEmployee responsibleEmployee;
    }
}
