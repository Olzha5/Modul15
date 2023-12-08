using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul15
{
    public class MyClass
    {
        public int PublicProperty { get; set; }
        private string PrivateProperty { get; set; }

        public MyClass() { }

        private MyClass(int value)
        {
            PublicProperty = value;
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public Method Called");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private Method Called");
        }
    }

}
