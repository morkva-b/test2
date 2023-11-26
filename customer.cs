using OpenQA.Selenium.DevTools.V117.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_l2
{
    internal class customer
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public customer() { Name = ""; Amount = ""; }
        public customer(string name, string amount) { Name = name; Amount = amount; }
    }
}
